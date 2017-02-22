using System.Collections.Generic;

namespace NStruct.Mapping
{
    /// <summary>
    /// The mapping manager
    /// </summary>
    public interface IMappingManager : IDependency
    {
        /// <summary>
        /// Gets the mapper.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <returns></returns>
        IMapper<TSource, TDestination> GetMapper<TSource, TDestination>()
            where TSource : class
            where TDestination : class;

        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        TDestination Map<TSource, TDestination>(TSource source)
            where TSource : class
            where TDestination : class;

        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source)
            where TSource : class
            where TDestination : class;
    }
}
