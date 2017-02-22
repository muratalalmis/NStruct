using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NStruct.Validation
{
    /// <summary>
    /// The default validation result
    /// </summary>
    public class DefaultValidationResult : ValidationResult, IValidationResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultValidationResult"/> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public DefaultValidationResult(string errorMessage) 
            : base(errorMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultValidationResult"/> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="memberNames">The list of member names that have validation errors.</param>
        public DefaultValidationResult(string errorMessage, IEnumerable<string> memberNames) 
            : base(errorMessage, memberNames)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultValidationResult"/> class.
        /// </summary>
        /// <param name="validationResult">The validation result object.</param>
        protected DefaultValidationResult(ValidationResult validationResult) 
            : base(validationResult)
        {
        }
    }
}