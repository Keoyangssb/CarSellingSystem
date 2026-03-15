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
    public partial class frmReportSaleCar : Form
    {
        public frmReportSaleCar()
        {
            InitializeComponent();
        }
        private myClass db = new myClass();
        private void frmReportSaleCar_Load(object sender, EventArgs e)
        {
            //from_date.Value = DateTime.Now.AddDays(-7);
            db.FillCombo(cboMake, "tbl_make", "make_name", "make_id", "status_id=1", "", true);
            db.FillCombo(cboYear, "tbl_years", "year_name", "year_id", "status_id=1", "", true);
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
                DateTime fromDate = from_date.Value;
                DateTime toDate = to_date.Value;
                fromDate = DateTime.SpecifyKind(fromDate, DateTimeKind.Utc);
                toDate = DateTime.SpecifyKind(toDate, DateTimeKind.Utc);
                string from_date_to_date = "ຈາກວັນທີ " + fromDate.ToString("dd-MM-yyyy") + " ຫາ " + toDate.ToString("dd-MM-yyyy");

                string sql = "SELECT * ,N'" + from_date_to_date + "' as from_date_to_date FROM v_sell_car ";
                sql = sql + " Where status_id = 1 ";
                if (txt_cusFullName.Text != "")
                {
                    sql = sql + " And (cus_full_name LIKE N'%" + txt_cusFullName.Text + "%' OR cus_tel LIKE N'%" + txt_cusFullName.Text + "%')";
                }
                else
                {
                    sql = sql + " And sale_date Between '" + fromDate + "' And '" + toDate + "'";
                    if (cboMake.SelectedIndex > 0)
                    {
                        sql = sql + " And make_id=" + cboMake.SelectedValue;
                    }
                    if (cboModel.SelectedIndex > 0)
                    {
                        sql = sql + " And model_id=" + cboModel.SelectedValue;
                    }
                    if (cboYear.SelectedIndex > 0)
                    {
                        sql = sql + " And made_year=" + cboYear.SelectedValue;
                    }
                }
                sql = sql + " Order by sale_date ";

                dt = "v_sell_car";
                rpt = new ReportSaleCar();

                cmdReport.Connection = new SqlConnection(globalVariable.connectionString);
                cmdReport.CommandText = sql;
                cmdReport.CommandType = CommandType.Text;
                da.SelectCommand = cmdReport;
                da.Fill(ds, dt);
                rpt.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rpt;

            }

        }

        private void cboMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboModel.DataSource = null;
            cboModel.EndUpdate();
            if (cboMake.SelectedIndex > 0)
            {
                int selected_id = Convert.ToInt32(cboMake.SelectedValue);
                db.FillCombo(cboModel, "tbl_model", "model_name", "model_id", "make_id=" + selected_id, "", true);
            }
        }
    }
}
