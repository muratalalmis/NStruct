using System;
using System.Linq.Expressions;
using MongoDB.Driver;
using NStruct.NoSql.Document;
using NStruct.NoSql.Mongo.Builder;
using NStruct.Utility;

namespace NStruct.NoSql.Mongo.Repository.Builder
{
    /// <summary>
    /// The update builder
    /// </summary>
    /// <typeparam name="TDocument">The type of the document.</typeparam>
    public class UpdateBuilder<TDocument> : IUpdateBuilder<TDocument>
        where TDocument : IDocument
    {
        private UpdateDefinition<TDocument> _updateDefinition;

        /// <summary>
        /// Fors the specified expression.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="value">The value.</param>
        public IUpdateBuilder<TDocument> Set<TProperty>(Expression<Func<TDocument, TProperty>> expression, TProperty value)
        {
            var propertyName = ExpressionUtils.GetMemberName(expression);

            _updateDefinition = Builders<TDocument>.Update.Set(propertyName, value);

            return this;
        }

        /// <summary>
        /// Sets the with current date.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public IUpdateBuilder<TDocument> SetWithCurrentDate<TProperty>(Expression<Func<TDocument, TProperty>> expression, TProperty value)
        {
            var propertyName = ExpressionUtils.GetMemberName(expression);

            _updateDefinition = Builders<TDocument>.Update.Set(propertyName, value).CurrentDate(i => i.ModifiedOn);

            return this;
        }

        /// <summary>
        /// Gets the update definition.
        /// </summary>
        /// <value>
        /// The update definition.
        /// </value>
        public MongoDB.Driver.UpdateDefinition<TDocument> UpdateDefinition => _updateDefinition;
    }
}
