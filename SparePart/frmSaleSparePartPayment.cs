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

namespace CarSellingSystem.SparePart
{
    public partial class frmSaleSparePartPayment : Form
    {
        public frmSaleSparePartPayment()
        {
            InitializeComponent();
        }

        public long transaction_id = 0;

        private myClass db = new myClass();

        decimal totalSPP = 0;

        Decimal totalBuyPaid = 0;

        Decimal totalBuyBalance = 0;

        long tran_currency_id = 0;

        double exc_bath_usd = 0;
        double exc_kip_usd = 0;
        double exc_kip_bath = 0;

        private void frmSaleSparePartPayment_Load(object sender, EventArgs e)
        {
            db.FillCombo(cboPayType, "tbl_pay_type", "pay_type_name", "pay_type_id", "status_id=1", "pay_type_id", false);
            db.FillCombo(cboCurPay, "tbl_currency", "cur_name", "cur_id", "status_id=1", "", false);

            tran_currency_id = db.nLookup("sell_currency_id", "tbl_sell_sparePart_item", "sale_id=" + transaction_id);

            exc_bath_usd = db.NLookupDouble("bath_usd", "tbl_exchange_rate", "status_id=1");
            exc_kip_usd = db.NLookupDouble("kip_usd", "tbl_exchange_rate", "status_id=1");
            exc_kip_bath = db.NLookupDouble("kip_bath", "tbl_exchange_rate", "status_id=1");

            loadCalcPayment();
            loadPaymentHistory();

            cboCurPay.SelectedValue = tran_currency_id;

            txtPaying.Focus();
        }

        private void loadCalcPayment()
        {

            //txtPayingSPP.Enabled = true;
            //cboTotalBuy_payer.Enabled = true;
            //txtPayingFee.Enabled = true;
            //cboTotalFee_payer.Enabled = true;
            btnSave.Enabled = true;

            totalSPP = db.XSum("sell_price * sell_qty", "tbl_sell_sparePart_item", "sale_id=" + transaction_id + " And status_id=1");

            totalBuyPaid = db.XSum("pay_amount_in_currency", "tbl_sell_sparePart_payment", "sale_id=" + transaction_id + " And status_id=1");

            totalBuyBalance = totalSPP - totalBuyPaid;

            txtTotalSPP.Text = totalSPP.ToString(globalVariable.format_currency_usd);

            txtTotalBuy_paid.Text = totalBuyPaid.ToString(globalVariable.format_currency_usd);
            txtTotalBuy_balance.Text = totalBuyBalance.ToString(globalVariable.format_currency_usd);

            if (totalBuyBalance <= 0)
            {
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            double paySPPAmount = db.ToNumber(txtPaying.Text);
            double paySPPAmount_in_buy_cur = 0;
            double payAmountInUsd = 0;

            if (paySPPAmount == 0)
            {
                MessageBox.Show("ກະລຸນາປ້ອນຈຳນວນເງິນຊຳລະກ່ອນ.");
                txtPaying.Focus();
                return;
            }

            int pay_cur_id = Convert.ToInt32(cboCurPay.SelectedValue);
            if (tran_currency_id == pay_cur_id)
            {
                paySPPAmount_in_buy_cur = paySPPAmount;
            }
            else
            {
                if (tran_currency_id == 1)
                {
                    if (pay_cur_id == 2)
                    {
                        paySPPAmount_in_buy_cur = paySPPAmount * exc_kip_bath;
                    }
                    else if (pay_cur_id == 3)
                    {
                        paySPPAmount_in_buy_cur = paySPPAmount * exc_kip_usd;
                    }
                }
                else if (tran_currency_id == 2)
                {
                    if (pay_cur_id == 1)
                    {
                        paySPPAmount_in_buy_cur = paySPPAmount / exc_kip_bath;
                    }
                    else if (pay_cur_id == 3)
                    {
                        paySPPAmount_in_buy_cur = paySPPAmount * exc_bath_usd;
                    }
                }
                else if (tran_currency_id == 3)
                {
                    if (pay_cur_id == 1)
                    {
                        paySPPAmount_in_buy_cur = paySPPAmount / exc_kip_usd;
                    }
                    else if (pay_cur_id == 2)
                    {
                        paySPPAmount_in_buy_cur = paySPPAmount / exc_bath_usd;
                    }
                }
            }

            DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການບັນທຶກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
            if (result == DialogResult.No)
            {
                return;
            }

            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                try
                {
                    string insertQuery = @"
                    INSERT INTO [dbo].[tbl_sell_sparePart_payment]
                    (
                        pay_date, sale_id, pay_type_id, pay_type_name, pay_currency_id,
                        pay_amount, pay_amount_in_currency, remark,
                        rate_kip2bath, rate_kip2usd, rate_bath2usd,payAmountInUsd, status_id,
                        created_date, created_user
                    )
                    VALUES
                    (
                        @pay_date, @sale_id, @pay_type_id, @pay_type_name, @pay_currency_id,
                        @pay_amount, @pay_amount_in_currency, @remark,
                        @rate_kip2bath, @rate_kip2usd, @rate_bath2usd,@payAmountInUsd, @status_id,
                        @created_date, @created_user
                    );";

                    conn.Open();

                    if (pay_cur_id != 3)
                    {
                        payAmountInUsd = db.C2USD(pay_cur_id, paySPPAmount);
                    }
                    else
                    {
                        payAmountInUsd = paySPPAmount;
                    }

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@pay_date", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@sale_id", transaction_id);
                        cmd.Parameters.AddWithValue("@pay_type_id", cboPayType.SelectedValue);
                        cmd.Parameters.AddWithValue("@pay_type_name", cboPayType.Text);
                        cmd.Parameters.AddWithValue("@pay_currency_id", cboCurPay.SelectedValue);
                        cmd.Parameters.AddWithValue("@pay_amount", paySPPAmount);
                        cmd.Parameters.AddWithValue("@pay_amount_in_currency", paySPPAmount_in_buy_cur);
                        cmd.Parameters.AddWithValue("@remark", "");
                        cmd.Parameters.AddWithValue("@rate_kip2bath", exc_kip_bath);
                        cmd.Parameters.AddWithValue("@rate_kip2usd", exc_kip_usd);
                        cmd.Parameters.AddWithValue("@rate_bath2usd", exc_bath_usd);
                        cmd.Parameters.AddWithValue("@payAmountInUsd", payAmountInUsd);
                        cmd.Parameters.AddWithValue("@status_id", 1);
                        cmd.Parameters.AddWithValue("@created_date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@created_user", globalVariable.g_user_name);
                        int rowsInserted = cmd.ExecuteNonQuery();
                    }                   

                    MessageBox.Show("ບັນທຶກສຳເລັດແລ້ວ.");
                    txtPaying.Text = "";
                    conn.Close();
                    loadCalcPayment();
                    loadPaymentHistory();
                    txtPaying.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ບັນທຶກມີຂໍ້ຜິດຜາດ. >> " + ex.Message.ToString());
                    conn.Close();
                }
            }
        }

        private void loadPaymentHistory()
        {
            dgvData.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM tbl_sell_sparePart_payment Where sale_id=" + transaction_id + " And status_id=1 order by pay_id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int rowIndex = dgvData.Rows.Add();
                        dgvData.Rows[rowIndex].Cells["col_pay_id"].Value = reader["pay_id"];
                        dgvData.Rows[rowIndex].Cells["col_pay_date"].Value = Convert.ToDateTime(reader["created_date"]).ToString(globalVariable.format_date_time);
                        dgvData.Rows[rowIndex].Cells["col_pay_des"].Value = "ຈ່າຍຄ່າອາໄຫຼ່";
                        dgvData.Rows[rowIndex].Cells["col_pay_amount"].Value = Convert.ToDecimal(reader["pay_amount"]).ToString(globalVariable.format_currency_usd);
                        int pay_currentcy = Convert.ToInt32(reader["pay_currency_id"]);
                        if (pay_currentcy == 1)
                        {
                            dgvData.Rows[rowIndex].Cells["col_currency"].Value = "ກີບ";
                        }
                        else if (pay_currentcy == 2)
                        {
                            dgvData.Rows[rowIndex].Cells["col_currency"].Value = "ບາດ";
                        }
                        else if (pay_currentcy == 3)
                        {
                            dgvData.Rows[rowIndex].Cells["col_currency"].Value = "ໂດລາ";
                        }

                        dgvData.Rows[rowIndex].Cells["col_pay_type_name"].Value = reader["pay_type_name"];
                        dgvData.Rows[rowIndex].Cells["col_user"].Value = reader["created_user"];
                        dgvData.Rows[rowIndex].Cells["col_item_del"].Value = "ລົບອອກ";
                    }
                }
                conn.Close();
                set_free_item_rowNo();
            }
        }

        private void set_free_item_rowNo()
        {
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                DataGridViewRow row = dgvData.Rows[i];
                row.Cells["col_item_no"].Value = i + 1;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtPaying_Leave(object sender, EventArgs e)
        {
            double c_amount = db.ToNumber(txtPaying.Text);
            txtPaying.Text = c_amount.ToString(globalVariable.format_currency_usd);
            calcPaySpp();
        }

        private void calcPaySpp()
        {
            double c_amount = db.ToNumber(txtPaying.Text);
            int pay_cur_id = Convert.ToInt32(cboCurPay.SelectedValue);
            Decimal totalPaid = 0;
            if (tran_currency_id == pay_cur_id)
            {
                totalPaid = Convert.ToDecimal(c_amount) + totalBuyPaid;
            }
            else
            {
                if (tran_currency_id == 1)
                {
                    if (pay_cur_id == 2)
                    {
                        c_amount = c_amount * exc_kip_bath;
                    }
                    else if (pay_cur_id == 3)
                    {
                        c_amount = c_amount * exc_kip_usd;
                    }
                }
                else if (tran_currency_id == 2)
                {
                    if (pay_cur_id == 1)
                    {
                        c_amount = c_amount / exc_kip_bath;
                    }
                    else if (pay_cur_id == 3)
                    {
                        c_amount = c_amount * exc_bath_usd;
                    }
                }
                else if (tran_currency_id == 3)
                {
                    if (pay_cur_id == 1)
                    {
                        c_amount = c_amount / exc_kip_usd;
                    }
                    else if (pay_cur_id == 2)
                    {
                        c_amount = c_amount / exc_bath_usd;
                    }
                }
                totalPaid = Convert.ToDecimal(c_amount) + totalBuyPaid;
            }

            Decimal totalBalance = totalSPP - totalPaid;

            txtTotalBuy_paid.Text = totalPaid.ToString(globalVariable.format_currency_usd);
            txtTotalBuy_balance.Text = totalBalance.ToString(globalVariable.format_currency_usd);
        }

        private void dgvData_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (e.ColumnIndex == -1)
            {
                return;
            }

            string columnName = dgvData.Columns[e.ColumnIndex].Name;

            if (columnName == "col_item_del")
            {
                DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການລົບອອກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    DataGridViewRow row = dgvData.Rows[e.RowIndex];
                    int del_item_id = Convert.ToInt32(row.Cells["col_pay_id"].Value);
                    if (del_item_id > 0)
                    {
                        string exc_qry = "update tbl_sell_sparePart_payment set status_id=2 where pay_id=" + del_item_id;
                        int exc = db.sqlExecute(exc_qry);
                    }
                    //dgvData.Rows.RemoveAt(e.RowIndex);
                    //set_free_item_rowNo();
                    loadCalcPayment();
                    loadPaymentHistory();
                }
            }
        }

    }
}
