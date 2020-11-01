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
            if(startWorkingHour >= endWorkingHour)
            {
                throw new ArgumentException($"{nameof(startWorkingHour)} is bigger or equal than {nameof(endWorkingHour)}"); 
            }

            _startWorkingHour = startWorkingHour;
            _endWorkingHour = endWorkingHour;
        }

        public DateTime CalculateDueDate(DateTime submitDate, uint turnAroundTime)
        {
            uint daysRequired = turnAroundTime / DailyHours;
            DateTime result = submitDate;
            while(daysRequired > 0)
            {
                result = result.AddDays(1);
                if (result.DayOfWeek == DayOfWeek.Saturday || result.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }
                --daysRequired;
            }

            return result;
        }
    }
}
