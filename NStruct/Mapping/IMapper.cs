using System.Collections.Generic;

namespace NStruct.Mapping
{
    /// <summary>
    /// This can be used in order to map between source and destination. 
    /// </summary>
    public interface IMapper : IDependency
    {
    }

    /// <summary>
    /// The Mapper Interface can be used in order to map between source and destination.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TDestination">The type of the destination.</typeparam>
    public interface IMapper<in TSource, out TDestination> : IMapper
         where TSource : class
         where TDestination : class
    {
        /// <summary>
        /// Maps the specified t source.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        TDestination Map(TSource source);

        /// <summary>
        /// Maps the specified sources.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        IEnumerable<TDestination> Map(IEnumerable<TSource> source);
    }
}
