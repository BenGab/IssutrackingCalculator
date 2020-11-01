using System;

namespace IssueDueCalculator
{
    /// <summary>
    /// The component interface of Issue Date calculation
    /// </summary>
    public interface IIssueDueDateCalculator
    {
        /// <summary>
        /// The calculation of Due date
        /// </summary>
        /// <param name="submitDate">The issue submitted date</param>
        /// <param name="turnAroundTime">The expected time to take soluiton</param>
        /// <returns>The calculated date of resolution</returns>
        DateTime CalculateDueDate(DateTime submitDate, uint turnAroundTime);
    }
}
