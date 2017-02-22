using System;
using System.Collections.Generic;
using System.Linq;
using NStruct.NoSql.Document;
using NStruct.NoSql.Mongo;
using NStruct.NoSql.Mongo.Builder;

namespace NStruct.Document.Mongo
{
    /// <summary>
    /// The default mongodb storage implementation
    /// </summary>
    /// <seealso cref="IMongoStorage" />
    public class DefaultMongoStorage : IMongoStorage
    {
        private readonly IMongoRepository _mongoRepository;

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultMongoStorage"/> class.
        /// </summary>
        public DefaultMongoStorage(IMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository;
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
            _mongoRepository.Insert(document);
        }



        /// <summary>
        /// Inserts the specified documents.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="documents">The documents.</param>
        public void Insert<TDocument>(IEnumerable<TDocument> documents) where TDocument : IDocument
        {
            _mongoRepository.Insert(documents);
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
            if (!string.IsNullOrWhiteSpace(id))
            {
                _mongoRepository.Delete<TDocument>(id);
            }
        }

        /// <summary>
        /// Deletes the specified filter.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="filter">The filter.</param>
        public void Delete<TDocument>(Action<IFilterBuilder<TDocument>> filter) where TDocument : IDocument
        {
            _mongoRepository.Delete<TDocument>(filter);
        }

        /// <summary>
        /// Deletes the many.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="filter">The filter.</param>
        public void DeleteMany<TDocument>(Action<IFilterBuilder<TDocument>> filter) where TDocument : IDocument
        {
            _mongoRepository.DeleteMany<TDocument>(filter);
        }

        #endregion

        #region Update

        /// <summary>
        /// Updates the specified filter.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="updates">The updates.</param>
        public bool Update<TDocument>(Action<IFilterBuilder<TDocument>> filter, params Action<IUpdateBuilder<TDocument>>[] updates) where TDocument : IDocument
        {
            return _mongoRepository.Update(filter, updates);
        }

        /// <summary>
        /// Updates the many.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="updates">The updates.</param>
        public bool UpdateMany<TDocument>(Action<IFilterBuilder<TDocument>> filter, params Action<IUpdateBuilder<TDocument>>[] updates) where TDocument : IDocument
        {
            return _mongoRepository.UpdateMany(filter, updates);
        }

        /// <summary>
        /// Updates the specified document.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="document">The document.</param>
        public void Update<TDocument>(TDocument document) where TDocument : IDocument
        {
            _mongoRepository.Delete<TDocument>(document.DocumentId);
            _mongoRepository.Insert(document);
        }

        #endregion

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <returns></returns>
        public IQueryable<TDocument> List<TDocument>() where TDocument : IDocument
        {
            var queryable = _mongoRepository.Query<TDocument>();
            return queryable;
        }

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        public IQueryable<TDocument> List<TDocument>(TDocument sampleInstance, string typeName)
        {
            var queryable = _mongoRepository.QueryUnSafe<TDocument>(typeName);
            return queryable;
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public TDocument Get<TDocument>(string id) where TDocument : IDocument
        {
            return _mongoRepository.Get<TDocument>(id);
        }

        /// <summary>
        /// Firsts this instance.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <returns></returns>
        public TDocument First<TDocument>() where TDocument : IDocument
        {
            return _mongoRepository.First<TDocument>();
        }

        /// <summary>
        /// Lasts this instance.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <returns></returns>
        public TDocument Last<TDocument>() where TDocument : IDocument
        {
            return _mongoRepository.Last<TDocument>();
        }


        /// <summary>
        /// Queries this instance.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <returns></returns>
        public IQueryable<TDocument> Query<TDocument>() where TDocument : IDocument
        {
            return _mongoRepository.Query<TDocument>();
        }
    }
}
