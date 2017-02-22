using System.Collections.Generic;

namespace NStruct.Validation
{
    /// <summary>
    /// The validation result context
    /// </summary>
    public class ValidationResultContext : IValidationResultContext
    {
        private readonly bool _success;
        private readonly IEnumerable<IValidationResult> _validationResults;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResultContext"/> class.
        /// </summary>
        public ValidationResultContext()
        {
            _success = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResultContext"/> class.
        /// </summary>
        /// <param name="validationResults">The validation results.</param>
        public ValidationResultContext(IEnumerable<IValidationResult> validationResults)
        {
            _validationResults = validationResults;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IValidationResultContext" /> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success
        {
            get { return _success; }
        }

        /// <summary>
        /// Gets the validation results.
        /// </summary>
        /// <value>
        /// The validation results.
        /// </value>
        public IEnumerable<IValidationResult> ValidationResults
        {
            get { return _validationResults; }
        }
    }
}