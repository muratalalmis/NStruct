using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace NStruct.Validation
{
    /// <summary>
    /// The validation exception class.
    /// </summary>
    [Serializable]
    public class ValidationException : CoreException
    {
        const string MESSAGE = "Object has not validated.";
        const string MEMBER_NAMES = "Member Names : {0}";
        const string ERROR_MESSAGE = "Message : {0}";

        private readonly string _message;
        private readonly IEnumerable<IValidationResult> _validatationResults;

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        public override string Message
        {
            get
            {
                if (_validatationResults == null)
                {
                    return _message;
                }

                var builder = new StringBuilder();
                builder.AppendLine(MESSAGE);
                if (_validatationResults.Any())
                {
                    foreach (var validatationResult in _validatationResults)
                    {
                        builder.AppendLine(string.Format(ERROR_MESSAGE, validatationResult.ErrorMessage));
                        builder.AppendLine(string.Format(MEMBER_NAMES, string.Concat(validatationResult.MemberNames, ",")));
                    }
                }

                return builder.ToString();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        public ValidationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException" /> class.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        public ValidationException(Exception innerException)
            : base(null, innerException)
        {
        }

        public ValidationException(IEnumerable<IValidationResult> validatationResults)
        {
            _message = MESSAGE;
            _validatationResults = validatationResults;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ValidationException(string message)
            : base(message)
        {
            _message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is a null reference (Nothing in Visual Basic). </exception> 
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*"/>
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter"/>
        /// </PermissionSet>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
