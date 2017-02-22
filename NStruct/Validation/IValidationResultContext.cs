using System.Collections.Generic;

namespace NStruct.Validation
{
    /// <summary>
    /// The validation result context
    /// </summary>
    public interface IValidationResultContext
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="IValidationResultContext"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        bool Success { get; }

        /// <summary>
        /// Gets the validation results.
        /// </summary>
        /// <value>
        /// The validation results.
        /// </value>
        IEnumerable<IValidationResult> ValidationResults { get; } 
    }
}
