using CarSellingSystem.BuyCar;
using CarSellingSystem.Cars;
using CarSellingSystem.Customer;
using CarSellingSystem.ExchangeRate;
using CarSellingSystem.Expense;
using CarSellingSystem.ReportForms;
using CarSellingSystem.SaleCar;
using CarSellingSystem.SparePart;
using CarSellingSystem.Stocks;
using CarSellingSystem.Users;
using DevComponents.DotNetBar;
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
    public partial class frmMain : Form
    {
        public static frmMain Instance { get; private set; }
        public frmMain()
        {
            InitializeComponent();
            Instance = this;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            getExc();
        }

        private void getExc()
        {
            lbl_status_user.Text = "Login by user: " + globalVariable.g_user_name;
            lbl_status_exchange.Text = "";
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT TOP(1) * FROM dbo.tbl_exchange_rate where status_id=1 ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        //ອັດຕາແລກປ່ຽນ: ກີບ-ບາດ: 650 | ກີບ-ໂດລາ: 21,600 | ບາດ-ໂດລາ: 32 
                        lbl_status_exchange.Text = "ອັດຕາແລກປ່ຽນ: ກີບ-ບາດ: " + Convert.ToDecimal(reader["kip_bath"]).ToString(globalVariable.format_currency_usd) +
                            " | ກີບ-ໂດລາ: " + Convert.ToDecimal(reader["kip_usd"]).ToString(globalVariable.format_currency_usd) +
                            " | ບາດ-ໂດລາ: " + Convert.ToDecimal(reader["bath_usd"]).ToString(globalVariable.format_currency_usd);
                    }
                }
                reader.Close();
                conn.Close();
            }
        }

        private void btnBuyCar_Click(object sender, EventArgs e)
        {
            frmBuyCar frm = new frmBuyCar();
            frm.buy_transaction_id = 0;
            frm.ShowDialog();
        }

        private void btnBuyCarList_Click(object sender, EventArgs e)
        {
            if (!CheckForm("frmBuyCarList"))
            {
                TabItem newTab = tcl.CreateTab("ປະຫວັດຊື້ລົດ");
                newTab.Name = "frmBuyCarList";

                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                panel.Dock = DockStyle.Fill;

                tcl.Refresh();
                tcl.SelectedTab = newTab;

                frmBuyCarList frm = new frmBuyCarList();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.TopLevel = false;

                panel.Controls.Add(frm);
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }



        private bool CheckForm(string tabName)
        {
            if (this.tcl.Tabs.Count > 0)
            {
                for (int i = 0; i < tcl.Tabs.Count; i++)
                {
                    string nName = tcl.Tabs[i].Name;
                    if (nName == tabName)
                    {
                        tcl.SelectedTabIndex = i;
                        return true;
                    }
                }
            }
            return false;
        }

        private void btnSaleCar_Click(object sender, EventArgs e)
        {
            frmSaleCar frm = new frmSaleCar();
            frm.sell_transaction_id = 0;
            frm.ShowDialog();
        }

        private void btnSaleCarHistory_Click(object sender, EventArgs e)
        {
            if (!CheckForm("frmSaleCarList"))
            {
                TabItem newTab = tcl.CreateTab("ປະຫວັດຂາຍລົດ");
                newTab.Name = "frmSaleCarList";

                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                panel.Dock = DockStyle.Fill;

                tcl.Refresh();
                tcl.SelectedTab = newTab;

                frmSaleCarList frm = new frmSaleCarList();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.TopLevel = false;

                panel.Controls.Add(frm);
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void btnBuySparePartList_Click(object sender, EventArgs e)
        {
            if (!CheckForm("frmBuySparePartList"))
            {
                TabItem newTab = tcl.CreateTab("ຊື້ອາໄຫຼ່ລົດ");
                newTab.Name = "frmBuySparePartList";

                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                panel.Dock = DockStyle.Fill;

                tcl.Refresh();
                tcl.SelectedTab = newTab;

                frmBuySparePartList frm = new frmBuySparePartList();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.TopLevel = false;

                panel.Controls.Add(frm);
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void btnSaleSparePartList_Click(object sender, EventArgs e)
        {
            if (!CheckForm("frmSaleSparePartList"))
            {
                TabItem newTab = tcl.CreateTab("ຂາຍອາໄຫຼ່ລົດ");
                newTab.Name = "frmSaleSparePartList";

                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                panel.Dock = DockStyle.Fill;

                tcl.Refresh();
                tcl.SelectedTab = newTab;

                frmSaleSparePartList frm = new frmSaleSparePartList();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.TopLevel = false;

                panel.Controls.Add(frm);
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void btnExpenseList_Click(object sender, EventArgs e)
        {
            if (!CheckForm("frmExpenseList"))
            {
                TabItem newTab = tcl.CreateTab("ບັນທຶກລາຍຈ່າຍລວມ");
                newTab.Name = "frmExpenseList";

                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                panel.Dock = DockStyle.Fill;

                tcl.Refresh();
                tcl.SelectedTab = newTab;

                frmExpenseList frm = new frmExpenseList();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.TopLevel = false;

                panel.Controls.Add(frm);
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if (!CheckForm("frmCustomer"))
            {
                TabItem newTab = tcl.CreateTab("ຂໍ້ມູນລູກຄ້າ");
                newTab.Name = "frmCustomer";

                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                panel.Dock = DockStyle.Fill;

                tcl.Refresh();
                tcl.SelectedTab = newTab;

                frmCustomer frm = new frmCustomer();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.TopLevel = false;

                panel.Controls.Add(frm);
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void btnSparePart_Click(object sender, EventArgs e)
        {
            if (!CheckForm("frmSparePart"))
            {
                TabItem newTab = tcl.CreateTab("ຂໍ້ມູນອາໄຫຼ່");
                newTab.Name = "frmSparePart";

                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                panel.Dock = DockStyle.Fill;

                tcl.Refresh();
                tcl.SelectedTab = newTab;

                frmSparePart frm = new frmSparePart();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.TopLevel = false;

                panel.Controls.Add(frm);
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void frmExchangeRate_Click(object sender, EventArgs e)
        {
            frmExchangeRate frm = new frmExchangeRate();
            frm.ShowDialog();
            //show rate
            getExc();
        }


        private void btnCarInfo_Click(object sender, EventArgs e)
        {
            frmCarList frm = new frmCarList();
            frm.ShowDialog();
        }

        private void frmRoleAccess_Click(object sender, EventArgs e)
        {
            frmRoleAccess frm = new frmRoleAccess();
            frm.ShowDialog();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (!CheckForm("frmUser"))
            {
                TabItem newTab = tcl.CreateTab("ຂໍ້ມູນ User");
                newTab.Name = "frmUser";

                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                panel.Dock = DockStyle.Fill;

                tcl.Refresh();
                tcl.SelectedTab = newTab;

                frmUser frm = new frmUser();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.TopLevel = false;

                panel.Controls.Add(frm);
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void btnCheckCarBalance_Click(object sender, EventArgs e)
        {
            if (!CheckForm("frmCheckCarBalance"))
            {
                TabItem newTab = tcl.CreateTab("ເບິ່ງຍອດເຫຼືອລົດ");
                newTab.Name = "frmCheckCarBalance";

                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                panel.Dock = DockStyle.Fill;

                tcl.Refresh();
                tcl.SelectedTab = newTab;

                frmCheckCarBalance frm = new frmCheckCarBalance();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.TopLevel = false;

                panel.Controls.Add(frm);
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void btnCheckSPPBalance_Click(object sender, EventArgs e)
        {
            if (!CheckForm("bfrmCheckSPPBalance"))
            {
                TabItem newTab = tcl.CreateTab("ເບິ່ງຍອດເຫຼືອລົດອາໄຫຼ່");
                newTab.Name = "bfrmCheckSPPBalance";

                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                panel.Dock = DockStyle.Fill;

                tcl.Refresh();
                tcl.SelectedTab = newTab;

                bfrmCheckSPPBalance frm = new bfrmCheckSPPBalance();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.TopLevel = false;

                panel.Controls.Add(frm);
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void btnReportBuyCar_Click(object sender, EventArgs e)
        {
            if (!CheckForm("frmReportBuyCar"))
            {
                TabItem newTab = tcl.CreateTab("ລາຍງານຊຶ້ລົດເຂົ້າ");
                newTab.Name = "frmReportBuyCar";

                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                panel.Dock = DockStyle.Fill;

                tcl.Refresh();
                tcl.SelectedTab = newTab;

                frmReportBuyCar frm = new frmReportBuyCar();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.TopLevel = false;

                panel.Controls.Add(frm);
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void btnReportSaleCar_Click(object sender, EventArgs e)
        {
            if (!CheckForm("frmReportSaleCar"))
            {
                TabItem newTab = tcl.CreateTab("ລາຍງານຂາຍລົດ");
                newTab.Name = "frmReportSaleCar";

                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                panel.Dock = DockStyle.Fill;

                tcl.Refresh();
                tcl.SelectedTab = newTab;

                frmReportSaleCar frm = new frmReportSaleCar();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.TopLevel = false;

                panel.Controls.Add(frm);
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void btnReportBuySparePart_Click(object sender, EventArgs e)
        {
            if (!CheckForm("frmReportBuySparePart"))
            {
                TabItem newTab = tcl.CreateTab("ລາຍງານຊຶ້ອາໄຫຼ່");
                newTab.Name = "frmReportBuySparePart";

                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                panel.Dock = DockStyle.Fill;

                tcl.Refresh();
                tcl.SelectedTab = newTab;

                frmReportBuySparePart frm = new frmReportBuySparePart();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.TopLevel = false;

                panel.Controls.Add(frm);
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void btnSaleSSPReport_Click(object sender, EventArgs e)
        {
            if (!CheckForm("frmReportSaleSparePart"))
            {
                TabItem newTab = tcl.CreateTab("ລາຍງານຂາຍອາໄຫຼ່");
                newTab.Name = "frmReportSaleSparePart";

                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                panel.Dock = DockStyle.Fill;

                tcl.Refresh();
                tcl.SelectedTab = newTab;

                frmReportSaleSparePart frm = new frmReportSaleSparePart();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.TopLevel = false;

                panel.Controls.Add(frm);
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void btnExpenseReport_Click(object sender, EventArgs e)
        {
            if (!CheckForm("frmExpenseReport"))
            {
                TabItem newTab = tcl.CreateTab("ລາຍງານບັນຊີລາຍຈ່າຍລວມ");
                newTab.Name = "frmExpenseReport";

                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                panel.Dock = DockStyle.Fill;

                tcl.Refresh();
                tcl.SelectedTab = newTab;

                frmExpenseReport frm = new frmExpenseReport();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.TopLevel = false;

                panel.Controls.Add(frm);
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void btnProfitLoseReport_Click(object sender, EventArgs e)
        {
            if (!CheckForm("frmProfitLoseReport"))
            {
                TabItem newTab = tcl.CreateTab("ລາຍງານກຳໄລ");
                newTab.Name = "frmProfitLoseReport";

                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                panel.Dock = DockStyle.Fill;

                tcl.Refresh();
                tcl.SelectedTab = newTab;

                frmProfitLoseReport2 frm = new frmProfitLoseReport2();
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.TopLevel = false;

                panel.Controls.Add(frm);
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void btnExpenseCode_Click(object sender, EventArgs e)
        {
            frmAddEditExpense frm = new frmAddEditExpense();
            frm.ShowDialog();
        }


        

    }
}
