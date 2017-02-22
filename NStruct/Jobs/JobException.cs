using System;

namespace NStruct.Jobs
{
    /// <summary>
    /// The task exception
    /// </summary>
    public class JobException : CoreException
    {
        public JobException(Exception exception)
            : base("Error occured when job running.", exception)
        {
        }
    }
}
