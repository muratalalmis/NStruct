using System;
using System.Linq.Expressions;
using NStruct.NoSql.Document;

namespace NStruct.NoSql.Mongo.Builder
{
    /// <summary>
    /// The update builder
    /// </summary>
    /// <typeparam name="TDocument">The type of the document.</typeparam>
    public interface IUpdateBuilder<TDocument>
        where TDocument : IDocument
    {
        /// <summary>
        /// Fors the specified expression.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="value">The value.</param>
        IUpdateBuilder<TDocument> Set<TProperty>(Expression<Func<TDocument, TProperty>> expression, TProperty value);

        /// <summary>
        /// Sets the with current date.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        IUpdateBuilder<TDocument> SetWithCurrentDate<TProperty>(Expression<Func<TDocument, TProperty>> expression, TProperty value);
    }
}
