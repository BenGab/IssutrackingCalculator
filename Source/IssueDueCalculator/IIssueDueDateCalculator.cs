using System;

namespace IssueDueCalculator
{
    public interface IIssueDueDateCalculator
    {
        DateTime CalculateDueDate(DateTime submitDate, uint turnAroundTime);
    }
}
