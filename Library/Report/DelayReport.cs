using System;

namespace DorukOtomotiv.Libraries.Report
{
    public class DelayReportItem
    {
        // properties
        public int WorkOrderID { get; set; }
        public int DelayTypeID { get; set; }
        public string DelayTypeName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }
        public int DelayMinutes { get; set; }

        // constructor function
        public DelayReportItem(int workOrderID, int delayTypeID, string delayTypeName, DateTime startDateTime, DateTime finishDateTime, int delayMinutes)
        {
            WorkOrderID = workOrderID;
            DelayTypeID = delayTypeID;
            DelayTypeName = delayTypeName;
            StartDateTime = startDateTime;
            FinishDateTime = finishDateTime;
            DelayMinutes = delayMinutes;
        }
    }
}