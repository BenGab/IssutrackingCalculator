using System;

namespace IssueDueCalculator
{
    public class IssueDueDateHourCalculator : IIssueDueDateCalculator
    {
        private readonly uint _startWorkingHour;
        private readonly uint _endWorkingHour;

        public uint DailyHour => _endWorkingHour - _startWorkingHour;

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
            uint daysRequired = turnAroundTime / DailyHour;

            return submitDate.AddDays(daysRequired);
        }
    }
}
