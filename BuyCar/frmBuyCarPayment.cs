using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarSellingSystem.BuyCar
{
    public partial class frmBuyCarPayment : Form
    {
        public frmBuyCarPayment()
        {
            InitializeComponent();
        }

        public long buy_transaction_id = 0;

        private myClass db = new myClass();

        Decimal totalBuyPaid = 0;
        Decimal totalFeePaid = 0;
        Decimal totalKotaPaid = 0;
        Decimal totalTaxPaid = 0;

        Decimal totalBuyBalance = 0;
        Decimal totalFeeBalance = 0;
        Decimal totalKotaBalance = 0;
        Decimal totalTaxBalance = 0;

        bool is_first_load = true;

        private void frmBuyCarPayment_Load(object sender, EventArgs e)
        {
            is_first_load = true;

            db.FillCombo(cboTotalBuy_payer, "tbl_user_payer", "payer_name", "payer_id", "status_id=1", "payer_id", false);
            db.FillCombo(cboTotalFee_payer, "tbl_user_payer", "payer_name", "payer_id", "status_id=1", "payer_id", false);
            db.FillCombo(cboTotalKota_payer, "tbl_user_payer", "payer_name", "payer_id", "status_id=1", "payer_id", false);
            db.FillCombo(cboTotalTax_payer, "tbl_user_payer", "payer_name", "payer_id", "status_id=1", "payer_id", false);

            db.FillCombo(cboTotalBuy_payType, "tbl_pay_type", "pay_type_name", "pay_type_id", "status_id=1", "pay_type_id", false);
            db.FillCombo(cboTotalFee_payType, "tbl_pay_type", "pay_type_name", "pay_type_id", "status_id=1", "pay_type_id", false);
            db.FillCombo(cboTotalKota_payType, "tbl_pay_type", "pay_type_name", "pay_type_id", "status_id=1", "pay_type_id", false);
            db.FillCombo(cboTotalTax_payType, "tbl_pay_type", "pay_type_name", "pay_type_id", "status_id=1", "pay_type_id", false);

            db.FillCombo(cboCurrency_pay_car, "tbl_currency", "cur_name", "cur_id", "status_id=1", "", false);
            db.FillCombo(cboCurrency_pay_fee, "tbl_currency", "cur_name", "cur_id", "status_id=1", "", false);
            db.FillCombo(cboCurrency_pay_kota, "tbl_currency", "cur_name", "cur_id", "status_id=1", "", false);
            db.FillCombo(cboCurrency_pay_tax, "tbl_currency", "cur_name", "cur_id", "status_id=1", "", false);

            cboCurrency_pay_car.SelectedValue = 3;
            cboCurrency_pay_fee.SelectedValue = 3;
            cboCurrency_pay_kota.SelectedValue = 3;
            cboCurrency_pay_tax.SelectedValue = 3;

            getCalcPayment();
            getPaymentHistory();
            is_first_load = false;
            txtTotalBuy_paying.Focus();
        }

        private void getCalcPayment()
        {
            txtTotalBuy_paying.Enabled = true;
            cboTotalBuy_payer.Enabled = true;
            txtTotalFee_paying.Enabled = true;
            cboTotalFee_payer.Enabled = true;
            txtTotalKota_paying.Enabled = true;
            cboTotalKota_payer.Enabled = true;
            btnSave.Enabled = true;

            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM v_buy_car Where buy_id=" + buy_transaction_id;
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        txtTotalBuy.Text = Convert.ToDecimal(reader["buy_price"]).ToString(globalVariable.format_currency_usd);
                        txtTotalFee.Text = Convert.ToDecimal(reader["fee_price"]).ToString(globalVariable.format_currency_usd);
                        txtTotalKota.Text = Convert.ToDecimal(reader["kota_price"]).ToString(globalVariable.format_currency_usd);
                        txtTotalTax.Text = Convert.ToDecimal(reader["tax_price"]).ToString(globalVariable.format_currency_usd);

                        totalBuyPaid = db.XSum("payAmountInUsd", "tbl_buy_cars_payment", "buy_id=" + buy_transaction_id + " And pay_item_id=1 And status_id=1");
                        totalFeePaid = db.XSum("payAmountInUsd", "tbl_buy_cars_payment", "buy_id=" + buy_transaction_id + " And pay_item_id=2 And status_id=1");
                        totalKotaPaid = db.XSum("payAmountInUsd", "tbl_buy_cars_payment", "buy_id=" + buy_transaction_id + " And pay_item_id=3 And status_id=1");
                        totalTaxPaid = db.XSum("payAmountInUsd", "tbl_buy_cars_payment", "buy_id=" + buy_transaction_id + " And pay_item_id=4 And status_id=1");

                        totalBuyBalance = Convert.ToDecimal(reader["buy_price"]) - totalBuyPaid;
                        totalFeeBalance = Convert.ToDecimal(reader["fee_price"]) - totalFeePaid;
                        totalKotaBalance = Convert.ToDecimal(reader["kota_price"]) - totalKotaPaid;
                        totalTaxBalance = Convert.ToDecimal(reader["tax_price"]) - totalTaxPaid;

                        txtTotalBuy_paid.Text = totalBuyPaid.ToString(globalVariable.format_currency_usd);
                        txtTotalBuy_balance.Text = totalBuyBalance.ToString(globalVariable.format_currency_usd);

                        txtTotalFee_paid.Text = totalFeePaid.ToString(globalVariable.format_currency_usd);
                        txtTotalFee_balance.Text = totalFeeBalance.ToString(globalVariable.format_currency_usd);

                        txtTotalKota_paid.Text = totalKotaPaid.ToString(globalVariable.format_currency_usd);
                        txtTotalKota_balance.Text = totalKotaBalance.ToString(globalVariable.format_currency_usd);

                        txtTotalTax_paid.Text = totalTaxPaid.ToString(globalVariable.format_currency_usd);
                        txtTotalTax_balance.Text = totalTaxBalance.ToString(globalVariable.format_currency_usd);

                        if (Convert.ToDecimal(reader["buy_price"]) == 0 || totalBuyBalance == 0)
                        {
                            txtTotalBuy_paying.Enabled = false;
                            cboTotalBuy_payer.Enabled = false;
                        }
                        if (Convert.ToDecimal(reader["fee_price"]) == 0 || totalFeeBalance == 0)
                        {
                            txtTotalFee_paying.Enabled = false;
                            cboTotalFee_payer.Enabled = false;
                        }
                        if (Convert.ToDecimal(reader["kota_price"]) == 0 || totalKotaBalance == 0)
                        {
                            txtTotalKota_paying.Enabled = false;
                            cboTotalKota_payer.Enabled = false;
                        }

                        if (totalBuyBalance == 0 && totalFeeBalance == 0 && totalKotaBalance == 0 && totalTaxBalance == 0)
                        {
                            btnSave.Enabled = false;
                        }


                    }
                }
                conn.Close();
            }
        }

        private void getPaymentHistory()
        {
            dgvData.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM tbl_buy_cars_payment Where buy_id=" + buy_transaction_id + " And status_id=1 order by pay_id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int rowIndex = dgvData.Rows.Add();
                        dgvData.Rows[rowIndex].Cells["col_pay_id"].Value = reader["pay_id"];
                        dgvData.Rows[rowIndex].Cells["col_pay_date"].Value = Convert.ToDateTime(reader["pay_date"]).ToString(globalVariable.format_date) + " " + Convert.ToDateTime(reader["created_date"]).ToString(globalVariable.format_time);
                        dgvData.Rows[rowIndex].Cells["col_pay_des"].Value = reader["pay_item_name"];
                        dgvData.Rows[rowIndex].Cells["col_pay_amount"].Value = Convert.ToDecimal(reader["pay_amount"]).ToString(globalVariable.format_currency_usd);
                        dgvData.Rows[rowIndex].Cells["col_pay_type_name"].Value = reader["pay_type_name"];
                        dgvData.Rows[rowIndex].Cells["col_payer"].Value = reader["payer_name"];
                        dgvData.Rows[rowIndex].Cells["col_user"].Value = reader["created_user"];
                        int paid_currency = Convert.ToInt32(reader["payCurrencyId"]);
                        if (paid_currency == 1)
                        {
                            dgvData.Rows[rowIndex].Cells["col_currency"].Value = "ກີບ";
                        }
                        else if (paid_currency == 2)
                        {
                            dgvData.Rows[rowIndex].Cells["col_currency"].Value = "ບາດ";
                        }
                        else if (paid_currency == 3)
                        {
                            dgvData.Rows[rowIndex].Cells["col_currency"].Value = "ໂດລາ";
                        }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            double payCarAmount = db.ToNumber(txtTotalBuy_paying.Text);
            double payFeeAmount = db.ToNumber(txtTotalFee_paying.Text);
            double payKotaAmount = db.ToNumber(txtTotalKota_paying.Text);
            double payTaxAmount = db.ToNumber(txtTotalTax_paying.Text);

            if (payCarAmount == 0 && payFeeAmount == 0 && payKotaAmount == 0 && payTaxAmount == 0)
            {
                MessageBox.Show("ກະລຸນາປ້ອນຈຳນວນເງິນຊຳລະກ່ອນ.");
                txtTotalBuy_paying.Focus();
                return;
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
                    INSERT INTO [dbo].[tbl_buy_cars_payment]
                    (
                        [buy_id], [payer_id], [payer_name], [pay_date], 
                        [pay_item_id], [pay_item_name], [pay_amount], [pay_type_id],[pay_type_name],
                        [rate_kip2usd], [rate_bath2usd],[payCurrencyId],[payAmountInUsd], [status_id], 
                        [created_date], [created_user]
                    )
                    VALUES
                    (
                    @buy_id, @payer_id, @payer_name, @pay_date, 
                    @pay_item_id, @pay_item_name, @pay_amount, @pay_type_id,@pay_type_name,
                    @rate_kip2usd, @rate_bath2usd,@payCurrencyId,@payAmountInUsd, @status_id, 
                    @created_date, @created_user)";

                    conn.Open();

                    double exc_bath_usd = db.NLookupDouble("bath_usd", "tbl_exchange_rate", "status_id=1");
                    double exc_kip_usd = db.NLookupDouble("kip_usd", "tbl_exchange_rate", "status_id=1");
                    double paid_amount_in_usd = 0;
                    int pay_currency_id = 3;

                    if (payCarAmount > 0)
                    {
                        paid_amount_in_usd = payCarAmount;
                        pay_currency_id = Convert.ToInt32(cboCurrency_pay_car.SelectedValue);
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@buy_id", buy_transaction_id);
                        cmd.Parameters.AddWithValue("@payer_id", cboTotalBuy_payer.SelectedValue);
                        cmd.Parameters.AddWithValue("@payer_name", cboTotalBuy_payer.Text);
                        cmd.Parameters.AddWithValue("@pay_date", dt_paid.Value);
                        cmd.Parameters.AddWithValue("@pay_item_id", 1);
                        cmd.Parameters.AddWithValue("@pay_item_name", "ຈ່າຍຕົ້ນທຶນຊື້ລົດ");
                        cmd.Parameters.AddWithValue("@pay_amount", payCarAmount);
                        cmd.Parameters.AddWithValue("@pay_type_id", cboTotalBuy_payType.SelectedValue);
                        cmd.Parameters.AddWithValue("@pay_type_name", cboTotalBuy_payType.Text);
                        cmd.Parameters.AddWithValue("@rate_kip2usd", exc_kip_usd);
                        cmd.Parameters.AddWithValue("@rate_bath2usd", exc_bath_usd);
                        cmd.Parameters.AddWithValue("@payCurrencyId", pay_currency_id);
                        cmd.Parameters.AddWithValue("@payAmountInUsd", paid_amount_in_usd);
                        cmd.Parameters.AddWithValue("@status_id", 1);
                        cmd.Parameters.AddWithValue("@created_date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@created_user", globalVariable.g_user_name);
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }

                    paid_amount_in_usd = 0;

                    if (payFeeAmount > 0)
                    {
                        pay_currency_id = Convert.ToInt32(cboCurrency_pay_fee.SelectedValue);
                        if (pay_currency_id != 3)
                        {
                            paid_amount_in_usd = db.C2USD(pay_currency_id, payFeeAmount);
                        }else{
                            paid_amount_in_usd = payFeeAmount;
                        }

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@buy_id", buy_transaction_id);
                        cmd.Parameters.AddWithValue("@payer_id", cboTotalFee_payer.SelectedValue);
                        cmd.Parameters.AddWithValue("@payer_name", cboTotalFee_payer.Text);
                        cmd.Parameters.AddWithValue("@pay_date", dt_paid.Value);
                        cmd.Parameters.AddWithValue("@pay_item_id", 2);
                        cmd.Parameters.AddWithValue("@pay_item_name", "ຈ່າຍຄ່າທຳນຽນ");
                        cmd.Parameters.AddWithValue("@pay_amount", payFeeAmount);
                        cmd.Parameters.AddWithValue("@pay_type_id", cboTotalFee_payType.SelectedValue);
                        cmd.Parameters.AddWithValue("@pay_type_name", cboTotalFee_payType.Text);
                        cmd.Parameters.AddWithValue("@rate_kip2usd", exc_kip_usd);
                        cmd.Parameters.AddWithValue("@rate_bath2usd", exc_bath_usd);
                        cmd.Parameters.AddWithValue("@payCurrencyId", pay_currency_id);
                        cmd.Parameters.AddWithValue("@payAmountInUsd", paid_amount_in_usd);
                        cmd.Parameters.AddWithValue("@status_id", 1);
                        cmd.Parameters.AddWithValue("@created_date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@created_user", globalVariable.g_user_name);
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }

                    paid_amount_in_usd = 0;

                    if (payKotaAmount > 0)
                    {
                        pay_currency_id = Convert.ToInt32(cboCurrency_pay_kota.SelectedValue);
                        if (pay_currency_id != 3)
                        {
                            paid_amount_in_usd = db.C2USD(pay_currency_id, payKotaAmount);
                        }
                        else
                        {
                            paid_amount_in_usd = payKotaAmount;
                        }
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@buy_id", buy_transaction_id);
                        cmd.Parameters.AddWithValue("@payer_id", cboTotalKota_payer.SelectedValue);
                        cmd.Parameters.AddWithValue("@payer_name", cboTotalKota_payer.Text);
                        cmd.Parameters.AddWithValue("@pay_date", dt_paid.Value);
                        cmd.Parameters.AddWithValue("@pay_item_id", 3);
                        cmd.Parameters.AddWithValue("@pay_item_name", "ຈ່າຍຄ່າໂຄຕ່າ");
                        cmd.Parameters.AddWithValue("@pay_amount", payKotaAmount);
                        cmd.Parameters.AddWithValue("@pay_type_id", cboTotalKota_payType.SelectedValue);
                        cmd.Parameters.AddWithValue("@pay_type_name", cboTotalKota_payType.Text);
                        cmd.Parameters.AddWithValue("@rate_kip2usd", exc_kip_usd);
                        cmd.Parameters.AddWithValue("@rate_bath2usd", exc_bath_usd);
                        cmd.Parameters.AddWithValue("@payCurrencyId", pay_currency_id);
                        cmd.Parameters.AddWithValue("@payAmountInUsd", paid_amount_in_usd);
                        cmd.Parameters.AddWithValue("@status_id", 1);
                        cmd.Parameters.AddWithValue("@created_date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@created_user", globalVariable.g_user_name);
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }

                    paid_amount_in_usd = 0;

                    if (payTaxAmount > 0)
                    {
                        pay_currency_id = Convert.ToInt32(cboCurrency_pay_tax.SelectedValue);
                        if (pay_currency_id != 3)
                        {
                            paid_amount_in_usd = db.C2USD(pay_currency_id, payTaxAmount);
                        }
                        else
                        {
                            paid_amount_in_usd = payTaxAmount;
                        }
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@buy_id", buy_transaction_id);
                        cmd.Parameters.AddWithValue("@payer_id", cboTotalTax_payer.SelectedValue);
                        cmd.Parameters.AddWithValue("@payer_name", cboTotalTax_payer.Text);
                        cmd.Parameters.AddWithValue("@pay_date", dt_paid.Value);
                        cmd.Parameters.AddWithValue("@pay_item_id", 4);
                        cmd.Parameters.AddWithValue("@pay_item_name", "ຈ່າຍຄ່າພາສີ");
                        cmd.Parameters.AddWithValue("@pay_amount", payTaxAmount);
                        cmd.Parameters.AddWithValue("@pay_type_id", cboTotalTax_payType.SelectedValue);
                        cmd.Parameters.AddWithValue("@pay_type_name", cboTotalTax_payType.Text);
                        cmd.Parameters.AddWithValue("@rate_kip2usd", exc_kip_usd);
                        cmd.Parameters.AddWithValue("@rate_bath2usd", exc_bath_usd);
                        cmd.Parameters.AddWithValue("@payCurrencyId", pay_currency_id);
                        cmd.Parameters.AddWithValue("@payAmountInUsd", paid_amount_in_usd);
                        cmd.Parameters.AddWithValue("@status_id", 1);
                        cmd.Parameters.AddWithValue("@created_date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@created_user", globalVariable.g_user_name);
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("ບັນທຶກສຳເລັດແລ້ວ.");
                    txtTotalBuy_paying.Text = "";
                    txtTotalFee_paying.Text = "";
                    txtTotalKota_paying.Text = "";
                    txtTotalTax_paying.Text = "";
                    conn.Close();
                    getCalcPayment();
                    getPaymentHistory();
                    txtTotalBuy_paying.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ບັນທຶກມີຂໍ້ຜິດຜາດ. >> " + ex.Message.ToString());
                    conn.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtTotalBuy_paying_Leave(object sender, EventArgs e)
        {
            double c_amount = db.ToNumber(txtTotalBuy_paying.Text);
            txtTotalBuy_paying.Text = c_amount.ToString(globalVariable.format_currency_usd);
            Decimal totalAmount = Convert.ToDecimal(txtTotalBuy.Text);
            Decimal totalPaid = Convert.ToDecimal(c_amount) + totalBuyPaid;
            Decimal totalBalance = totalAmount - totalPaid;

            txtTotalBuy_paid.Text = totalPaid.ToString(globalVariable.format_currency_usd);
            txtTotalBuy_balance.Text = totalBalance.ToString(globalVariable.format_currency_usd);
        }

        private void txtTotalFee_paying_Leave(object sender, EventArgs e)
        {
            double c_amount = db.ToNumber(txtTotalFee_paying.Text);
            txtTotalFee_paying.Text = c_amount.ToString(globalVariable.format_currency_usd);
            Decimal totalAmount = Convert.ToDecimal(txtTotalFee.Text);
            int pay_cur_id = Convert.ToInt32(cboCurrency_pay_fee.SelectedValue);
            if (pay_cur_id != 3)
            {
                c_amount = db.C2USD(pay_cur_id, c_amount);
            }

            Decimal totalPaid = Convert.ToDecimal(c_amount) + totalFeePaid;
            Decimal totalBalance = totalAmount - totalPaid;

            txtTotalFee_paid.Text = totalPaid.ToString(globalVariable.format_currency_usd);
            txtTotalFee_balance.Text = totalBalance.ToString(globalVariable.format_currency_usd);
        }

        private void txtTotalKota_paying_Leave(object sender, EventArgs e)
        {
            double c_amount = db.ToNumber(txtTotalKota_paying.Text);
            txtTotalKota_paying.Text = c_amount.ToString(globalVariable.format_currency_usd);
            Decimal totalAmount = Convert.ToDecimal(txtTotalKota.Text);

            int pay_cur_id = Convert.ToInt32(cboCurrency_pay_kota.SelectedValue);
            if (pay_cur_id != 3)
            {
                c_amount = db.C2USD(pay_cur_id, c_amount);
            }

            Decimal totalPaid = Convert.ToDecimal(c_amount) + totalKotaPaid;
            Decimal totalBalance = totalAmount - totalPaid;

            txtTotalKota_paid.Text = totalPaid.ToString(globalVariable.format_currency_usd);
            txtTotalKota_balance.Text = totalBalance.ToString(globalVariable.format_currency_usd);
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
                        string exc_qry = "update tbl_buy_cars_payment set status_id=2 where pay_id=" + del_item_id;
                        int exc = db.sqlExecute(exc_qry);
                    }
                    //dgvData.Rows.RemoveAt(e.RowIndex);
                    //set_free_item_rowNo();
                    getCalcPayment();
                    getPaymentHistory();
                }
            }
        }

        private void cboCurrency_pay_fee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (is_first_load)
            {
                return;
            }
            double c_amount = db.ToNumber(txtTotalFee_paying.Text);
            txtTotalFee_paying.Text = c_amount.ToString(globalVariable.format_currency_usd);
            Decimal totalAmount = Convert.ToDecimal(txtTotalFee.Text);
            int pay_cur_id = Convert.ToInt32(cboCurrency_pay_fee.SelectedValue);
            if (pay_cur_id != 3)
            {
                c_amount = db.C2USD(pay_cur_id, c_amount);
            }

            Decimal totalPaid = Convert.ToDecimal(c_amount) + totalFeePaid;
            Decimal totalBalance = totalAmount - totalPaid;

            txtTotalFee_paid.Text = totalPaid.ToString(globalVariable.format_currency_usd);
            txtTotalFee_balance.Text = totalBalance.ToString(globalVariable.format_currency_usd);
        }

        private void cboCurrency_pay_kota_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (is_first_load)
            {
                return;
            }
            double c_amount = db.ToNumber(txtTotalKota_paying.Text);
            txtTotalKota_paying.Text = c_amount.ToString(globalVariable.format_currency_usd);
            Decimal totalAmount = Convert.ToDecimal(txtTotalKota.Text);

            int pay_cur_id = Convert.ToInt32(cboCurrency_pay_kota.SelectedValue);
            if (pay_cur_id != 3)
            {
                c_amount = db.C2USD(pay_cur_id, c_amount);
            }

            Decimal totalPaid = Convert.ToDecimal(c_amount) + totalKotaPaid;
            Decimal totalBalance = totalAmount - totalPaid;

            txtTotalKota_paid.Text = totalPaid.ToString(globalVariable.format_currency_usd);
            txtTotalKota_balance.Text = totalBalance.ToString(globalVariable.format_currency_usd);
        }

        private void txtTotalTax_paying_Leave(object sender, EventArgs e)
        {
            double c_amount = db.ToNumber(txtTotalTax_paying.Text);
            txtTotalTax_paying.Text = c_amount.ToString(globalVariable.format_currency_usd);
            Decimal totalAmount = Convert.ToDecimal(txtTotalTax.Text);

            int pay_cur_id = Convert.ToInt32(cboCurrency_pay_tax.SelectedValue);
            if (pay_cur_id != 3)
            {
                c_amount = db.C2USD(pay_cur_id, c_amount);
            }

            Decimal totalPaid = Convert.ToDecimal(c_amount) + totalTaxPaid;
            Decimal totalBalance = totalAmount - totalPaid;

            txtTotalTax_paid.Text = totalPaid.ToString(globalVariable.format_currency_usd);
            txtTotalTax_balance.Text = totalBalance.ToString(globalVariable.format_currency_usd);
        }



    }
}
