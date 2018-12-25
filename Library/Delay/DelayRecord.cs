using System;

namespace DorukOtomotiv.Libraries.Delay
{
    public class DelayRecord
    {
        // porperties
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
    }
}