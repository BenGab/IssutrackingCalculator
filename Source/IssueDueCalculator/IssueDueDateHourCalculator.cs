using System;

namespace IssueDueCalculator
{
    public class IssueDueDateHourCalculator : IIssueDueDateCalculator
    {
        private readonly uint _startWorkingHour;
        private readonly uint _endWorkingHour;

        public uint DailyHours => _endWorkingHour - _startWorkingHour;

        public IssueDueDateHourCalculator(uint startWorkingHour, uint endWorkingHour)
        {
            if (startWorkingHour >= endWorkingHour)
            {
                throw new ArgumentException($"{nameof(startWorkingHour)} is bigger or equal than {nameof(endWorkingHour)}");
            }

            _startWorkingHour = startWorkingHour;
            _endWorkingHour = endWorkingHour;
        }

        public DateTime CalculateDueDate(DateTime submitDate, uint turnAroundTime)
        {
            uint daysRequired = turnAroundTime / DailyHours;
            uint hoursRequired = turnAroundTime % DailyHours;
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
