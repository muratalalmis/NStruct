using System;

namespace NStruct.Jobs.Triggers
{
    /// <summary>
    /// The delegate trigger
    /// </summary>
    public class DelegateTrigger : ITrigger
    {
        /// <summary>
        /// Gets or sets the mahchine.
        /// </summary>
        /// <value>
        /// The mahchine.
        /// </value>
        public Func<bool> Mahchine { get; set; }
    }
}
