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
    public partial class frmProfitLoseReport : Form
    {
        public frmProfitLoseReport()
        {
            InitializeComponent();
        }
        private myClass db = new myClass();
        private void frmProfitLoseReport_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GenReport();
            LoadReport();
        }

        private void GenReport()
        {
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                DateTime fromDate = dtFrom.Value;
                DateTime toDate = dtTo.Value;
                fromDate = DateTime.SpecifyKind(fromDate, DateTimeKind.Utc);
                toDate = DateTime.SpecifyKind(toDate, DateTimeKind.Utc);

                int reportId = 0;
                DateTime reportDate;
                string reportType = "";
                string reportDetail = "";
                decimal reportAmount = 0;
                int currencyId = 0;
                string currencyName = "";
                decimal exchangeRate = 0;
                decimal amountInUsd = 0;

                string exc_qry = "Delete From tbl_tempReportProfit ";
                int exc = db.sqlExecute(exc_qry);

                //buy car
                conn.Open();
                string sql = "SELECT * FROM tbl_buy_cars_payment ";
                sql = sql + " Where pay_date Between '" + fromDate + "' And '" + toDate + "' And status_id = 1 ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reportType = "ຊື້ລົດ";
                        while (reader.Read())
                        {
                            reportId = Convert.ToInt32(reader["pay_id"]);
                            reportDate = Convert.ToDateTime(reader["pay_date"]);
                            reportDetail = reader["pay_item_name"].ToString();
                            reportAmount = -Convert.ToDecimal(reader["pay_amount"]);
                            currencyId = Convert.ToInt32(reader["payCurrencyId"]);
                            if (currencyId == 1)
                            {
                                exchangeRate = Convert.ToDecimal(reader["rate_kip2usd"]);
                                currencyName = "ກີບ";
                            }
                            else if (currencyId == 2)
                            {
                                exchangeRate = Convert.ToDecimal(reader["rate_bath2usd"]);
                                currencyName = "ບາດ";
                            }
                            else
                            {
                                exchangeRate = Convert.ToDecimal(reader["rate_kip2usd"]);
                                currencyName = "ໂດລາ";
                            }
                            amountInUsd = -Convert.ToDecimal(reader["payAmountInUsd"]);

                            SaveReport(reportId, reportDate, reportType, reportDetail, reportAmount, currencyId, currencyName, exchangeRate, amountInUsd);
                        }
                    }
                }

                //buy spp
                cmd = new SqlCommand();
                //reader = new SqlDataReader();
                sql = "SELECT * FROM tbl_buy_spare_part_payment ";
                sql = sql + " Where pay_date Between '" + fromDate + "' And '" + toDate + "' And status_id = 1 ";
                cmd = new SqlCommand(sql, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reportType = "ຊື້ອາໄຫລ່ລົດ";
                        while (reader.Read())
                        {
                            reportId = Convert.ToInt32(reader["pay_id"]);
                            reportDate = Convert.ToDateTime(reader["pay_date"]);
                            reportDetail = reader["pay_item_name"].ToString();
                            reportAmount = -Convert.ToDecimal(reader["pay_amount"]);
                            currencyId = Convert.ToInt32(reader["pay_currency_id"]);
                            if (currencyId == 1)
                            {
                                exchangeRate = Convert.ToDecimal(reader["rate_kip2usd"]);
                                currencyName = "ກີບ";
                            }
                            else if (currencyId == 2)
                            {
                                exchangeRate = Convert.ToDecimal(reader["rate_bath2usd"]);
                                currencyName = "ບາດ";
                            }
                            else
                            {
                                exchangeRate = Convert.ToDecimal(reader["rate_kip2usd"]);
                                currencyName = "ໂດລາ";
                            }
                            amountInUsd = -Convert.ToDecimal(reader["payAmountInUsd"]);

                            SaveReport(reportId, reportDate, reportType, reportDetail, reportAmount, currencyId, currencyName, exchangeRate, amountInUsd);
                        }
                    }
                }
                

                //expense
                cmd = new SqlCommand();
                //reader = new SqlDataReader();
                sql = "SELECT * FROM v_tblExpense_Detail ";
                sql = sql + " Where exp_date Between '" + fromDate + "' And '" + toDate + "'";
                cmd = new SqlCommand(sql, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reportType = "ລາຍຈ່າຍລວມ";
                        while (reader.Read())
                        {
                            reportId = Convert.ToInt32(reader["detail_id"]);
                            reportDate = Convert.ToDateTime(reader["exp_date"]);
                            reportDetail = reader["item_name"].ToString();
                            reportAmount = -Convert.ToDecimal(reader["expense_amount"]);
                            currencyId = Convert.ToInt32(reader["currency_id"]);
                            if (currencyId == 1)
                            {
                                exchangeRate = Convert.ToDecimal(reader["kip_usd"]);
                                currencyName = "ກີບ";
                            }
                            else if (currencyId == 2)
                            {
                                exchangeRate = Convert.ToDecimal(reader["bath_usd"]);
                                currencyName = "ບາດ";
                            }
                            else
                            {
                                exchangeRate = Convert.ToDecimal(reader["kip_usd"]);
                                currencyName = "ໂດລາ";
                            }
                            amountInUsd = -Convert.ToDecimal(reader["payAmountInUsd"]);
                            SaveReport(reportId, reportDate, reportType, reportDetail, reportAmount, currencyId, currencyName, exchangeRate, amountInUsd);
                        }
                    }
                }
                

                //sell car
                cmd = new SqlCommand();
                //reader = new SqlDataReader();
                sql = "SELECT * FROM v_tbl_sell_car_payment_report ";
                sql = sql + " Where pay_date Between '" + fromDate + "' And '" + toDate + "' ";
                cmd = new SqlCommand(sql, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reportType = "ຂາຍລົດ";
                        while (reader.Read())
                        {
                            reportId = Convert.ToInt32(reader["pay_id"]);
                            reportDate = Convert.ToDateTime(reader["pay_date"]);
                            reportDetail = reader["sale_pay_type_name"].ToString();
                            reportAmount = Convert.ToDecimal(reader["total_pay_in_usd"]);
                            currencyId = 3;// Convert.ToInt32(reader["currency_id"]);
                            if (currencyId == 1)
                            {
                                exchangeRate = Convert.ToDecimal(reader["rate_kip2usd"]);
                                currencyName = "ກີບ";
                            }
                            else if (currencyId == 2)
                            {
                                exchangeRate = Convert.ToDecimal(reader["rate_bath2usd"]);
                                currencyName = "ບາດ";
                            }
                            else
                            {
                                exchangeRate = Convert.ToDecimal(reader["rate_kip2usd"]);
                                currencyName = "ໂດລາ";
                            }
                            amountInUsd = Convert.ToDecimal(reader["total_pay_in_usd"]);
                            SaveReport(reportId, reportDate, reportType, reportDetail, reportAmount, currencyId, currencyName, exchangeRate, amountInUsd);
                        }
                    }
                }

                //sell spp
                cmd = new SqlCommand();
                //reader = new SqlDataReader();
                sql = "SELECT * FROM tbl_sell_sparePart_payment ";
                sql = sql + " Where pay_date Between '" + fromDate + "' And '" + toDate + "' And status_id=1 ";
                cmd = new SqlCommand(sql, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reportType = "ຂາຍອາໄຫລ່ລົດ";
                        while (reader.Read())
                        {
                            reportId = Convert.ToInt32(reader["pay_id"]);
                            reportDate = Convert.ToDateTime(reader["pay_date"]);
                            reportDetail = "ລາຍຮັບຂາຍອາໄຫລ່ລົດ";
                            reportAmount = Convert.ToDecimal(reader["pay_amount"]);
                            currencyId = Convert.ToInt32(reader["pay_currency_id"]);
                            if (currencyId == 1)
                            {
                                exchangeRate = Convert.ToDecimal(reader["rate_kip2usd"]);
                                currencyName = "ກີບ";
                            }
                            else if (currencyId == 2)
                            {
                                exchangeRate = Convert.ToDecimal(reader["rate_bath2usd"]);
                                currencyName = "ບາດ";
                            }
                            else
                            {
                                exchangeRate = Convert.ToDecimal(reader["rate_kip2usd"]);
                                currencyName = "ໂດລາ";
                            }
                            amountInUsd = Convert.ToDecimal(reader["payAmountInUsd"]);
                            SaveReport(reportId, reportDate, reportType, reportDetail, reportAmount, currencyId, currencyName, exchangeRate, amountInUsd);
                        }
                    }
                }
            }
        }

        private void SaveReport(int reportId, DateTime reportDate, string reportType, string reportDetail, decimal reportAmount, int currencyId, string currencyName, decimal exchangeRate, decimal amountInUsd)
        {
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                try
                {
                    string query = @"
                            INSERT INTO [dbo].[tbl_tempReportProfit] (
                                [reportId], [reportDate], [reportType], [reportDetail], [reportAmount],[currencyId],[currencyName],[exchangeRate],[amountInUsd]
                            )
                            VALUES (
                                @reportId, @reportDate, @reportType, @reportDetail, @reportAmount,@currencyId,@currencyName,@exchangeRate,@amountInUsd);";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@reportId", reportId);
                        cmd.Parameters.AddWithValue("@reportDate", reportDate);
                        cmd.Parameters.AddWithValue("@reportType", reportType);
                        cmd.Parameters.AddWithValue("@reportDetail", reportDetail);
                        cmd.Parameters.AddWithValue("@reportAmount", reportAmount);
                        cmd.Parameters.AddWithValue("@currencyId", currencyId);
                        cmd.Parameters.AddWithValue("@currencyName", currencyName);
                        cmd.Parameters.AddWithValue("@exchangeRate", exchangeRate);
                        cmd.Parameters.AddWithValue("@amountInUsd", amountInUsd);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ບັນທຶກມີຂໍ້ຜິດຜາດ. >> " + ex.Message.ToString());
                    conn.Close();
                }
            }
        }

        private void LoadReport()
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

                string sql = "SELECT *,N'" + from_date_to_date + "' as from_date_to_date FROM tbl_tempReportProfit ";
                sql = sql + " Order By reportDate ";

                dt = "dt_tempReportProfit";
                rpt = new ReportProfitLose();

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
