using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DorukOtomotiv.Libraries.Delay;


namespace DorukOtomotiv.Libraries.Report
{
    //buna gerek olmayadabilir bilmiyorum, ama rapor için yeni manipulasyonlar buraya eklebilir, o yüzden yazdık, ileride eklenecek işlemler için modülerlik sağladık
    public class DelayReportList
    {
        public List<DelayReportItem> listDelayReportItems
        {
            get
            {
                return listDelayReportItems;
            }
            set
            {
                listDelayReportItems = value;
            }
        }
        
        public void AddDelayReportItem(DelayReportItem item)
        {
            listDelayReportItems.Add(item);
        }

        public void ClearList()
        {
            listDelayReportItems.Clear();
        }

        // constructor function
        public DelayReportList()
        {
            listDelayReportItems = new List<DelayReportItem>();
        }
    }



    //hatta iş emri ID si bile interface den gelebilir 
    //interface hem buraya hem de delay e kalıtım bırakmalı    
    //şimdilik elimle yazıyorum sonradna iki interface den kalıtarak alacak şekilde yazacaz
    public class DelayReportItem
    {
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