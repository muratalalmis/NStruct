using System.Text;

namespace NStruct.Mapping
{
    /// <summary>
    /// The unregistered mapping exception
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TDestination">The type of the destination.</typeparam>
    public class UnRegisteredMappingException<TSource, TDestination> : MappingException
    {
        const string MESSAGE = "Mapping has not registered for using types.";
        const string MESSAGE_TYPES = "Types : {0} => {1}";
        const string SOURCE_LOCATION = "Source Full Name : {0}";
        const string DESTINATION_LOCATION = "Destination Full Name : {0}";

        /// <summary>
        /// Throws when called mapping has not registered on IoC container.
        /// Initializes a new instance of the <see cref="UnRegisteredMappingException{TSource, TDestination}"/> class.
        /// </summary>
        public UnRegisteredMappingException()
        {
        }

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        public override string Message
        {
            get
            {
                var builder = new StringBuilder();

                var sourceType = typeof(TSource);
                var destinationType = typeof(TDestination);

                builder.AppendLine();
                builder.AppendLine(MESSAGE);
                builder.AppendLine();
                builder.AppendLine(string.Format(MESSAGE_TYPES, sourceType.Name, destinationType.Name));
                builder.AppendLine();
                builder.AppendLine(string.Format(SOURCE_LOCATION, sourceType.FullName));
                builder.AppendLine(string.Format(DESTINATION_LOCATION, destinationType.FullName));

                return builder.ToString();
            }
        }
    }
}
