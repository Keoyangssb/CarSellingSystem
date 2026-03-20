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
    public partial class frmProfitLoseReport2 : Form
    {
        public frmProfitLoseReport2()
        {
            InitializeComponent();
        }

        private myClass db = new myClass();

        private void frmProfitLoseReport2_Load(object sender, EventArgs e)
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

                DateTime reportDate;

                string exc_qry = " TRUNCATE TABLE tbl_profit_lose; ";
                int exc = db.sqlExecute(exc_qry);

                decimal exc_bath_usd = db.NLookupDecimal("bath_usd", "tbl_exchange_rate", "status_id=1");
                decimal exc_kip_usd = db.NLookupDecimal("kip_usd", "tbl_exchange_rate", "status_id=1");

                //buy car
                conn.Open();
                string sql = "SELECT pay_item_id, pay_item_name, SUM(pay_amount) AS total_paid_amount, payCurrencyId, SUM(payAmountInUsd) AS total_paid_usd FROM dbo.tbl_buy_cars_payment ";
                sql = sql + " Where pay_date Between '" + fromDate + "' And '" + toDate + "' And status_id = 1 ";
                sql = sql + " GROUP BY pay_item_name, payCurrencyId, pay_item_id ORDER BY pay_item_id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string item_name = "";
                            decimal expense_kip = 0;
                            decimal expense_bath = 0;
                            decimal expense_usd = 0;
                            decimal income_kip = 0;
                            decimal income_bath = 0;
                            decimal income_usd = 0;
                            decimal expense_kip2usd = 0;
                            decimal expense_bath2usd = 0;
                            decimal income_kip2usd = 0;
                            decimal income_bath2usd = 0;
                            int currencyId = 0;

                            item_name = reader["pay_item_name"].ToString();
                            currencyId = Convert.ToInt32(reader["payCurrencyId"]);
                            if (currencyId == 1)
                            {
                                expense_kip = Convert.ToDecimal(reader["total_paid_amount"]);
                                expense_kip2usd = Convert.ToDecimal(reader["total_paid_usd"]); 
                            }
                            else if (currencyId == 2)
                            {
                                expense_bath = Convert.ToDecimal(reader["total_paid_amount"]);
                                expense_bath2usd = Convert.ToDecimal(reader["total_paid_usd"]); 
                            }
                            else if (currencyId == 3)
                            {
                                expense_usd = Convert.ToDecimal(reader["total_paid_amount"]);
                            }

                            SaveProfitLoseReport(item_name, expense_kip, expense_bath, expense_usd, income_kip, income_bath, income_usd, expense_kip2usd, expense_bath2usd, income_kip2usd, income_bath2usd);
                        }
                    }
                }

                //buy spp
                cmd = new SqlCommand();
                //reader = new SqlDataReader();
                sql = "SELECT pay_item_id, pay_item_name, SUM(pay_amount) AS total_paid_amount, pay_currency_id, SUM(payAmountInUsd) AS total_paid_usd FROM tbl_buy_spare_part_payment ";
                sql = sql + " Where pay_date Between '" + fromDate + "' And '" + toDate + "' And status_id = 1 ";
                sql = sql + " GROUP BY pay_item_name, pay_currency_id, pay_item_id ORDER BY pay_item_name";
                cmd = new SqlCommand(sql, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string item_name = "";
                            decimal expense_kip = 0;
                            decimal expense_bath = 0;
                            decimal expense_usd = 0;
                            decimal income_kip = 0;
                            decimal income_bath = 0;
                            decimal income_usd = 0;
                            decimal expense_kip2usd = 0;
                            decimal expense_bath2usd = 0;
                            decimal income_kip2usd = 0;
                            decimal income_bath2usd = 0;
                            int currencyId = 0;

                            item_name = reader["pay_item_name"].ToString();
                            currencyId = Convert.ToInt32(reader["pay_currency_id"]);
                            if (currencyId == 1)
                            {
                                expense_kip = Convert.ToDecimal(reader["total_paid_amount"]);
                                expense_kip2usd = Convert.ToDecimal(reader["total_paid_usd"]);
                            }
                            else if (currencyId == 2)
                            {
                                expense_bath = Convert.ToDecimal(reader["total_paid_amount"]);
                                expense_bath2usd = Convert.ToDecimal(reader["total_paid_usd"]);
                            }
                            else if (currencyId == 3)
                            {
                                expense_usd = Convert.ToDecimal(reader["total_paid_amount"]);
                            }

                            SaveProfitLoseReport(item_name, expense_kip, expense_bath, expense_usd, income_kip, income_bath, income_usd, expense_kip2usd, expense_bath2usd, income_kip2usd, income_bath2usd);
                        }
                    }
                }

                //expense
                cmd = new SqlCommand();
                sql = "SELECT item_id, item_name, SUM(expense_amount) AS total_paid_amount, currency_id, SUM(payAmountInUsd) AS total_paid_usd FROM v_tblExpense_Detail ";
                sql = sql + " Where exp_date Between '" + fromDate + "' And '" + toDate + "' ";
                sql = sql + " GROUP BY item_id, item_name,currency_id ORDER BY item_name";
                cmd = new SqlCommand(sql, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string item_name = "";
                            decimal expense_kip = 0;
                            decimal expense_bath = 0;
                            decimal expense_usd = 0;
                            decimal income_kip = 0;
                            decimal income_bath = 0;
                            decimal income_usd = 0;
                            decimal expense_kip2usd = 0;
                            decimal expense_bath2usd = 0;
                            decimal income_kip2usd = 0;
                            decimal income_bath2usd = 0;
                            int currencyId = 0;

                            item_name = reader["item_name"].ToString();
                            currencyId = Convert.ToInt32(reader["currency_id"]);
                            if (currencyId == 1)
                            {
                                expense_kip = Convert.ToDecimal(reader["total_paid_amount"]);
                                expense_kip2usd = Convert.ToDecimal(reader["total_paid_usd"]);
                            }
                            else if (currencyId == 2)
                            {
                                expense_bath = Convert.ToDecimal(reader["total_paid_amount"]);
                                expense_bath2usd = Convert.ToDecimal(reader["total_paid_usd"]);
                            }
                            else if (currencyId == 3)
                            {
                                expense_usd = Convert.ToDecimal(reader["total_paid_amount"]);
                            }
                            SaveProfitLoseReport(item_name, expense_kip, expense_bath, expense_usd, income_kip, income_bath, income_usd, expense_kip2usd, expense_bath2usd, income_kip2usd, income_bath2usd);
                        }
                    }
                }

                ////sell car
                cmd = new SqlCommand();
                //reader = new SqlDataReader();
                sql = "SELECT SUM(pay_amount_usd) AS total_paid_usd, SUM(pay_amount_kip) AS total_paid_kip,SUM(pay_amount_bath) AS total_paid_bath,SUM(total_pay_in_usd) AS total_paid_in_usd FROM v_tbl_sell_car_payment_report ";
                sql = sql + " Where pay_date Between '" + fromDate + "' And '" + toDate + "' ";
                cmd = new SqlCommand(sql, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string item_name = "";
                            decimal expense_kip = 0;
                            decimal expense_bath = 0;
                            decimal expense_usd = 0;
                            decimal income_kip = 0;
                            decimal income_bath = 0;
                            decimal income_usd = 0;
                            decimal expense_kip2usd = 0;
                            decimal expense_bath2usd = 0;
                            decimal income_kip2usd = 0;
                            decimal income_bath2usd = 0;

                            item_name = "ຈ່າຍຄ່າລົດ";
                            income_kip = reader["total_paid_kip"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["total_paid_kip"]);
                            income_bath = reader["total_paid_bath"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["total_paid_bath"]);
                            income_usd = reader["total_paid_usd"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["total_paid_usd"]);

                            if (income_kip > 0)
                            {
                                income_kip2usd = income_kip / exc_kip_usd;
                            }
                            else if (income_bath > 0)
                            {
                                income_usd = income_bath / exc_bath_usd;
                            }
                            SaveProfitLoseReport(item_name, expense_kip, expense_bath, expense_usd, income_kip, income_bath, income_usd, expense_kip2usd, expense_bath2usd, income_kip2usd, income_bath2usd);
                        }
                    }
                }

                ////sell spp
                cmd = new SqlCommand();
                //reader = new SqlDataReader();
                sql = "SELECT SUM(pay_amount) AS total_paid_amount, pay_currency_id, SUM(payAmountInUsd) AS total_paid_usd FROM tbl_sell_sparePart_payment ";
                sql = sql + " Where pay_date Between '" + fromDate + "' And '" + toDate + "' And status_id=1 ";
                sql = sql + " GROUP BY pay_currency_id ";
                cmd = new SqlCommand(sql, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string item_name = "";
                            decimal expense_kip = 0;
                            decimal expense_bath = 0;
                            decimal expense_usd = 0;
                            decimal income_kip = 0;
                            decimal income_bath = 0;
                            decimal income_usd = 0;
                            decimal expense_kip2usd = 0;
                            decimal expense_bath2usd = 0;
                            decimal income_kip2usd = 0;
                            decimal income_bath2usd = 0;
                            int currencyId = 0;

                            item_name = "ຈ່າຍຄ່າອາໄຫຼ່";
                            currencyId = Convert.ToInt32(reader["pay_currency_id"]);
                            if (currencyId == 1)
                            {
                                income_kip = Convert.ToDecimal(reader["total_paid_amount"]);
                                income_kip2usd = Convert.ToDecimal(reader["total_paid_usd"]);
                            }
                            else if (currencyId == 2)
                            {
                                income_bath = Convert.ToDecimal(reader["total_paid_amount"]);
                                income_bath2usd = Convert.ToDecimal(reader["total_paid_usd"]);
                            }
                            else if (currencyId == 3)
                            {
                                income_usd = Convert.ToDecimal(reader["total_paid_amount"]);
                            }
                            SaveProfitLoseReport(item_name, expense_kip, expense_bath, expense_usd, income_kip, income_bath, income_usd, expense_kip2usd, expense_bath2usd, income_kip2usd, income_bath2usd);
                        }
                    }
                }

            }
        }

        private void SaveProfitLoseReport(string item_name,
        decimal? expense_kip,
        decimal? expense_bath,
        decimal? expense_usd,
        decimal? income_kip,
        decimal? income_bath,
        decimal? income_usd,
        decimal? expense_kip2usd,
        decimal? expense_bath2usd,
        decimal? income_kip2usd,
        decimal? income_bath2usd)
        {
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                try
                {
                    string query = @"
                    INSERT INTO tbl_profit_lose
                    (
                        item_name,
                        expense_kip,
                        expense_bath,
                        expense_usd,
                        income_kip,
                        income_bath,
                        income_usd,
                        expense_kip2usd,
                        expense_bath2usd,
                        income_kip2usd,
                        income_bath2usd
                    )
                    VALUES
                    (
                        @item_name,
                        @expense_kip,
                        @expense_bath,
                        @expense_usd,
                        @income_kip,
                        @income_bath,
                        @income_usd,
                        @expense_kip2usd,
                        @expense_bath2usd,
                        @income_kip2usd,
                        @income_bath2usd
                    )";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@item_name", (object)item_name ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@expense_kip", (object)expense_kip ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@expense_bath", (object)expense_bath ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@expense_usd", (object)expense_usd ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@income_kip", (object)income_kip ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@income_bath", (object)income_bath ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@income_usd", (object)income_usd ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@expense_kip2usd", (object)expense_kip2usd ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@expense_bath2usd", (object)expense_bath2usd ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@income_kip2usd", (object)income_kip2usd ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@income_bath2usd", (object)income_bath2usd ?? DBNull.Value);
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

                string sql = "SELECT *,N'" + from_date_to_date + "' as from_date_to_date FROM tbl_profit_lose ";
                sql = sql + " Order By id ";

                //dt = "dt_tempReportProfit";
                //rpt = new ReportProfitLose();
                dt = "dt_tempReportProfit2";
                rpt = new ReportProfitLose2();

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
