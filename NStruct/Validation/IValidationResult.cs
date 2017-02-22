using System.Collections.Generic;

namespace NStruct.Validation
{
    /// <summary>
    /// The validation result
    /// </summary>
    public interface IValidationResult 
    {
        /// <summary>
        /// Gets the member names. It may be null.
        /// </summary>
        /// <value>
        /// The member names.
        /// </value>
        IEnumerable<string> MemberNames { get; }

        /// <summary>
        /// Gets the error message. It may be null.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        string ErrorMessage { get; }
    }
}
