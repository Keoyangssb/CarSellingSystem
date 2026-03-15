using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarSellingSystem.SaleCar
{
    public partial class frmSaleCarPayment : Form
    {
        public frmSaleCarPayment()
        {
            InitializeComponent();
        }

        private myClass db = new myClass();

        public long sale_transaction_id = 0;

        decimal totalCar = 0;
        decimal totalPaid = 0;
        decimal totalBalance = 0;

        decimal exc_bath_usd = 0;
        decimal exc_kip_usd = 0;

        private void frmSaleCarPayment_Load(object sender, EventArgs e)
        {
            db.FillCombo(cboPayer, "tbl_sell_car_payer", "payer_name", "payer_id", "", "payer_id", false);
            db.FillCombo(cboSellPayType, "tbl_sale_pay_type", "sale_pay_type_name", "sale_pay_type_id", "", "sale_pay_type_id", false);
            db.FillCombo(cboPayType, "tbl_pay_type", "pay_type_name", "pay_type_id", "status_id=1", "pay_type_id", false);
            //db.FillCombo(cboCurrency, "tbl_currency", "cur_name", "cur_id", "status_id=1", "cur_id", false);
            cboPayer.SelectedIndex = -1;
            cboSellPayType.SelectedIndex = -1;
            cboPayType.SelectedIndex = -1;
            //cboCurrency.SelectedValue = 3;

            exc_bath_usd = db.NLookupDecimal("bath_usd", "tbl_exchange_rate", "status_id=1");
            exc_kip_usd = db.NLookupDecimal("kip_usd", "tbl_exchange_rate", "status_id=1");

            //checkPay();

            loadPayment();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboPayer.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກຜຸ້ຈ່າຍກ່ອນ.");
                cboPayer.Focus();
                return;
            }
            if (cboSellPayType.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກຈ່າຍກ່ອນ.");
                cboSellPayType.Focus();
                return;
            }
            if (cboPayType.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກຮູບແບບຊຳລະກ່ອນ.");
                cboPayType.Focus();
                return;
            }

            decimal paying_usd = db.ToNumberDecimal(txtPayingUSD.Text);
            decimal paying_kip = db.ToNumberDecimal(txtPayingKip.Text);
            decimal paying_bath = db.ToNumberDecimal(txtPayingBath.Text);

            decimal paying_kip_in_usd = paying_kip / exc_kip_usd;
            decimal paying_bath_in_usd = paying_bath / exc_bath_usd;

            decimal totalPaying_in_usd = paying_usd + paying_kip_in_usd + paying_bath_in_usd;

            decimal total_pay_in_usd = totalPaid + totalPaying_in_usd;
            decimal total_balance = totalCar - total_pay_in_usd;

            if (totalBalance > 0)
            {
                if (totalPaying_in_usd == 0)
                {
                    MessageBox.Show("ກະລຸນາຈ່າຍເງິນກ່ອນ.");
                    txtPayingUSD.Focus();
                    return;
                }

                int pay_full_id = Convert.ToInt32(cboSellPayType.SelectedValue);
                if (pay_full_id == 1)
                {
                    if (total_balance > 0)
                    {
                        MessageBox.Show("ກະລຸນາຈ່າຍເງິນໃຫ້ຄົບກ່ອນ.");
                        txtPayingUSD.Focus();
                        return;
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
                    string query = @"
                    INSERT INTO [dbo].[tbl_sell_car_payment] (
                        [pay_date], [sell_id], [payer_id], [sell_pay_type_id], [pay_type_id],
                        [pay_amount_usd], [pay_amount_kip], [pay_amount_bath],
                        [total_pay_in_usd], [remark], [rate_kip2usd], [rate_bath2usd],
                        [status_id], [created_date], [created_user]
                    )
                    VALUES (
                        @pay_date, @sell_id, @payer_id, @sell_pay_type_id, @pay_type_id,
                        @pay_amount_usd, @pay_amount_kip, @pay_amount_bath,
                        @total_pay_in_usd, @remark, @rate_kip2usd, @rate_bath2usd,
                        @status_id, @created_date, @created_user);";

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))

                        {
                            cmd.Parameters.AddWithValue("@pay_date", dt_paid.Value);
                            cmd.Parameters.AddWithValue("@sell_id", sale_transaction_id); 
                            cmd.Parameters.AddWithValue("@payer_id", cboPayer.SelectedValue);
                            cmd.Parameters.AddWithValue("@sell_pay_type_id", cboSellPayType.SelectedValue);
                            cmd.Parameters.AddWithValue("@pay_type_id", cboPayType.SelectedValue);
                            cmd.Parameters.AddWithValue("@pay_amount_usd", paying_usd);
                            cmd.Parameters.AddWithValue("@pay_amount_kip", paying_kip);
                            cmd.Parameters.AddWithValue("@pay_amount_bath", paying_bath);
                            cmd.Parameters.AddWithValue("@total_pay_in_usd", totalPaying_in_usd);
                            cmd.Parameters.AddWithValue("@remark", txtRemark.Text == "" ? "" : txtRemark.Text);
                            cmd.Parameters.AddWithValue("@rate_kip2usd", exc_kip_usd);
                            cmd.Parameters.AddWithValue("@rate_bath2usd", exc_bath_usd);
                            cmd.Parameters.AddWithValue("@status_id", 1);
                            cmd.Parameters.AddWithValue("@created_date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@created_user", "admin");

                            conn.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("ບັນທຶກສຳເລັດແລ້ວ.");
                            conn.Close();
                            loadPayment();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ບັນທຶກມີຂໍ້ຜິດຜາດ. >> " + ex.Message.ToString());
                        conn.Close();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cboPayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //checkPay();
        }

        private void cboFull_SelectedIndexChanged(object sender, EventArgs e)
        {
            //checkPay();
        }

        private void cboPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //checkPay();
        }

        private void checkPay()
        {
            txtPayingUSD.Text = "";
            if (cboPayer.SelectedIndex != -1 && cboSellPayType.SelectedIndex != -1 && cboPayType.SelectedIndex != -1)
            {
                txtPayingUSD.Enabled = true;
            }
            else
            {
                txtPayingUSD.Enabled = false;
            }
            if (cboSellPayType.SelectedIndex != -1)
            {
                if (Convert.ToInt32(cboSellPayType.SelectedValue) == 1)
                {
                    txtPayingUSD.Text = lblBalance.Text;
                }
            }
        }

        private void loadPayment()
        {
            totalCar = db.NLookupDecimal("sale_price", "v_sell_car", "sale_id=" + sale_transaction_id);
            totalPaid = db.XSum("total_pay_in_usd", "tbl_sell_car_payment", "sell_id=" + sale_transaction_id + " And status_id=1");
            totalBalance = totalCar - totalPaid;
            lblPrice.Text = totalCar.ToString(globalVariable.format_currency_usd);
            lblPaid.Text = totalPaid.ToString(globalVariable.format_currency_usd);
            lblBalance.Text = totalBalance.ToString(globalVariable.format_currency_usd) + " $";
            decimal balanceKip = totalBalance * exc_kip_usd;
            decimal balanceBath = totalBalance * exc_bath_usd;
            lblBalanceKip.Text = balanceKip.ToString(globalVariable.format_currency_lak) + " K";
            lblBalanceBath.Text = balanceBath.ToString(globalVariable.format_currency_usd) + " ฿";

            dgvData.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM v_sell_car_payment Where sale_id=" + sale_transaction_id + " ";
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
                        dgvData.Rows[rowIndex].Cells["col_payer"].Value = reader["payer_name"];
                        dgvData.Rows[rowIndex].Cells["col_select_pay"].Value = reader["sale_pay_type_name"];
                        dgvData.Rows[rowIndex].Cells["col_pay_type"].Value = reader["pay_type_name"];

                        dgvData.Rows[rowIndex].Cells["col_pay_usd"].Value = Convert.ToDecimal(reader["pay_amount_usd"]).ToString(globalVariable.format_currency_usd);
                        dgvData.Rows[rowIndex].Cells["col_pay_kip"].Value = Convert.ToDecimal(reader["pay_amount_kip"]).ToString(globalVariable.format_currency_lak);
                        dgvData.Rows[rowIndex].Cells["col_pay_bath"].Value = Convert.ToDecimal(reader["pay_amount_bath"]).ToString(globalVariable.format_currency_usd);

                        dgvData.Rows[rowIndex].Cells["col_remark"].Value = reader["remark"];

                        dgvData.Rows[rowIndex].Cells["col_rate_kip_usd"].Value = Convert.ToDecimal(reader["rate_kip2usd"]).ToString(globalVariable.format_currency_usd);
                        dgvData.Rows[rowIndex].Cells["col_rate_bath_usd"].Value = Convert.ToDecimal(reader["rate_bath2usd"]).ToString(globalVariable.format_currency_usd);

                        dgvData.Rows[rowIndex].Cells["col_user"].Value = reader["created_user"];
                        dgvData.Rows[rowIndex].Cells["col_item_del"].Value = "ລົບອອກ";
                    }
                }
                conn.Close();
                set_item_rowNo();
            }

        }

        private void set_item_rowNo()
        {
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                DataGridViewRow row = dgvData.Rows[i];
                row.Cells["col_item_no"].Value = i + 1;
            }
        }

        private void calcPayment()
        {
            decimal paying_usd = db.ToNumberDecimal(txtPayingUSD.Text);
            decimal paying_kip = db.ToNumberDecimal(txtPayingKip.Text);
            decimal paying_bath = db.ToNumberDecimal(txtPayingBath.Text);

            paying_kip = paying_kip / exc_kip_usd;
            paying_bath = paying_bath / exc_bath_usd;

            decimal totalPay = totalPaid + paying_usd + paying_kip + paying_bath;
            decimal total_balance = totalCar - totalPay;

            lblPaid.Text = totalPay.ToString(globalVariable.format_currency_usd);
            lblBalance.Text = total_balance.ToString(globalVariable.format_currency_usd) + " $";

            decimal balanceKip = total_balance * exc_kip_usd;
            decimal balanceBath = total_balance * exc_bath_usd;
            lblBalanceKip.Text = balanceKip.ToString(globalVariable.format_currency_lak) + " K";
            lblBalanceBath.Text = balanceBath.ToString(globalVariable.format_currency_usd) + " ฿";

        }

        private void txtPayingUSD_TextChanged(object sender, EventArgs e)
        {
            calcPayment();
        }

        private void txtPayingKip_TextChanged(object sender, EventArgs e)
        {
            calcPayment();
        }

        private void txtPayingBath_TextChanged(object sender, EventArgs e)
        {
            calcPayment();
        }

        private void txtPayingUSD_Leave(object sender, EventArgs e)
        {
            double c_amount = db.ToNumber(txtPayingUSD.Text);
            txtPayingUSD.Text = c_amount.ToString(globalVariable.format_currency_usd);
        }

        private void txtPayingKip_Leave(object sender, EventArgs e)
        {
            double c_amount = db.ToNumber(txtPayingKip.Text);
            txtPayingKip.Text = c_amount.ToString(globalVariable.format_currency_lak);
        }

        private void txtPayingBath_Leave(object sender, EventArgs e)
        {
            double c_amount = db.ToNumber(txtPayingBath.Text);
            txtPayingBath.Text = c_amount.ToString(globalVariable.format_currency_usd);
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
                        string exc_qry = "update tbl_sell_car_payment set status_id=2,modify_date=GETDATE(),modify_user='" + globalVariable.g_user_name + "' where pay_id=" + del_item_id;
                        int exc = db.sqlExecute(exc_qry);
                    }
                    loadPayment();
                }
            }
        }

    }
}
