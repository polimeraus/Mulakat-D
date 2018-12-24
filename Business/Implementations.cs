using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DorukOtomotiv.Data;
using DorukOtomotiv.Libraries.WorkOrder;
using DorukOtomotiv.Libraries.Delay;
using DorukOtomotiv.Libraries.Report;
using System.Text.RegularExpressions;

namespace DorukOtomotiv.Business
{
    public class Implementations
    {
        public List<DelayReportItem> GetReportData()
        {
            WorkOrderList isemirleri = new WorkOrderList();
            DelayTypeList dt = new DelayTypeList();
            DelayRecordList duraksamalar = new DelayRecordList();

            List<DelayReportItem> reportData = new List<DelayReportItem>();
            reportData.Clear();


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
                        reportData.Add(
                                        new DelayReportItem(
                                            isEmri.WorkOrderID,
                                            delay.DelayTypeID,
                                            (dt.GetDelayTypeNameByID(delay.DelayTypeID)),
                                            conflictStartDateTime,
                                            conflictFinishDateTime,
                                            (int)conflictFinishDateTime.Subtract(conflictStartDateTime).TotalMinutes
                                            ));

                        //iki tarih arasını dakika olarak ölçmek istesek ?
                        //TimeSpan span = conflictFinishDateTime.Subtract(conflictStartDateTime);
                        //span.TotalMinutes;
                        //int intMinutes = TimeSpan.FromMinutes(span);
                    }
                }
            }


            return reportData;
        }

        public string GetRportHTMLFromReportData()
        {
            var reportData = GetReportData();

            //sadece is emirleri
            var isemirleriDistinct = from c in reportData
                                     group c by new { c.WorkOrderID } into g
                                     select new { g.Key.WorkOrderID };

            //sadece Delay Tip leri
            //ana kaynak datasından çekiyorum, doğrudan delay listesinden çekmiyorum, çünkü veri listesinde yoksa çıktıya sıfır kayıt şeklinde çıksın i,stemiyorum
            var delayTypesDistinct = from c in reportData
                                     group c by new { c.DelayTypeID, c.DelayTypeName } into g
                                     select new { g.Key.DelayTypeID, g.Key.DelayTypeName };


            //şimdi her bir iş emri için bir satış açılacağına göre,
            string s = "<table border=1>";
            s += "<tr>";
            s += "<th>İş Emri</th>";

            foreach (var itemDelay in delayTypesDistinct)
            {
                //o is emrinin o delay tipindeki tüm toplamı lazıms...                    

                s += "<th>" + itemDelay.DelayTypeName + "</th>";
            }

            s += "<th>Toplam</th>";
            s += "</tr>";
           
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


            //toplam satırını atalım
            s += "<tr>";
            s += "<td>Toplam</td>";
            foreach (var itemDelay in delayTypesDistinct)
            {
                s += "<td>" + reportData.Where(x => x.DelayTypeID == itemDelay.DelayTypeID).Sum(y => y.DelayMinutes).ToString() + "</td>";
            }
            //toplamların toplamı, bereket.. Allah ne verdiyse topla
            s += "<td>" + reportData.Sum(y => y.DelayMinutes).ToString() + "</td>";
            s += "</tr>";

            s += "</table>";

            return s;
        }
       
        public DataTable ConvertHTMLTablesToDataTable(string HTML)
        {
            DataTable dt = null;
            DataRow dr = null;
            DataColumn dc = null;
            string TableExpression = "<table[^>]*>(.*?)</table>";
            string HeaderExpression = "<th[^>]*>(.*?)</th>";
            string RowExpression = "<tr[^>]*>(.*?)</tr>";
            string ColumnExpression = "<td[^>]*>(.*?)</td>";
            bool HeadersExist = false;
            int iCurrentColumn = 0;
            int iCurrentRow = 0;

            // Get a match for all the tables in the HTML    
            MatchCollection Tables = Regex.Matches(HTML, TableExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

            // Loop through each table element    
            foreach (Match Table in Tables)
            {

                // Reset the current row counter and the header flag    
                iCurrentRow = 0;
                HeadersExist = false;

                // Add a new table to the DataSet    
                dt = new DataTable();

                // Create the relevant amount of columns for this table (use the headers if they exist, otherwise use default names)    
                if (Table.Value.Contains("<th"))
                {
                    // Set the HeadersExist flag    
                    HeadersExist = true;

                    // Get a match for all the rows in the table    
                    MatchCollection Headers = Regex.Matches(Table.Value, HeaderExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

                    // Loop through each header element    
                    foreach (Match Header in Headers)
                    {
                        //dt.Columns.Add(Header.Groups(1).ToString);  
                        dt.Columns.Add(Header.Groups[1].ToString());

                    }
                }
                else
                {
                    for (int iColumns = 1; iColumns <= Regex.Matches(Regex.Matches(Regex.Matches(Table.Value, TableExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase)[0].ToString(), RowExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase)[0].ToString(), ColumnExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase).Count; iColumns++)
                    {
                        dt.Columns.Add("Column " + iColumns);
                    }
                }

                // Get a match for all the rows in the table    
                MatchCollection Rows = Regex.Matches(Table.Value, RowExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

                // Loop through each row element    
                foreach (Match Row in Rows)
                {

                    // Only loop through the row if it isn't a header row    
                    if (!(iCurrentRow == 0 & HeadersExist == true))
                    {

                        // Create a new row and reset the current column counter    
                        dr = dt.NewRow();
                        iCurrentColumn = 0;

                        // Get a match for all the columns in the row    
                        MatchCollection Columns = Regex.Matches(Row.Value, ColumnExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

                        // Loop through each column element    
                        foreach (Match Column in Columns)
                        {

                            DataColumnCollection columns = dt.Columns;

                            if (!columns.Contains("Column " + iCurrentColumn))
                            {
                                //Add Columns  
                                dt.Columns.Add("Column " + iCurrentColumn);
                            }
                            // Add the value to the DataRow    
                            dr[iCurrentColumn] = Column.Groups[1].ToString();
                            // Increase the current column    
                            iCurrentColumn += 1;
                        }

                        // Add the DataRow to the DataTable    
                        dt.Rows.Add(dr);
                    }
                    // Increase the current row counter    
                    iCurrentRow += 1;
                }
            }
            return (dt);
        }

        public DataTable GetRportDataFromHTMLToDataTable()
        {
            return ConvertHTMLTablesToDataTable(GetRportHTMLFromReportData());
        }


    }



}
