using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DorukOtomotiv.Business;

namespace PresentationWin
{
    public partial class DorukOtomotiv : Form
    {
        public DorukOtomotiv()
        {
            InitializeComponent();
            DataTable reportData = new Implementations().GetRportDataFromHTMLToDataTable();            
            dataGridView1.DataSource = reportData;
        }
    }
}
