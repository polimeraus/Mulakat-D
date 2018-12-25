using System;
using DorukOtomotiv.Business;


namespace DorukOtomotiv
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region previous reports
            //var reportData = new Implementations().GetReportData();

            /*
            var sonuc = from c in reportData
                        group c by new
                        {
                            c.WorkOrderID,
                            c.DelayTypeID,
                            c.DelayTypeName
                        } into gcs

                        select new
                        {
                            isemri = gcs.Key.WorkOrderID,
                            GecikmeTipi = gcs.Key.DelayTypeName,
                            GecikmeSayisi = gcs.Count(),
                            GecikmeToplamSüresi = gcs.Sum(x => x.DelayMinutes)
                        };     

            GridView1.AutoGenerateColumns = true;
            GridView1.DataSource = sonuc.ToList();
            GridView1.DataBind();

            GridView2.AutoGenerateColumns = true;
            GridView2.DataSource = reportData.ToList();
            GridView2.DataBind();
            */
            #endregion

            string s = new Implementations().GetRportHTMLFromReportData();                 
            Response.Write(s);
        }

    }
}