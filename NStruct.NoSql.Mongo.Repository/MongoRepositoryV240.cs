using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using NStruct.NoSql.Document;
using NStruct.NoSql.Mongo.Builder;
using NStruct.NoSql.Mongo.Repository.Builder;
using NStruct.NoSql.Mongo.Repository.Configuration;

namespace NStruct.NoSql.Mongo.Repository
{
    /// <summary>
    /// The mongo repository 2.40
    /// </summary>
    /// <seealso cref="IMongoRepository" />
    public class MongoRepositoryV240 : IMongoRepository
    {
        #region Fields

        private IMongoDatabase _mongoDatabase;
        private readonly IMongoClient _client;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoRepositoryV240"/> class.
        /// </summary>
        /// <exception cref="NStruct.CoreException">Mongo db has not configured</exception>
        public MongoRepositoryV240()
        {
            if (MongoDbConfigurationHolder.CurrentConfiguration == null)
                throw new CoreException("Mongo db has not configured");

            _client = CreateClient(MongoDbConfigurationHolder.CurrentConfiguration);
        }

        /// <summary>
        /// Creates the client.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        /// <exception cref="NStruct.FatalException">
        /// Mongo host has not configured!
        /// or
        /// Database has not created!
        /// </exception>
        private IMongoClient CreateClient(IMongoConfiguration configuration)
        {
            if (string.IsNullOrEmpty(configuration.Host)) throw new FatalException("Mongo host has not configured!");
            if (string.IsNullOrEmpty(configuration.Database)) throw new FatalException("Database has not created!");

            var client = new MongoClient(MongoUrl.Create(configuration.Host));
            _mongoDatabase = client.GetDatabase(configuration.Database);

            return client;
        }

        #endregion

        #region Collection

        private IMongoCollection<TDocument> GetCollection<TDocument>()
            where TDocument : IDocument
        {
            var type = typeof(TDocument);
            return _mongoDatabase.GetCollection<TDocument>(type.Name);
        }

        private IMongoCollection<TDocument> GetCollectionUnSafe<TDocument>(string typeName)
        {
            return _mongoDatabase.GetCollection<TDocument>(typeName);
        }

        #endregion

        #region Insert

        /// <summary>
        /// Inserts the specified document.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="document">The document.</param>
        public void Insert<TDocument>(TDocument document) where TDocument : IDocument
        {
            document.DocumentId = Guid.NewGuid().ToString();
            document._id = document.DocumentId;

            GetCollection<TDocument>().InsertOne(document);
        }

        /// <summary>
        /// Inserts the specified documents.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="documents">The documents.</param>
        public void Insert<TDocument>(IEnumerable<TDocument> documents) where TDocument : IDocument
        {
            GetCollection<TDocument>().InsertMany(documents);
        }

        #endregion

        #region Get

        public IQueryable<TDocument> QueryUnSafe<TDocument>(string typeName)
        {
            try
            {
                var result = GetCollectionUnSafe<TDocument>(typeName);

                return result.AsQueryable();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public TDocument Get<TDocument>(string id) where TDocument : IDocument
        {
            return GetCollection<TDocument>().AsQueryable().FirstOrDefault(x => x.DocumentId == id);
        }
        #endregion

        #region Update

        /// <summary>
        /// Updates the specified filter.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="updates">The updates.</param>
        public bool Update<TDocument>(Action<IFilterBuilder<TDocument>> filter,
            params Action<IUpdateBuilder<TDocument>>[] updates) where TDocument : IDocument
        {
            var filterBuilder = new FilterBuilder<TDocument>();
            filter(filterBuilder);

            foreach (var updateBuilder in updates)
            {
                var tempBuilder = new UpdateBuilder<TDocument>();
                updateBuilder(tempBuilder);

                return
                    GetCollection<TDocument>()
                        .UpdateOne(filterBuilder.Filter, tempBuilder.UpdateDefinition)
                        .IsAcknowledged;
            }

            return default(bool);
        }

        /// <summary>
        /// Updates the many.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="updates">The updates.</param>
        public bool UpdateMany<TDocument>(Action<IFilterBuilder<TDocument>> filter,
            params Action<IUpdateBuilder<TDocument>>[] updates) where TDocument : IDocument
        {
            var filterBuilder = new FilterBuilder<TDocument>();
            filter(filterBuilder);

            foreach (var updateBuilder in updates)
            {
                var tempBuilder = new UpdateBuilder<TDocument>();
                updateBuilder(tempBuilder);

                return
                    GetCollection<TDocument>()
                        .UpdateMany(filterBuilder.Filter, tempBuilder.UpdateDefinition)
                        .IsAcknowledged;
            }

            return default(bool);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="id">The identifier.</param>
        public void Delete<TDocument>(string id) where TDocument : IDocument
        {
            GetCollection<TDocument>().DeleteOne(id);
        }

        /// <summary>
        /// Deletes the specified filter.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="filter">The filter.</param>
        public void Delete<TDocument>(Action<IFilterBuilder<TDocument>> filter) where TDocument : IDocument
        {
            var filterBuilder = new FilterBuilder<TDocument>();
            filter(filterBuilder);

            GetCollection<TDocument>().FindOneAndDelete(filterBuilder.Filter);
        }

        /// <summary>
        /// Deletes the specified filter.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="filter">The filter.</param>
        public void DeleteMany<TDocument>(Action<IFilterBuilder<TDocument>> filter) where TDocument : IDocument
        {
            var filterBuilder = new FilterBuilder<TDocument>();
            filter(filterBuilder);

            GetCollection<TDocument>().DeleteMany(filterBuilder.Filter);
        }

        #endregion

        #region Query

        /// <summary>
        /// Queries this instance.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <returns></returns>
        public IQueryable<TDocument> Query<TDocument>() where TDocument : IDocument
        {
            try
            {
                var result = GetCollection<TDocument>();

                return result.AsQueryable();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Firsts this instance.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <returns></returns>
        public TDocument First<TDocument>() where TDocument : IDocument
        {
            return GetCollection<TDocument>().AsQueryable().FirstOrDefault();
        }

        /// <summary>
        /// Lasts this instance.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <returns></returns>
        public TDocument Last<TDocument>() where TDocument : IDocument
        {
            return GetCollection<TDocument>().AsQueryable().LastOrDefault();
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <returns></returns>
        public int Count<TDocument>() where TDocument : IDocument
        {
            return GetCollection<TDocument>().AsQueryable().Count();
        }

        #endregion

        #region Aggregigate

        /// <summary>
        /// Groups the specified projection.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="projection">The projection.</param>
        public void Group<TDocument>(Action<IProjectionBuilder<TDocument>> projection) where TDocument : IDocument
        {
            var projectionBuilder = new ProjectionBuilder<TDocument>();
            projection(projectionBuilder);

            GetCollection<TDocument>().Aggregate().Group(projectionBuilder.ProjectDefinition);
        }

        #endregion
    }
}
