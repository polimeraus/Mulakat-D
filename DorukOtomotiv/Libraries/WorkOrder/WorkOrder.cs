using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DorukOtomotiv.Libraries.WorkOrder
{   
    public class WorkOrder
    {
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

        // constructor default function
        public WorkOrder()
        {
            WorkOrderID = 0;
            StartDateTime = new DateTime();
            FinishDateTime = new DateTime();
        }
    }
}