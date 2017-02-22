using System;
using System.Collections.Generic;
using System.Linq;
using NStruct.NoSql.Mongo.Builder;

namespace NStruct.NoSql.Document
{
    /// <summary>
    /// The mongo storage interface
    /// </summary>
    /// <seealso cref="IDocumentStorage" />
    public interface IMongoStorage : IDocumentStorage
    {
        /// <summary>
        /// Inserts the specified documents.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="documents">The documents.</param>
        void Insert<TDocument>(IEnumerable<TDocument> documents)
            where TDocument : IDocument;

        /// <summary>
        /// Updates the specified filter.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="updates">The updates.</param>
        bool Update<TDocument>(Action<IFilterBuilder<TDocument>> filter, params Action<IUpdateBuilder<TDocument>>[] updates)
            where TDocument : IDocument;
        
        /// <summary>
        /// Updates the many.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="updates">The updates.</param>
        bool UpdateMany<TDocument>(Action<IFilterBuilder<TDocument>> filter, params Action<IUpdateBuilder<TDocument>>[] updates)
            where TDocument : IDocument;
        
        /// <summary>
        /// Deletes the specified filter.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="filter">The filter.</param>
        void Delete<TDocument>(Action<IFilterBuilder<TDocument>> filter)
            where TDocument : IDocument;

        /// <summary>
        /// Deletes the specified filter.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="filter">The filter.</param>
        void DeleteMany<TDocument>(Action<IFilterBuilder<TDocument>> filter)
            where TDocument : IDocument;

        /// <summary>
        /// Firsts this instance.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <returns></returns>
        TDocument First<TDocument>()
            where TDocument : IDocument;

        /// <summary>
        /// Lasts this instance.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <returns></returns>
        TDocument Last<TDocument>()
            where TDocument : IDocument;

        /// <summary>
        /// Queries this instance.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <returns></returns>
        IQueryable<TDocument> Query<TDocument>()
          where TDocument : IDocument;
    }
}