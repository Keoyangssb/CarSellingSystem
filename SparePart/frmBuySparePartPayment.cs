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
    public partial class frmBuySparePartPayment : Form
    {
        public frmBuySparePartPayment()
        {
            InitializeComponent();
        }

        public long buy_transaction_id = 0;

        private myClass db = new myClass();

        decimal totalSPP = 0;
        decimal totalFee = 0;

        Decimal totalBuyPaid = 0;
        Decimal totalFeePaid = 0;

        Decimal totalBuyBalance = 0;
        Decimal totalFeeBalance = 0;

        long buy_spp_currency_id = 0;
        long buy_fee_currency_id = 0;
        double exc_bath_usd = 0;
        double exc_kip_usd = 0;

        private void frmBuySparePartPayment_Load(object sender, EventArgs e)
        {
            db.FillCombo(cboPayerForSpp, "tbl_user_payer", "payer_name", "payer_id", "status_id=1", "payer_id", false);
            db.FillCombo(cboPayerForFee, "tbl_user_payer", "payer_name", "payer_id", "status_id=1", "payer_id", false);
            
            db.FillCombo(cboPayTypeSPP, "tbl_pay_type", "pay_type_name", "pay_type_id", "status_id=1", "pay_type_id", false);
            db.FillCombo(cboPayTypeFee, "tbl_pay_type", "pay_type_name", "pay_type_id", "status_id=1", "pay_type_id", false);

            db.FillCombo(cboCurPaySPP, "tbl_currency", "cur_name", "cur_id", "cur_id > 1 And status_id=1", "", false);
            db.FillCombo(cboCurPayFee, "tbl_currency", "cur_name", "cur_id", "cur_id > 1 And status_id=1", "", false);

            buy_spp_currency_id = db.nLookup("buy_currency_id", "tbl_buy_spare_part_item", "buy_id=" + buy_transaction_id);
            buy_fee_currency_id = db.nLookup("transport_fee_cur_id", "tbl_buy_spare_part", "buy_id=" + buy_transaction_id);

            exc_bath_usd = db.NLookupDouble("bath_usd", "tbl_exchange_rate", "status_id=1");
            exc_kip_usd = db.NLookupDouble("kip_usd", "tbl_exchange_rate", "status_id=1");

            loadCalcPayment();
            loadPaymentHistory();

            cboCurPaySPP.SelectedValue = buy_spp_currency_id;
            cboCurPayFee.SelectedValue = buy_fee_currency_id;

            txtPayingSPP.Focus();
        }

        private void loadCalcPayment()
        {
            
            //txtPayingSPP.Enabled = true;
            //cboTotalBuy_payer.Enabled = true;
            //txtPayingFee.Enabled = true;
            //cboTotalFee_payer.Enabled = true;
            btnSave.Enabled = true;

            totalSPP = db.XSum("buy_price * buy_qty", "tbl_buy_spare_part_item", "buy_id=" + buy_transaction_id + " And status_id=1");
            totalFee = db.NLookupDecimal("transport_fee", "tbl_buy_spare_part", "buy_id=" + buy_transaction_id);

            totalBuyPaid = db.XSum("pay_amount_in_currency", "tbl_buy_spare_part_payment", "buy_id=" + buy_transaction_id + " And pay_item_id=1 And status_id=1");
            totalFeePaid = db.XSum("pay_amount_in_currency", "tbl_buy_spare_part_payment", "buy_id=" + buy_transaction_id + " And pay_item_id=2 And status_id=1");

            totalBuyBalance = totalSPP - totalBuyPaid;
            totalFeeBalance = totalFee - totalFeePaid;

            txtTotalSPP.Text = totalSPP.ToString(globalVariable.format_currency_usd);
            txtTransportFee.Text = totalFee.ToString(globalVariable.format_currency_usd);

            txtTotalBuy_paid.Text = totalBuyPaid.ToString(globalVariable.format_currency_usd);
            txtTotalBuy_balance.Text = totalBuyBalance.ToString(globalVariable.format_currency_usd);

            txtTotalFee_paid.Text = totalFeePaid.ToString(globalVariable.format_currency_usd);
            txtTotalFee_balance.Text = totalFeeBalance.ToString(globalVariable.format_currency_usd);

            if (totalBuyBalance <= 0 && totalFeeBalance <= 0)
            {
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            double paySPPAmount = db.ToNumber(txtPayingSPP.Text);
            double payFeeAmount = db.ToNumber(txtPayingFee.Text);
            double paySPPAmount_in_buy_cur = 0;
            double payFeeAmount_in_buy_cur = 0;
            double payAmountInUsd = 0;

            if (paySPPAmount == 0 && payFeeAmount == 0)
            {
                MessageBox.Show("ກະລຸນາປ້ອນຈຳນວນເງິນຊຳລະກ່ອນ.");
                txtPayingSPP.Focus();
                return;
            }

            int pay_cur_id = Convert.ToInt32(cboCurPaySPP.SelectedValue);
            if (buy_spp_currency_id == pay_cur_id)
            {
                paySPPAmount_in_buy_cur = paySPPAmount;
            }
            else
            {
                if (buy_spp_currency_id == 2 && pay_cur_id == 3)
                {
                    paySPPAmount_in_buy_cur = paySPPAmount * exc_bath_usd;
                }
                else if (buy_spp_currency_id == 3 && pay_cur_id == 2)
                {
                    paySPPAmount_in_buy_cur = paySPPAmount / exc_bath_usd;
                }
            }

            int pay_fee_cur_id = Convert.ToInt32(cboCurPayFee.SelectedValue);
            if (buy_fee_currency_id == pay_fee_cur_id)
            {
                payFeeAmount_in_buy_cur = payFeeAmount;
            }
            else
            {
                if (buy_fee_currency_id == 2 && pay_cur_id == 3)
                {
                    payFeeAmount_in_buy_cur = payFeeAmount * exc_bath_usd;
                }
                else if (buy_fee_currency_id == 3 && pay_cur_id == 2)
                {
                    payFeeAmount_in_buy_cur = payFeeAmount / exc_bath_usd;
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
                    string sql = @"
                    INSERT INTO [dbo].[tbl_buy_spare_part_payment] (
                        buy_id,
                        payer_id,
                        payer_name,
                        pay_date,
                        pay_item_id,
                        pay_item_name,
                        pay_amount,
                        pay_currency_id,
                        pay_amount_in_currency,
                        pay_type_id,
                        pay_type_name,
                        rate_kip2usd,
                        rate_bath2usd,
                        payAmountInUsd,
                        status_id,
                        created_date,
                        created_user
                    )
                    VALUES (
                        @buy_id,
                        @payer_id,
                        @payer_name,
                        @pay_date,
                        @pay_item_id,
                        @pay_item_name,
                        @pay_amount,
                        @pay_currency_id,
                        @pay_amount_in_currency,
                        @pay_type_id,
                        @pay_type_name,
                        @rate_kip2usd,
                        @rate_bath2usd,
                        @payAmountInUsd,
                        @status_id,
                        @created_date,
                        @created_user)";

                    conn.Open();

                    double exc_bath_usd = db.NLookupDouble("bath_usd", "tbl_exchange_rate", "status_id=1");
                    double exc_kip_usd = db.NLookupDouble("kip_usd", "tbl_exchange_rate", "status_id=1");

                    if (paySPPAmount > 0)
                    {
                        if (pay_cur_id != 3)
                        {
                            payAmountInUsd = db.C2USD(pay_cur_id, paySPPAmount);
                        }
                        else
                        {
                            payAmountInUsd = paySPPAmount;
                        }

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@buy_id", buy_transaction_id);
                        cmd.Parameters.AddWithValue("@payer_id", cboPayerForSpp.SelectedValue);
                        cmd.Parameters.AddWithValue("@payer_name", cboPayerForSpp.Text);
                        cmd.Parameters.AddWithValue("@pay_date", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@pay_item_id", 1);
                        cmd.Parameters.AddWithValue("@pay_item_name", "ຈ່າຍຄ່າອາໄຫຼ່");
                        cmd.Parameters.AddWithValue("@pay_amount", paySPPAmount);
                        cmd.Parameters.AddWithValue("@pay_currency_id", cboCurPaySPP.SelectedValue); // 1 = USD?
                        cmd.Parameters.AddWithValue("@pay_amount_in_currency", paySPPAmount_in_buy_cur);
                        cmd.Parameters.AddWithValue("@pay_type_id", cboPayTypeSPP.SelectedValue); // e.g., cash
                        cmd.Parameters.AddWithValue("@pay_type_name", cboPayTypeSPP.Text);
                        cmd.Parameters.AddWithValue("@rate_kip2usd", exc_kip_usd);
                        cmd.Parameters.AddWithValue("@rate_bath2usd", exc_bath_usd);
                        cmd.Parameters.AddWithValue("@payAmountInUsd", payAmountInUsd);
                        cmd.Parameters.AddWithValue("@status_id", 1);
                        cmd.Parameters.AddWithValue("@created_date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@created_user", globalVariable.g_user_name);
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }

                    payAmountInUsd = 0;

                    if (payFeeAmount > 0)
                    {
                        if (pay_fee_cur_id != 3)
                        {
                            payAmountInUsd = db.C2USD(pay_fee_cur_id, payFeeAmount);
                        }
                        else
                        {
                            payAmountInUsd = payFeeAmount;
                        }
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@buy_id", buy_transaction_id);
                        cmd.Parameters.AddWithValue("@payer_id", cboPayerForFee.SelectedValue);
                        cmd.Parameters.AddWithValue("@payer_name", cboPayerForFee.Text);
                        cmd.Parameters.AddWithValue("@pay_date", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@pay_item_id", 2);
                        cmd.Parameters.AddWithValue("@pay_item_name", "ຈ່າຍຄ່າຂົນສົ່ງ");
                        cmd.Parameters.AddWithValue("@pay_amount", payFeeAmount);
                        cmd.Parameters.AddWithValue("@pay_currency_id", cboCurPayFee.SelectedValue); // 1 = USD?
                        cmd.Parameters.AddWithValue("@pay_amount_in_currency", payFeeAmount_in_buy_cur);
                        cmd.Parameters.AddWithValue("@pay_type_id", cboPayTypeFee.SelectedValue); // e.g., cash
                        cmd.Parameters.AddWithValue("@pay_type_name", cboPayTypeFee.Text);
                        cmd.Parameters.AddWithValue("@rate_kip2usd", exc_kip_usd);
                        cmd.Parameters.AddWithValue("@rate_bath2usd", exc_bath_usd);
                        cmd.Parameters.AddWithValue("@payAmountInUsd", payAmountInUsd);
                        cmd.Parameters.AddWithValue("@status_id", 1);
                        cmd.Parameters.AddWithValue("@created_date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@created_user", globalVariable.g_user_name);
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("ບັນທຶກສຳເລັດແລ້ວ.");
                    txtPayingSPP.Text = "";
                    txtPayingFee.Text = "";
                    conn.Close();
                    loadCalcPayment();
                    loadPaymentHistory();
                    txtPayingSPP.Focus();
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
                string sql = "SELECT * FROM tbl_buy_spare_part_payment Where buy_id=" + buy_transaction_id + " And status_id=1 order by pay_id";
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
                        dgvData.Rows[rowIndex].Cells["col_pay_des"].Value = reader["pay_item_name"];
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
                        dgvData.Rows[rowIndex].Cells["col_payer"].Value = reader["payer_name"];
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

        private void txtPayingSPP_Leave(object sender, EventArgs e)
        {
            double c_amount = db.ToNumber(txtPayingSPP.Text);
            txtPayingSPP.Text = c_amount.ToString(globalVariable.format_currency_usd);
            //Decimal totalAmount = Convert.ToDecimal(txtTotalBuy.Text);
            calcPaySpp();
        }

        private void calcPaySpp()
        {
            double c_amount = db.ToNumber(txtPayingSPP.Text);
            int pay_cur_id = Convert.ToInt32(cboCurPaySPP.SelectedValue);
            Decimal totalPaid = 0;
            if (buy_spp_currency_id == pay_cur_id || pay_cur_id == 0)
            {
                totalPaid = Convert.ToDecimal(c_amount) + totalBuyPaid;
            }
            else
            {
                if (buy_spp_currency_id == 2 && pay_cur_id == 3)
                {
                    c_amount = c_amount * exc_bath_usd;
                }
                else if (buy_spp_currency_id == 3 && pay_cur_id == 2)
                {
                    c_amount = c_amount / exc_bath_usd;
                }
                totalPaid = Convert.ToDecimal(c_amount) + totalBuyPaid;
            }
            
            Decimal totalBalance = totalSPP - totalPaid;

            txtTotalBuy_paid.Text = totalPaid.ToString(globalVariable.format_currency_usd);
            txtTotalBuy_balance.Text = totalBalance.ToString(globalVariable.format_currency_usd);
        }

        private void txtPayingFee_Leave(object sender, EventArgs e)
        {
            double c_amount = db.ToNumber(txtPayingFee.Text);
            txtPayingFee.Text = c_amount.ToString(globalVariable.format_currency_usd);
            //Decimal totalAmount = Convert.ToDecimal(txtTotalFee.Text);
            calcPayFee();
        }

        private void calcPayFee()
        {
            double c_amount = db.ToNumber(txtPayingFee.Text);
            //Decimal totalAmount = Convert.ToDecimal(txtTotalFee.Text);

            int pay_cur_id = Convert.ToInt32(cboCurPayFee.SelectedValue);
            Decimal totalPaid = totalFeePaid;
            if (buy_fee_currency_id == pay_cur_id || pay_cur_id == 0)
            {
                totalPaid = totalPaid + Convert.ToDecimal(c_amount);
            }
            else
            {
                if (buy_fee_currency_id == 2 && pay_cur_id == 3)
                {
                    c_amount = c_amount * exc_bath_usd;
                }
                else if (buy_fee_currency_id == 3 && pay_cur_id == 2)
                {
                    c_amount = c_amount / exc_bath_usd;
                }
                totalPaid = totalPaid + Convert.ToDecimal(c_amount);
            }

            Decimal totalBalance = totalFee - totalPaid;

            txtTotalFee_paid.Text = totalPaid.ToString(globalVariable.format_currency_usd);
            txtTotalFee_balance.Text = totalBalance.ToString(globalVariable.format_currency_usd);
        }

        private void cboCurSPP_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcPaySpp();
        }

        private void cboCurFee_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcPayFee();
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
                        string exc_qry = "update tbl_buy_spare_part_payment set status_id=2 where pay_id=" + del_item_id;
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
