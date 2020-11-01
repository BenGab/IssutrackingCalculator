using System;

namespace IssueDueCalculator
{
    /// <summary>
    /// The Hour calculation base implementation
    /// </summary>
    public class IssueDueDateHourCalculator : IIssueDueDateCalculator
    {
        private readonly uint _startWorkingHour;
        private readonly uint _endWorkingHour;

        public uint DailyHours => _endWorkingHour - _startWorkingHour;

        /// <summary>
        /// The Configuration constructor
        /// </summary>
        /// <param name="startWorkingHour">The hour of start work</param>
        /// <param name="endWorkingHour">The hour of end work</param>
        /// <exception cref="ArgumentException">When the start working hour is bigger than endworking hours</exception>
        public IssueDueDateHourCalculator(uint startWorkingHour, uint endWorkingHour)
        {
            if (startWorkingHour >= endWorkingHour)
            {
                throw new ArgumentException($"{nameof(startWorkingHour)} is bigger or equal than {nameof(endWorkingHour)}");
            }

            _startWorkingHour = startWorkingHour;
            _endWorkingHour = endWorkingHour;
        }

        /// <summary>
        /// The calculation of Due date
        /// </summary>
        /// <param name="submitDate">The issue submitted date</param>
        /// <param name="turnAroundTime">The expected time to take soluiton in hours</param>
        /// <returns>The calculated date of resolution</returns>
        /// <exception cref="ArgumentException">When the turnAroundTime is zero</exception>
        public DateTime CalculateDueDate(DateTime submitDate, uint turnAroundTime)
        {
            if(turnAroundTime == 0)
            {
                throw new ArgumentException($"{nameof(turnAroundTime)} cannot be zero");
            }

            DateTime result = submitDate;
            while (turnAroundTime > 0)
            {
                result = result.AddHours(1);
                if (result.DayOfWeek == DayOfWeek.Saturday || result.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }

                if(result.TimeOfDay.Hours <= _startWorkingHour || result.TimeOfDay.Hours > _endWorkingHour)
                {
                    continue;
                }

                --turnAroundTime;
            }

            return result;
        }
    }
}
