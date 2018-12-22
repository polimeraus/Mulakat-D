using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DorukOtomotiv.Data;
using DorukOtomotiv.Libraries.WorkOrder;
using DorukOtomotiv.Libraries.Delay;
using DorukOtomotiv.Libraries.Report;


namespace DorukOtomotiv
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WorkOrderList isemirleri = new WorkOrderList();
            DelayRecordList duraksamalar = new DelayRecordList();
            DelayReportList reportList = new DelayReportList();
            
            //her bir iş emrini bir döngüye sokalım,
            foreach (WorkOrder isEmri in isemirleri.workOrderList)
            {
                //sonra da he rbir iş emri için gecikme (delay) tablosunu tamamen gezelim
                foreach (DelayRecord delay in duraksamalar.delayRecordList)
                {
                    if ((isEmri.StartDateTime >= delay.FinishDateTime) || (isEmri.FinishDateTime <= delay.StartDateTime))
                    {
                        //eğer hiçbir şekilde gecikme saati ile çakışma yoksa o delay i pas geç
                        continue;
                    }
                    else
                    {
                        DateTime conflictStartDateTime, conflictFinishDateTime;
                        //çakışma varsa çakışma süresini hesaplayalım ve ilgili delay kategorisinde toplayalım

                        //başlangıç
                        if (delay.StartDateTime <= isEmri.StartDateTime)  //delay in başlangıcı is emrinden önce ise başlangıcı is emri olarak kabul etmeliyiz
                            conflictStartDateTime = isEmri.StartDateTime;
                        else
                            conflictStartDateTime = delay.StartDateTime;  //şayet delay in başlangıcı is emrinin başlangıcından sonra ise başlangıç olarak delay başlangıcını kabul ediyoruz

                        //bitiş
                        if (delay.FinishDateTime >= isEmri.FinishDateTime)  //delay in bitişi is emrini geçmiş ise sadece is emri bitene kadar olan kısmı alıyoruz
                            conflictFinishDateTime = isEmri.FinishDateTime;
                        else
                            conflictFinishDateTime = delay.FinishDateTime;


                        //burayı belki bir true false ile kontrol edebiliriz, yani çakışma olmuşsa true ya dönen bir değişken gibi...
                        //delayRecordReport.Add(new DelayRecord(delay.DelayRecordID, delay.DelayTypeID, conflictStartDateTime, conflictFinishDateTime));
                        reportList.AddDelayReportItem(new DelayReportItem()

                        //iki tarih arasını dakika olarak ölçmek istesek ?
                        //TimeSpan span = conflictFinishDateTime.Subtract(conflictStartDateTime);
                        //span.TotalMinutes;
                        //int intMinutes = TimeSpan.FromMinutes(span);
                    }
                }
            }

            /*
            //burada raporu gride dökelim,
            var results = from p in delayRecordReport                          
                          group p by p.DelayTypeID  into g
                          select new { isemri=g. DelayTipi = g.Key, DelayToplamı = g.Count(), TolamSaat=  g.Sum(x => (x.FinishDateTime.Subtract(x.StartDateTime)).TotalMinutes) };
            //GridView1.DataSource = delayRecordReport.ToList();
            GridView1.DataSource = results.ToList();
            GridView1.DataBind();
            GridView1.AutoGenerateColumns = true;
            */
        }
    }
}