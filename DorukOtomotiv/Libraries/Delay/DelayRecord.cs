using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DorukOtomotiv.Libraries.Delay
{
    public class DelayRecord
    {
        public long DelayRecordID { get; set; }
        public int DelayTypeID { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }

        // constructor function
        public DelayRecord(long delayRecordID, int delayTypeID, DateTime startDateTime, DateTime finishDateTime)
        {
            DelayRecordID = delayRecordID;
            DelayTypeID = delayTypeID;
            StartDateTime = startDateTime;
            FinishDateTime = finishDateTime;
        }

        // constructor default function
        public DelayRecord()
        {
            DelayRecordID = 0;
            DelayTypeID = 0;
            StartDateTime = new DateTime();
            FinishDateTime = new DateTime();
        }
    }
}