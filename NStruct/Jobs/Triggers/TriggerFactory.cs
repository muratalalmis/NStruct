using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NStruct.Jobs.Triggers
{
    /// <summary>
    /// The trigger factory
    /// </summary>
    public class TriggerFactory
    {
        private readonly ITrigger _trigger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TriggerFactory"/> class.
        /// </summary>
        /// <param name="trigger">The trigger.</param>
        public TriggerFactory(ITrigger trigger)
        {
            _trigger = trigger;
        }

        /// <summary>
        /// Forwards the specified next.
        /// </summary>
        /// <param name="next">The next.</param>
        /// <returns></returns>
        /// <exception cref="FatalException">Unknown trigger type</exception>
        public DateTime Forward(DateTime next)
        {
            var trigger = _trigger as TimeTrigger;
            if (trigger is SecondTrigger)
            {
                return next.AddSeconds(trigger.Interval);
            }
            else if (trigger is MinuteTrigger)
            {
                return next.AddMinutes(trigger.Interval);
            }
            else if (trigger is HourlyTrigger)
            {
                return next.AddHours(trigger.Interval);
            }
            else if (trigger is DailyTrigger)
            {
                return next.AddDays(trigger.Interval);
            }
            else if (trigger is WeeklyTrigger)
            {
                return next.AddDays(trigger.Interval * 7);
            }
            else if (trigger is MonthlyTrigger)
            {
                return next.AddMonths(trigger.Interval);
            }
            else if (trigger is YearlyTrigger)
            {
                return next.AddYears(trigger.Interval);
            }
            else
            {
                throw new FatalException("Unknown trigger type");
            }
        }
    }
}
