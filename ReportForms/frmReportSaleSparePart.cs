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
using System.Windows.Forms;

namespace CarSellingSystem.ReportForms
{
    public partial class frmReportSaleSparePart : Form
    {
        public frmReportSaleSparePart()
        {
            InitializeComponent();
        }

        private void frmReportSaleSparePart_Load(object sender, EventArgs e)
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

                string sql = "SELECT *,N'" + from_date_to_date + "' as from_date_to_date FROM v_sellSparePart_item Where status_id=1 ";
                if (txtTranNo.Text != "")
                {
                    sql = sql + " And sale_no LIKE N'%" + txtTranNo.Text + "%' ";
                }
                else if (txtCustomer.Text != "")
                {
                    sql = sql + " And cus_full_name LIKE N'%" + txtCustomer.Text + "%' OR cus_tel LIKE N'%" + txtCustomer.Text + "%' ";
                }
                else
                {
                    sql = sql + " And sale_date Between '" + dtFrom.Value + "' And '" + dtTo.Value + "' ";
                }
                sql = sql + " Order By sale_date DESC";

                dt = "v_sellSparePart_item";
                rpt = new ReportSaleSparePart();

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
