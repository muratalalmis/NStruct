using System;
using System.Linq.Expressions;
using NStruct.NoSql.Document;

namespace NStruct.NoSql.Mongo.Builder
{
    /// <summary>
    /// The filter builder
    /// </summary>
    /// <typeparam name="TDocument">The type of the document.</typeparam>
    public interface IFilterBuilder<TDocument>
        where TDocument : IDocument
    {
        /// <summary>
        /// Fors the specified expression.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="param">The parameter.</param>
        /// <returns></returns>
        IFilterBuilder<TDocument> For<TProperty>(Expression<Func<TDocument, TProperty>> expression, TProperty param);

    }
}
