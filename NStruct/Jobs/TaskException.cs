using System;

namespace NStruct.Jobs
{
    /// <summary>
    /// The task exception
    /// </summary>
    public class TaskException : CoreException
    {
        public TaskException(Exception exception)
            : base("Error occured when task running.", exception)
        {
        }
    }
}
