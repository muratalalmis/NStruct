using System;
using System.Linq.Expressions;
using MongoDB.Driver;
using NStruct.NoSql.Document;
using NStruct.NoSql.Mongo.Builder;
using NStruct.Utility;

namespace NStruct.NoSql.Mongo.Repository.Builder
{
    /// <summary>
    /// The filter builder
    /// </summary>
    /// <typeparam name="TDocument">The type of the document.</typeparam>
    /// <seealso cref="IFilterBuilder{TDocument}" />
    public class FilterBuilder<TDocument> : IFilterBuilder<TDocument>
        where TDocument : IDocument
    {
        private FilterDefinition<TDocument> _filter;

        /// <summary>
        /// Gets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public FilterDefinition<TDocument> Filter => _filter;

        /// <summary>
        /// Fors the specified expression.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="param">The parameter.</param>
        /// <returns></returns>
        public IFilterBuilder<TDocument> For<TProperty>(Expression<Func<TDocument, TProperty>> expression, TProperty param)
        {
            var propertyName = ExpressionUtils.GetMemberName(expression);
            _filter = Builders<TDocument>.Filter.Eq(propertyName, param);

            return this;
        }
    }
}
