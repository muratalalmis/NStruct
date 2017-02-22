using System;
using System.Linq.Expressions;
using NStruct.NoSql.Document;

namespace NStruct.NoSql.Mongo.Builder
{
    /// <summary>
    /// The projection builder interface
    /// </summary>
    /// <typeparam name="TDocument">The type of the document.</typeparam>
    public interface IProjectionBuilder<TDocument>
        where TDocument : IDocument
    {
        IProjectionBuilder<TDocument> Include<TProperty>(Expression<Func<TDocument>> expression);
    }
}