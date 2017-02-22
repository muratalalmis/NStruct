using System;
using NStruct.Jobs.Scheduling;
using NStruct.Jobs.Triggers;

namespace NStruct.Jobs
{
    /// <summary>
    /// The schedulable job
    /// </summary>
    public abstract class SchedulableJob : Job, ISchedulable
    {
        private ITrigger _trigger;
        private DateTime _next;
        private DateTime? _last;

        public ITrigger Trigger => _trigger;

        public void Forward()
        {
            try
            {
                if (this.Enabled && this.Status != JobStatus.Working)
                {
                    this.Status = JobStatus.Working;
                    Run();

                    _last = DateTime.Now;
                }
                Iterate();
            }
            catch (Exception ex)
            {
                this.Status = JobStatus.Failed;

                throw new JobException(ex);
            }
        }

        public DateTime Next => _next;
        public DateTime Last => _last ?? default(DateTime);

        private void Iterate()
        {
            var factory = new TriggerFactory(this.Trigger);
            _next = factory.Forward(_last ?? DateTime.Now);

            this.Status = JobStatus.Ready;
        }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        public override void Run()
        {
            Process();
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        protected abstract void Process();
    }
}
