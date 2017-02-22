using System.Linq;

namespace NStruct.NoSql.Document
{
    /// <summary>
    /// The Document storage.
    /// </summary>
    public interface IDocumentStorage : IDependency
    {
        /// <summary>
        /// Inserts the specified document.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="document">The document.</param>
        void Insert<TDocument>(TDocument document)
             where TDocument : IDocument;

        /// <summary>
        /// Updates the specified document.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="document">The document.</param>
        void Update<TDocument>(TDocument document)
             where TDocument : IDocument;

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="id">The identifier.</param>
        void Delete<TDocument>(string id)
             where TDocument : IDocument;

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <returns></returns>
        IQueryable<TDocument> List<TDocument>()
            where TDocument : IDocument;

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <returns></returns>
        IQueryable<TDocument> List<TDocument>(TDocument sampleInstance, string typeName);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        TDocument Get<TDocument>(string id)
            where TDocument : IDocument;
    }
}
