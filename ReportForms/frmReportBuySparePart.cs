using CarSellingSystem.Reports;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms.ComponentModel;
using System.Windows.Forms;

namespace CarSellingSystem.ReportForms
{
    public partial class frmReportBuySparePart : Form
    {
        public frmReportBuySparePart()
        {
            InitializeComponent();
        }

        private void frmReportBuySparePart_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            SqlCommand cmdReport = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            dsReports ds = new dsReports();
            string dt = "";

            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                DateTime fromDate = dtFrom.Value;
                DateTime toDate = dtTo.Value;
                fromDate = DateTime.SpecifyKind(fromDate, DateTimeKind.Utc);
                toDate = DateTime.SpecifyKind(toDate, DateTimeKind.Utc);
                string from_date_to_date = "ຈາກວັນທີ " + fromDate.ToString("dd-MM-yyyy") + " ຫາ " + toDate.ToString("dd-MM-yyyy");

                string sql = "SELECT *,N'" + from_date_to_date + "' as from_date_to_date FROM v_buySparePart2 Where status_id=1 ";
                if (txtBuyNo.Text != "")
                {
                    sql = sql + " And buy_no LIKE N'%" + txtBuyNo.Text + "%'";
                }
                else
                {
                    sql = sql + " And buy_date Between '" + dtFrom.Value + "' And '" + dtTo.Value + "' ";
                }

                sql = sql + " Order By buy_date DESC";

                dt = "v_buySparePart2";
                rpt = new ReportBuySparePart();

                cmdReport.Connection = new SqlConnection(globalVariable.connectionString);
                cmdReport.CommandText = sql;
                cmdReport.CommandType = CommandType.Text;
                da.SelectCommand = cmdReport;
                da.Fill(ds, dt);
                rpt.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rpt;

            }
        }


    }
}
