using System.Collections.Generic;
using System.Linq;
using NStruct.Validation;

namespace NStruct.Mapping
{
    /// <summary>
    /// The base class can be used in order to map between source and destination. 
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TDestination">The type of the destination.</typeparam>
    public abstract class Mapper<TSource, TDestination> : IMapper<TSource, TDestination>
        where TDestination : class
        where TSource : class
    {
        /// <summary>
        /// Maps the specified t source.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public TDestination Map(TSource source)
        {
            Validator.AgainstNullArgument(nameof(source), source);

            return MapFrom(source);
        }

        /// <summary>
        /// Maps from.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        protected abstract TDestination MapFrom(TSource source);

        /// <summary>
        /// Maps the specified sources.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IEnumerable<TDestination> Map(IEnumerable<TSource> source)
        {
            Validator.AgainstNullArgument(nameof(source), source);

            return source.Select(MapFrom);
        }
    }
}
