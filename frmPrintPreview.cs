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

namespace CarSellingSystem
{
    public partial class frmPrintPreview : Form
    {
        public frmPrintPreview()
        {
            InitializeComponent();
        }

        public string report_name = "";
        public string report_query = "";
        public string report_query2 = "";
        public string report_query3 = "";
        public long print_transaction_id = 0;

        private void frmPrintPreview_Load(object sender, EventArgs e)
        {
            try
            {
                ReportDocument rpt = new ReportDocument();
                SqlCommand cmdReport = new SqlCommand();
                SqlCommand cmdReport_sub2 = new SqlCommand();
                SqlCommand cmdReport_sub3 = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlDataAdapter da_sub2 = new SqlDataAdapter();
                SqlDataAdapter da_sub3 = new SqlDataAdapter();
                dsReports ds = new dsReports();
                string dt = "";
                string dt_sub2 = "";
                string dt_sub3 = "";

                switch (report_name)
                {
                    case "SalesAndWarrantyAgreement":
                        dt = "dtSalesAndWarrantyAgreement";
                        rpt = new SalesAndWarrantyAgreement();

                        cmdReport.Connection = new SqlConnection(globalVariable.connectionString);
                        cmdReport.CommandText = report_query;
                        cmdReport.CommandType = CommandType.Text;

                        da.SelectCommand = cmdReport;
                        da.Fill(ds, dt);

                        dt_sub2 = "v_sell_car_payment";
                        cmdReport_sub2.Connection = new SqlConnection(globalVariable.connectionString);
                        cmdReport_sub2.CommandText = report_query2; 
                        cmdReport_sub2.CommandType = CommandType.Text;

                        da_sub2.SelectCommand = cmdReport_sub2;
                        da_sub2.Fill(ds, dt_sub2);

                        dt_sub3 = "tbl_sell_car_free_items";
                        cmdReport_sub3.Connection = new SqlConnection(globalVariable.connectionString);
                        cmdReport_sub3.CommandText = report_query3; 
                        cmdReport_sub3.CommandType = CommandType.Text;

                        da_sub3.SelectCommand = cmdReport_sub3;
                        da_sub3.Fill(ds, dt_sub3);

                        break;

                    case "rptSalesReceipt":
                        dt = "dtSalesAndWarrantyAgreement";
                        rpt = new rptSalesReceipt();

                        cmdReport.Connection = new SqlConnection(globalVariable.connectionString);
                        cmdReport.CommandText = report_query;
                        cmdReport.CommandType = CommandType.Text;

                        da.SelectCommand = cmdReport;
                        da.Fill(ds, dt);

                        dt_sub2 = "v_sell_car_payment";
                        cmdReport_sub2.Connection = new SqlConnection(globalVariable.connectionString);
                        cmdReport_sub2.CommandText = report_query2;
                        cmdReport_sub2.CommandType = CommandType.Text;

                        da_sub2.SelectCommand = cmdReport_sub2;
                        da_sub2.Fill(ds, dt_sub2);

                        break;

                    case "SaleFreeItemAndWarranty":
                        dt = "tbl_sell_car_free_items";
                        rpt = new SaleFreeItemAndWarranty();

                        cmdReport.Connection = new SqlConnection(globalVariable.connectionString);
                        cmdReport.CommandText = report_query;
                        cmdReport.CommandType = CommandType.Text;

                        da.SelectCommand = cmdReport;
                        da.Fill(ds, dt);

                        break;

                    case "rptOrderCarDepositAgreement":
                        dt = "dtSalesAndWarrantyAgreement";
                        rpt = new rptOrderCarDepositAgreement();

                        cmdReport.Connection = new SqlConnection(globalVariable.connectionString);
                        cmdReport.CommandText = report_query;
                        cmdReport.CommandType = CommandType.Text;

                        da.SelectCommand = cmdReport;
                        da.Fill(ds, dt);

                        break;

                    case "rptDepositAgreement":
                        dt = "dtSalesAndWarrantyAgreement";
                        rpt = new rptDepositAgreement();

                        cmdReport.Connection = new SqlConnection(globalVariable.connectionString);
                        cmdReport.CommandText = report_query;
                        cmdReport.CommandType = CommandType.Text;

                        da.SelectCommand = cmdReport;
                        da.Fill(ds, dt);

                        break;
                }

                

                rpt.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rpt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Print preview ມີຂໍ້ຜິດຜາດ. >> " + ex.Message.ToString());
            }

        }
    }
}
