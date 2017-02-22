using System.Collections.Generic;
using NStruct.IoC;

namespace NStruct.Mapping
{
    /// <summary>
    /// the mapping manager
    /// </summary>
    public class MappingManager : IMappingManager
    {
        private readonly IDictionary<string, IMapper> _mappers;

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingManager"/> class.
        /// </summary>
        public MappingManager(IEnumerable<IMapper> mappers)
        {
            _mappers = new Dictionary<string, IMapper>();
        }

        /// <summary>
        /// Gets the mapper.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <returns></returns>
        public IMapper<TSource, TDestination> GetMapper<TSource, TDestination>()
            where TSource : class
            where TDestination : class
        {
            try
            {
                var mapper = ContainerHolder.CurrentContainer.Resolve<IMapper<TSource, TDestination>>();

                return mapper;
            }
            catch
            {
                throw new UnRegisteredMappingException<TSource, TDestination>();
            }
        }

        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public TDestination Map<TSource, TDestination>(TSource source)
            where TSource : class
            where TDestination : class
        {
            var mapper = GetMapper<TSource, TDestination>();

            return mapper.Map(source);
        }

        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source)
            where TSource : class
            where TDestination : class
        {
            var mapper = GetMapper<TSource, TDestination>();

            return mapper.Map(source);
        }
    }
}
