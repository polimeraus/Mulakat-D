using System.Linq;
using System.Data;
using System.Collections.Generic;
using DorukOtomotiv.Libraries.Report;
using DorukOtomotiv.Data;
using DorukOtomotiv.Libraries.WorkOrder;
using DorukOtomotiv.Libraries.Delay;
using System;

namespace DorukOtomotiv.Business
{
    public class Implementations
    {
        // get main report data
        public List<DelayReportItem> GetReportData()
        {
            // master data to be prepared
            List<DelayReportItem> reportData = new List<DelayReportItem>();

            // we clear the list first
            reportData.Clear();

            // other requirements for data
            WorkOrderList isemirleri = new WorkOrderList();
            DelayTypeList dtl = new DelayTypeList();
            DelayRecordList duraksamalar = new DelayRecordList();

            // we loop for each work order 
            foreach (WorkOrder isEmri in isemirleri.workOrderList)
            {
                // we loop DelayRecord table for each work order
                foreach (DelayRecord delay in duraksamalar.delayRecordList)
                {
                    if ((isEmri.StartDateTime >= delay.FinishDateTime) || (isEmri.FinishDateTime <= delay.StartDateTime))
                    {
                        //eğer hiçbir şekilde gecikme saati ile çakışma yoksa o delay i pas geç
                        continue;
                    }
                    else
                    {
                        // if there is an conflict than calculate the minutes and add them to the related delay type category
                        DateTime conflictStartDateTime, conflictFinishDateTime;

                        // determine the conflict start
                        // if the delay start datetime is BEFORE than the work order datetime, set the conflict start to the work order start
                        if (delay.StartDateTime <= isEmri.StartDateTime)
                            conflictStartDateTime = isEmri.StartDateTime;
                        else
                            // if the delay start datetime is AFTER the the start to work order start datetime,  set the conflict start to the delay start
                            conflictStartDateTime = delay.StartDateTime;

                        // determine the conflict finish
                        // if the delay finish datetime is AFTER the work order finish datetime, set the conflict to the work order finish datetime
                        if (delay.FinishDateTime >= isEmri.FinishDateTime)
                            conflictFinishDateTime = isEmri.FinishDateTime;
                        else
                            conflictFinishDateTime = delay.FinishDateTime;


                        // add the item to the report data to show
                        reportData.Add(new DelayReportItem(
                                                               isEmri.WorkOrderID,
                                                               delay.DelayTypeID,
                                                               (dtl.GetDelayTypeNameByID(delay.DelayTypeID)),
                                                               conflictStartDateTime,
                                                               conflictFinishDateTime,
                                                               (int)conflictFinishDateTime.Subtract(conflictStartDateTime).TotalMinutes
                                                            ));
                    }
                }
            }

            return reportData;
        }
        
        // for web application, get report html
        public string GetRportHTMLFromReportData()
        {
            var reportData = GetReportData();

            // just work orders 
            var isemirleriDistinct = from c in reportData
                                     group c by new { c.WorkOrderID } into g
                                     select new { g.Key.WorkOrderID };

            // just delay types
            // we get from main data list
            var delayTypesDistinct = from c in reportData
                                     group c by new { c.DelayTypeID, c.DelayTypeName } into g
                                     select new { g.Key.DelayTypeID, g.Key.DelayTypeName };


            // each work order get a table row
            string s = "<table border=1 cellpadding=5 cellspacing=2 class='blueTable'>";
            s += "<thead>";
            s += "<tr>";
            s += "<th>İş Emri</th>";

            foreach (var itemDelay in delayTypesDistinct)
            {
                //o is emrinin o delay tipindeki tüm toplamı lazıms...                    

                s += "<th>" + itemDelay.DelayTypeName + "</th>";
            }

            s += "<th>Toplam</th>";
            s += "</tr>";
            s += "</thead>";

            s += "<tbody>";
            foreach (var itemIs in isemirleriDistinct)
            {
                s += "<tr>";
                s += "<td>" + itemIs.WorkOrderID.ToString() + "</td>";  //ilk kolon iş emrinin kendisi
                foreach (var itemDelay in delayTypesDistinct)
                {
                    //o is emrinin o delay tipindeki tüm toplamı lazıms...                    
                    s += "<td>" + reportData.Where(x => x.WorkOrderID == itemIs.WorkOrderID && x.DelayTypeID == itemDelay.DelayTypeID).Sum(y => y.DelayMinutes).ToString() + "</td>";
                }

                //en sağdaki toplam sütunu için bir koloın daha ekliyoruz, burada o iş emrinin tüm satır toplamı yer alacak
                s += "<td>" + reportData.Where(x => x.WorkOrderID == itemIs.WorkOrderID).Sum(y => y.DelayMinutes).ToString() + "</td>";
                s += "</tr>";
            }
            s += "</tbody>";

            // sum rows
            s += "<tfoot>";
            s += "<tr>";
            s += "<td style='font-weight: bold;'>Toplam</td>";
            foreach (var itemDelay in delayTypesDistinct)
            {
                s += "<td>" + reportData.Where(x => x.DelayTypeID == itemDelay.DelayTypeID).Sum(y => y.DelayMinutes).ToString() + "</td>";
            }

            // eventually column of sum of sums
            s += "<td  style='font-weight: bold;'>" + reportData.Sum(y => y.DelayMinutes).ToString() + "</td>";
            s += "</tr>";
            s += "</tfoot>";
            s += "</table>";

            return s;
        }       

        // for desktop application, html -> DataTable
        public DataTable GetRportDataFromHTMLToDataTable()
        {
            return Utilities.ConvertHTMLTablesToDataTable(GetRportHTMLFromReportData());
        }
    }
}
