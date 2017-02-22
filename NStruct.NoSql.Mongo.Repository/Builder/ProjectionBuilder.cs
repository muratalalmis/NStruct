using System;
using System.Linq.Expressions;
using MongoDB.Driver;
using NStruct.NoSql.Document;
using NStruct.NoSql.Mongo.Builder;
using NStruct.Utility;

namespace NStruct.NoSql.Mongo.Repository.Builder
{
    /// <summary>
    /// The projection builder implementation
    /// </summary>
    /// <typeparam name="TDocument">The type of the document.</typeparam>
    public class ProjectionBuilder<TDocument> : IProjectionBuilder<TDocument>
        where TDocument : IDocument
    {
        private ProjectionDefinition<TDocument> _projectionDefinition;


        /// <summary>
        /// Fors the specified expression.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public IProjectionBuilder<TDocument> Include<TProperty>(Expression<Func<TDocument>> expression)
        {
            var propertyName = ExpressionUtils.GetMemberName(expression);

            _projectionDefinition = Builders<TDocument>.Projection.Include(propertyName).Exclude(x => x.DocumentId);

            return this;
        }

        /// <summary>
        /// Gets the project definition.
        /// </summary>
        /// <value>
        /// The project definition.
        /// </value>
        public MongoDB.Driver.ProjectionDefinition<TDocument> ProjectDefinition => _projectionDefinition;
    }
}
