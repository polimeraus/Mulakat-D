using System;

namespace DorukOtomotiv.Libraries.WorkOrder
{   
    public class WorkOrder
    {
        // porperties
        public int WorkOrderID { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }

        // constructor function
        public WorkOrder(int workOrderID, DateTime startDateTime, DateTime finishDateTime)  
        {
            WorkOrderID = workOrderID;
            StartDateTime = startDateTime;
            FinishDateTime = finishDateTime;
        }
    }
}