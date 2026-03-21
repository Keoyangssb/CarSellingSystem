namespace CarSellingSystem
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl_status_user = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_status_exchange = new System.Windows.Forms.ToolStripStatusLabel();
            this.ExpandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.expExchangeTreasury = new DevComponents.DotNetBar.ExpandablePanel();
            this.btnBuyCarList = new DevComponents.DotNetBar.ButtonX();
            this.btnBuyCar = new DevComponents.DotNetBar.ButtonX();
            this.expTransaction = new DevComponents.DotNetBar.ExpandablePanel();
            this.btnSaleCarHistory = new DevComponents.DotNetBar.ButtonX();
            this.btnSaleCar = new DevComponents.DotNetBar.ButtonX();
            this.expSummaryTreasury = new DevComponents.DotNetBar.ExpandablePanel();
            this.btnSaleSparePartList = new DevComponents.DotNetBar.ButtonX();
            this.btnBuySparePartList = new DevComponents.DotNetBar.ButtonX();
            this.expandablePanel3 = new DevComponents.DotNetBar.ExpandablePanel();
            this.btnCheckSPPBalance = new DevComponents.DotNetBar.ButtonX();
            this.btnCheckCarBalance = new DevComponents.DotNetBar.ButtonX();
            this.expandablePanel2 = new DevComponents.DotNetBar.ExpandablePanel();
            this.btnExpenseList = new DevComponents.DotNetBar.ButtonX();
            this.expSetting = new DevComponents.DotNetBar.ExpandablePanel();
            this.btnExpenseCode = new DevComponents.DotNetBar.ButtonX();
            this.btnRoleAccess = new DevComponents.DotNetBar.ButtonX();
            this.btnUser = new DevComponents.DotNetBar.ButtonX();
            this.btnSparePart = new DevComponents.DotNetBar.ButtonX();
            this.btnCustomer = new DevComponents.DotNetBar.ButtonX();
            this.btnCarInfo = new DevComponents.DotNetBar.ButtonX();
            this.frmExchangeRate = new DevComponents.DotNetBar.ButtonX();
            this.expReport = new DevComponents.DotNetBar.ExpandablePanel();
            this.btnProfitLoseReport = new DevComponents.DotNetBar.ButtonX();
            this.btnExpenseReport = new DevComponents.DotNetBar.ButtonX();
            this.btnSaleSSPReport = new DevComponents.DotNetBar.ButtonX();
            this.btnReportBuySparePart = new DevComponents.DotNetBar.ButtonX();
            this.btnReportSaleCar = new DevComponents.DotNetBar.ButtonX();
            this.btnReportBuyCar = new DevComponents.DotNetBar.ButtonX();
            this.btnReportTotalCashTransfer = new DevComponents.DotNetBar.ButtonX();
            this.tcl = new DevComponents.DotNetBar.TabControl();
            this.ExpandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.statusStrip1.SuspendLayout();
            this.ExpandablePanel1.SuspendLayout();
            this.FlowLayoutPanel1.SuspendLayout();
            this.expExchangeTreasury.SuspendLayout();
            this.expTransaction.SuspendLayout();
            this.expSummaryTreasury.SuspendLayout();
            this.expandablePanel3.SuspendLayout();
            this.expandablePanel2.SuspendLayout();
            this.expSetting.SuspendLayout();
            this.expReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcl)).BeginInit();
            this.tcl.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_status_user,
            this.toolStripStatusLabel1,
            this.lbl_status_exchange});
            this.statusStrip1.Location = new System.Drawing.Point(0, 595);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1555, 29);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl_status_user
            // 
            this.lbl_status_user.Name = "lbl_status_user";
            this.lbl_status_user.Size = new System.Drawing.Size(129, 24);
            this.lbl_status_user.Text = "Log in by: Admin";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(14, 24);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // lbl_status_exchange
            // 
            this.lbl_status_exchange.Name = "lbl_status_exchange";
            this.lbl_status_exchange.Size = new System.Drawing.Size(437, 24);
            this.lbl_status_exchange.Text = "ອັດຕາແລກປ່ຽນ: ກີບ-ບາດ: 650 | ກີບ-ໂດລາ: 21,600 | ບາດ-ໂດລາ: 32 ";
            // 
            // ExpandablePanel1
            // 
            this.ExpandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.ExpandablePanel1.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            this.ExpandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ExpandablePanel1.Controls.Add(this.FlowLayoutPanel1);
            this.ExpandablePanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ExpandablePanel1.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpandablePanel1.Location = new System.Drawing.Point(0, 0);
            this.ExpandablePanel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ExpandablePanel1.Name = "ExpandablePanel1";
            this.ExpandablePanel1.Size = new System.Drawing.Size(207, 595);
            this.ExpandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.ExpandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ExpandablePanel1.Style.BackColor2.Color = System.Drawing.Color.DodgerBlue;
            this.ExpandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.ExpandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.ExpandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.ExpandablePanel1.Style.GradientAngle = 90;
            this.ExpandablePanel1.TabIndex = 7;
            this.ExpandablePanel1.TitleHeight = 44;
            this.ExpandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.ExpandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ExpandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.ExpandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.ExpandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.ExpandablePanel1.TitleStyle.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.ExpandablePanel1.TitleStyle.GradientAngle = 90;
            this.ExpandablePanel1.TitleText = "ເມນູ";
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.AutoScroll = true;
            this.FlowLayoutPanel1.Controls.Add(this.expExchangeTreasury);
            this.FlowLayoutPanel1.Controls.Add(this.expTransaction);
            this.FlowLayoutPanel1.Controls.Add(this.expSummaryTreasury);
            this.FlowLayoutPanel1.Controls.Add(this.expandablePanel3);
            this.FlowLayoutPanel1.Controls.Add(this.expandablePanel2);
            this.FlowLayoutPanel1.Controls.Add(this.expSetting);
            this.FlowLayoutPanel1.Controls.Add(this.expReport);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(0, 44);
            this.FlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(207, 551);
            this.FlowLayoutPanel1.TabIndex = 1;
            // 
            // expExchangeTreasury
            // 
            this.expExchangeTreasury.CanvasColor = System.Drawing.SystemColors.Control;
            this.expExchangeTreasury.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expExchangeTreasury.Controls.Add(this.btnBuyCarList);
            this.expExchangeTreasury.Controls.Add(this.btnBuyCar);
            this.expExchangeTreasury.Cursor = System.Windows.Forms.Cursors.Hand;
            this.expExchangeTreasury.Expanded = false;
            this.expExchangeTreasury.ExpandedBounds = new System.Drawing.Rectangle(4, 2, 199, 108);
            this.expExchangeTreasury.ExpandOnTitleClick = true;
            this.expExchangeTreasury.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expExchangeTreasury.Location = new System.Drawing.Point(4, 2);
            this.expExchangeTreasury.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.expExchangeTreasury.Name = "expExchangeTreasury";
            this.expExchangeTreasury.Size = new System.Drawing.Size(199, 44);
            this.expExchangeTreasury.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expExchangeTreasury.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expExchangeTreasury.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expExchangeTreasury.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expExchangeTreasury.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expExchangeTreasury.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expExchangeTreasury.Style.GradientAngle = 90;
            this.expExchangeTreasury.TabIndex = 0;
            this.expExchangeTreasury.TitleHeight = 44;
            this.expExchangeTreasury.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expExchangeTreasury.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expExchangeTreasury.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expExchangeTreasury.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expExchangeTreasury.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expExchangeTreasury.TitleStyle.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Bold);
            this.expExchangeTreasury.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expExchangeTreasury.TitleStyle.GradientAngle = 90;
            this.expExchangeTreasury.TitleText = "ຊື້ລົດ";
            // 
            // btnBuyCarList
            // 
            this.btnBuyCarList.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuyCarList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuyCarList.Location = new System.Drawing.Point(4, 52);
            this.btnBuyCarList.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnBuyCarList.Name = "btnBuyCarList";
            this.btnBuyCarList.Size = new System.Drawing.Size(190, 46);
            this.btnBuyCarList.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnBuyCarList.TabIndex = 8;
            this.btnBuyCarList.Text = "ຊື້ລົດ";
            this.btnBuyCarList.Click += new System.EventHandler(this.btnBuyCarList_Click);
            // 
            // btnBuyCar
            // 
            this.btnBuyCar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuyCar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuyCar.Location = new System.Drawing.Point(0, 153);
            this.btnBuyCar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnBuyCar.Name = "btnBuyCar";
            this.btnBuyCar.Size = new System.Drawing.Size(190, 46);
            this.btnBuyCar.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnBuyCar.TabIndex = 7;
            this.btnBuyCar.Text = "ບັນທຶກຊື້ລົດໃໝ່";
            this.btnBuyCar.Visible = false;
            this.btnBuyCar.Click += new System.EventHandler(this.btnBuyCar_Click);
            // 
            // expTransaction
            // 
            this.expTransaction.CanvasColor = System.Drawing.SystemColors.Control;
            this.expTransaction.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expTransaction.Controls.Add(this.btnSaleCarHistory);
            this.expTransaction.Controls.Add(this.btnSaleCar);
            this.expTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.expTransaction.Expanded = false;
            this.expTransaction.ExpandedBounds = new System.Drawing.Rectangle(4, 50, 199, 108);
            this.expTransaction.ExpandOnTitleClick = true;
            this.expTransaction.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expTransaction.Location = new System.Drawing.Point(4, 50);
            this.expTransaction.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.expTransaction.Name = "expTransaction";
            this.expTransaction.Size = new System.Drawing.Size(199, 44);
            this.expTransaction.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expTransaction.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expTransaction.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expTransaction.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expTransaction.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expTransaction.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expTransaction.Style.GradientAngle = 90;
            this.expTransaction.TabIndex = 1;
            this.expTransaction.TitleHeight = 44;
            this.expTransaction.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expTransaction.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expTransaction.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expTransaction.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expTransaction.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expTransaction.TitleStyle.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.expTransaction.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expTransaction.TitleStyle.GradientAngle = 90;
            this.expTransaction.TitleText = "ຂາຍລົດ";
            // 
            // btnSaleCarHistory
            // 
            this.btnSaleCarHistory.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaleCarHistory.Location = new System.Drawing.Point(4, 51);
            this.btnSaleCarHistory.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSaleCarHistory.Name = "btnSaleCarHistory";
            this.btnSaleCarHistory.Size = new System.Drawing.Size(190, 46);
            this.btnSaleCarHistory.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnSaleCarHistory.TabIndex = 9;
            this.btnSaleCarHistory.Text = "ຂາຍລົດ";
            this.btnSaleCarHistory.Click += new System.EventHandler(this.btnSaleCarHistory_Click);
            // 
            // btnSaleCar
            // 
            this.btnSaleCar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaleCar.Location = new System.Drawing.Point(4, 176);
            this.btnSaleCar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSaleCar.Name = "btnSaleCar";
            this.btnSaleCar.Size = new System.Drawing.Size(190, 46);
            this.btnSaleCar.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnSaleCar.TabIndex = 8;
            this.btnSaleCar.Text = "ບັນທຶກຂາຍລົດໃໝ່";
            this.btnSaleCar.Click += new System.EventHandler(this.btnSaleCar_Click);
            // 
            // expSummaryTreasury
            // 
            this.expSummaryTreasury.CanvasColor = System.Drawing.SystemColors.Control;
            this.expSummaryTreasury.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expSummaryTreasury.Controls.Add(this.btnSaleSparePartList);
            this.expSummaryTreasury.Controls.Add(this.btnBuySparePartList);
            this.expSummaryTreasury.Cursor = System.Windows.Forms.Cursors.Hand;
            this.expSummaryTreasury.Expanded = false;
            this.expSummaryTreasury.ExpandedBounds = new System.Drawing.Rectangle(4, 98, 199, 157);
            this.expSummaryTreasury.ExpandOnTitleClick = true;
            this.expSummaryTreasury.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.expSummaryTreasury.Location = new System.Drawing.Point(4, 98);
            this.expSummaryTreasury.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.expSummaryTreasury.Name = "expSummaryTreasury";
            this.expSummaryTreasury.Size = new System.Drawing.Size(199, 44);
            this.expSummaryTreasury.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expSummaryTreasury.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expSummaryTreasury.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expSummaryTreasury.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expSummaryTreasury.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expSummaryTreasury.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expSummaryTreasury.Style.GradientAngle = 90;
            this.expSummaryTreasury.TabIndex = 2;
            this.expSummaryTreasury.TitleHeight = 44;
            this.expSummaryTreasury.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expSummaryTreasury.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expSummaryTreasury.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expSummaryTreasury.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expSummaryTreasury.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expSummaryTreasury.TitleStyle.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.expSummaryTreasury.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expSummaryTreasury.TitleStyle.GradientAngle = 90;
            this.expSummaryTreasury.TitleText = "ອາໄຫຼ່ລົດ";
            // 
            // btnSaleSparePartList
            // 
            this.btnSaleSparePartList.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaleSparePartList.Location = new System.Drawing.Point(4, 102);
            this.btnSaleSparePartList.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSaleSparePartList.Name = "btnSaleSparePartList";
            this.btnSaleSparePartList.Size = new System.Drawing.Size(190, 46);
            this.btnSaleSparePartList.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnSaleSparePartList.TabIndex = 7;
            this.btnSaleSparePartList.Text = "ຂາຍອາໄຫຼ່ລົດ";
            this.btnSaleSparePartList.Click += new System.EventHandler(this.btnSaleSparePartList_Click);
            // 
            // btnBuySparePartList
            // 
            this.btnBuySparePartList.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuySparePartList.Location = new System.Drawing.Point(4, 50);
            this.btnBuySparePartList.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnBuySparePartList.Name = "btnBuySparePartList";
            this.btnBuySparePartList.Size = new System.Drawing.Size(190, 46);
            this.btnBuySparePartList.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnBuySparePartList.TabIndex = 6;
            this.btnBuySparePartList.Text = "ຊື້ອາໄຫຼ່ລົດ";
            this.btnBuySparePartList.Click += new System.EventHandler(this.btnBuySparePartList_Click);
            // 
            // expandablePanel3
            // 
            this.expandablePanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel3.Controls.Add(this.btnCheckSPPBalance);
            this.expandablePanel3.Controls.Add(this.btnCheckCarBalance);
            this.expandablePanel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.expandablePanel3.Expanded = false;
            this.expandablePanel3.ExpandedBounds = new System.Drawing.Rectangle(4, 146, 199, 157);
            this.expandablePanel3.ExpandOnTitleClick = true;
            this.expandablePanel3.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.expandablePanel3.Location = new System.Drawing.Point(4, 146);
            this.expandablePanel3.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.expandablePanel3.Name = "expandablePanel3";
            this.expandablePanel3.Size = new System.Drawing.Size(199, 44);
            this.expandablePanel3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel3.Style.GradientAngle = 90;
            this.expandablePanel3.TabIndex = 9;
            this.expandablePanel3.TitleHeight = 44;
            this.expandablePanel3.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel3.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel3.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel3.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel3.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel3.TitleStyle.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.expandablePanel3.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel3.TitleStyle.GradientAngle = 90;
            this.expandablePanel3.TitleText = "ສາງລົດ ແລະ ອາໄຫຼ່";
            // 
            // btnCheckSPPBalance
            // 
            this.btnCheckSPPBalance.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCheckSPPBalance.Location = new System.Drawing.Point(4, 102);
            this.btnCheckSPPBalance.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnCheckSPPBalance.Name = "btnCheckSPPBalance";
            this.btnCheckSPPBalance.Size = new System.Drawing.Size(190, 46);
            this.btnCheckSPPBalance.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnCheckSPPBalance.TabIndex = 7;
            this.btnCheckSPPBalance.Text = "ເບິ່ງຍອດເຫຼືອລົດອາໄຫຼ່";
            this.btnCheckSPPBalance.Click += new System.EventHandler(this.btnCheckSPPBalance_Click);
            // 
            // btnCheckCarBalance
            // 
            this.btnCheckCarBalance.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCheckCarBalance.Location = new System.Drawing.Point(4, 50);
            this.btnCheckCarBalance.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnCheckCarBalance.Name = "btnCheckCarBalance";
            this.btnCheckCarBalance.Size = new System.Drawing.Size(190, 46);
            this.btnCheckCarBalance.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnCheckCarBalance.TabIndex = 6;
            this.btnCheckCarBalance.Text = "ເບິ່ງຍອດເຫຼືອລົດ";
            this.btnCheckCarBalance.Click += new System.EventHandler(this.btnCheckCarBalance_Click);
            // 
            // expandablePanel2
            // 
            this.expandablePanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel2.Controls.Add(this.btnExpenseList);
            this.expandablePanel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.expandablePanel2.Expanded = false;
            this.expandablePanel2.ExpandedBounds = new System.Drawing.Rectangle(4, 194, 199, 105);
            this.expandablePanel2.ExpandOnTitleClick = true;
            this.expandablePanel2.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.expandablePanel2.Location = new System.Drawing.Point(4, 194);
            this.expandablePanel2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.expandablePanel2.Name = "expandablePanel2";
            this.expandablePanel2.Size = new System.Drawing.Size(199, 44);
            this.expandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel2.Style.GradientAngle = 90;
            this.expandablePanel2.TabIndex = 8;
            this.expandablePanel2.TitleHeight = 44;
            this.expandablePanel2.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel2.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel2.TitleStyle.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.expandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel2.TitleStyle.GradientAngle = 90;
            this.expandablePanel2.TitleText = "ລາຍຈ່າຍລວມ";
            // 
            // btnExpenseList
            // 
            this.btnExpenseList.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExpenseList.Location = new System.Drawing.Point(4, 50);
            this.btnExpenseList.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnExpenseList.Name = "btnExpenseList";
            this.btnExpenseList.Size = new System.Drawing.Size(190, 46);
            this.btnExpenseList.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnExpenseList.TabIndex = 6;
            this.btnExpenseList.Text = "ບັນທຶກລາຍຈ່າຍລວມ";
            this.btnExpenseList.Click += new System.EventHandler(this.btnExpenseList_Click);
            // 
            // expSetting
            // 
            this.expSetting.CanvasColor = System.Drawing.SystemColors.Control;
            this.expSetting.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expSetting.Controls.Add(this.btnExpenseCode);
            this.expSetting.Controls.Add(this.btnRoleAccess);
            this.expSetting.Controls.Add(this.btnUser);
            this.expSetting.Controls.Add(this.btnSparePart);
            this.expSetting.Controls.Add(this.btnCustomer);
            this.expSetting.Controls.Add(this.btnCarInfo);
            this.expSetting.Controls.Add(this.frmExchangeRate);
            this.expSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.expSetting.Expanded = false;
            this.expSetting.ExpandedBounds = new System.Drawing.Rectangle(4, 77, 199, 407);
            this.expSetting.ExpandOnTitleClick = true;
            this.expSetting.Font = new System.Drawing.Font("Saysettha OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expSetting.Location = new System.Drawing.Point(4, 242);
            this.expSetting.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.expSetting.Name = "expSetting";
            this.expSetting.Size = new System.Drawing.Size(199, 44);
            this.expSetting.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expSetting.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expSetting.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expSetting.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expSetting.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expSetting.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expSetting.Style.GradientAngle = 90;
            this.expSetting.TabIndex = 7;
            this.expSetting.TitleHeight = 44;
            this.expSetting.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expSetting.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expSetting.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expSetting.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expSetting.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expSetting.TitleStyle.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.expSetting.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expSetting.TitleStyle.GradientAngle = 90;
            this.expSetting.TitleText = "ຕັ້ງຄ່າຂໍ້ມູນຫຼັກ";
            // 
            // btnExpenseCode
            // 
            this.btnExpenseCode.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExpenseCode.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnExpenseCode.Location = new System.Drawing.Point(4, 254);
            this.btnExpenseCode.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnExpenseCode.Name = "btnExpenseCode";
            this.btnExpenseCode.Size = new System.Drawing.Size(188, 46);
            this.btnExpenseCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnExpenseCode.TabIndex = 18;
            this.btnExpenseCode.Text = "ຂໍ້ມູນລາຍຈ່າຍລວມ";
            this.btnExpenseCode.Click += new System.EventHandler(this.btnExpenseCode_Click);
            // 
            // btnRoleAccess
            // 
            this.btnRoleAccess.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRoleAccess.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnRoleAccess.Location = new System.Drawing.Point(4, 354);
            this.btnRoleAccess.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnRoleAccess.Name = "btnRoleAccess";
            this.btnRoleAccess.Size = new System.Drawing.Size(188, 46);
            this.btnRoleAccess.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnRoleAccess.TabIndex = 17;
            this.btnRoleAccess.Text = "ກຳນົດສິດທິ User";
            this.btnRoleAccess.Click += new System.EventHandler(this.frmRoleAccess_Click);
            // 
            // btnUser
            // 
            this.btnUser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUser.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnUser.Location = new System.Drawing.Point(4, 304);
            this.btnUser.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(188, 46);
            this.btnUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnUser.TabIndex = 15;
            this.btnUser.Text = "ຂໍ້ມູນ User";
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnSparePart
            // 
            this.btnSparePart.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSparePart.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnSparePart.Location = new System.Drawing.Point(4, 204);
            this.btnSparePart.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSparePart.Name = "btnSparePart";
            this.btnSparePart.Size = new System.Drawing.Size(188, 46);
            this.btnSparePart.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnSparePart.TabIndex = 14;
            this.btnSparePart.Text = "ຂໍ້ມູນອາໄຫຼ່";
            this.btnSparePart.Click += new System.EventHandler(this.btnSparePart_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCustomer.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnCustomer.Location = new System.Drawing.Point(4, 152);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(188, 46);
            this.btnCustomer.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnCustomer.TabIndex = 13;
            this.btnCustomer.Text = "ຂໍ້ມູນລູກຄ້າ";
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnCarInfo
            // 
            this.btnCarInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCarInfo.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnCarInfo.Location = new System.Drawing.Point(4, 100);
            this.btnCarInfo.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnCarInfo.Name = "btnCarInfo";
            this.btnCarInfo.Size = new System.Drawing.Size(188, 46);
            this.btnCarInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnCarInfo.TabIndex = 12;
            this.btnCarInfo.Text = "ຂໍ້ມູນລົດ";
            this.btnCarInfo.Click += new System.EventHandler(this.btnCarInfo_Click);
            // 
            // frmExchangeRate
            // 
            this.frmExchangeRate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.frmExchangeRate.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.frmExchangeRate.Location = new System.Drawing.Point(4, 48);
            this.frmExchangeRate.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.frmExchangeRate.Name = "frmExchangeRate";
            this.frmExchangeRate.Size = new System.Drawing.Size(190, 46);
            this.frmExchangeRate.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.frmExchangeRate.TabIndex = 11;
            this.frmExchangeRate.Text = "ອັດຕາແລກປ່ຽນ";
            this.frmExchangeRate.Click += new System.EventHandler(this.frmExchangeRate_Click);
            // 
            // expReport
            // 
            this.expReport.CanvasColor = System.Drawing.SystemColors.Control;
            this.expReport.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expReport.Controls.Add(this.btnProfitLoseReport);
            this.expReport.Controls.Add(this.btnExpenseReport);
            this.expReport.Controls.Add(this.btnSaleSSPReport);
            this.expReport.Controls.Add(this.btnReportBuySparePart);
            this.expReport.Controls.Add(this.btnReportSaleCar);
            this.expReport.Controls.Add(this.btnReportBuyCar);
            this.expReport.Controls.Add(this.btnReportTotalCashTransfer);
            this.expReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.expReport.Expanded = false;
            this.expReport.ExpandedBounds = new System.Drawing.Rectangle(4, 169, 199, 363);
            this.expReport.ExpandOnTitleClick = true;
            this.expReport.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.expReport.Location = new System.Drawing.Point(4, 290);
            this.expReport.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.expReport.Name = "expReport";
            this.expReport.Size = new System.Drawing.Size(199, 44);
            this.expReport.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expReport.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expReport.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expReport.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expReport.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expReport.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expReport.Style.GradientAngle = 90;
            this.expReport.TabIndex = 5;
            this.expReport.TitleHeight = 44;
            this.expReport.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expReport.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expReport.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expReport.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expReport.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expReport.TitleStyle.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.expReport.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expReport.TitleStyle.GradientAngle = 90;
            this.expReport.TitleText = "ລາຍງານ";
            // 
            // btnProfitLoseReport
            // 
            this.btnProfitLoseReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnProfitLoseReport.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnProfitLoseReport.Location = new System.Drawing.Point(4, 309);
            this.btnProfitLoseReport.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnProfitLoseReport.Name = "btnProfitLoseReport";
            this.btnProfitLoseReport.Size = new System.Drawing.Size(190, 46);
            this.btnProfitLoseReport.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnProfitLoseReport.TabIndex = 16;
            this.btnProfitLoseReport.Text = "ລາຍງານກຳໄລ";
            this.btnProfitLoseReport.Click += new System.EventHandler(this.btnProfitLoseReport_Click);
            // 
            // btnExpenseReport
            // 
            this.btnExpenseReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExpenseReport.Font = new System.Drawing.Font("Phetsarath OT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnExpenseReport.Location = new System.Drawing.Point(4, 257);
            this.btnExpenseReport.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnExpenseReport.Name = "btnExpenseReport";
            this.btnExpenseReport.Size = new System.Drawing.Size(190, 46);
            this.btnExpenseReport.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnExpenseReport.TabIndex = 15;
            this.btnExpenseReport.Text = "ລາຍງານບັນຊີລາຍຈ່າຍລວມ";
            this.btnExpenseReport.Click += new System.EventHandler(this.btnExpenseReport_Click);
            // 
            // btnSaleSSPReport
            // 
            this.btnSaleSSPReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaleSSPReport.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnSaleSSPReport.Location = new System.Drawing.Point(4, 206);
            this.btnSaleSSPReport.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSaleSSPReport.Name = "btnSaleSSPReport";
            this.btnSaleSSPReport.Size = new System.Drawing.Size(190, 46);
            this.btnSaleSSPReport.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnSaleSSPReport.TabIndex = 14;
            this.btnSaleSSPReport.Text = "ລາຍງານຂາຍອາໄຫຼ່";
            this.btnSaleSSPReport.Click += new System.EventHandler(this.btnSaleSSPReport_Click);
            // 
            // btnReportBuySparePart
            // 
            this.btnReportBuySparePart.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReportBuySparePart.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnReportBuySparePart.Location = new System.Drawing.Point(4, 155);
            this.btnReportBuySparePart.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnReportBuySparePart.Name = "btnReportBuySparePart";
            this.btnReportBuySparePart.Size = new System.Drawing.Size(190, 46);
            this.btnReportBuySparePart.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnReportBuySparePart.TabIndex = 13;
            this.btnReportBuySparePart.Text = "ລາຍງານຊຶ້ອາໄຫຼ່";
            this.btnReportBuySparePart.Click += new System.EventHandler(this.btnReportBuySparePart_Click);
            // 
            // btnReportSaleCar
            // 
            this.btnReportSaleCar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReportSaleCar.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnReportSaleCar.Location = new System.Drawing.Point(4, 103);
            this.btnReportSaleCar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnReportSaleCar.Name = "btnReportSaleCar";
            this.btnReportSaleCar.Size = new System.Drawing.Size(190, 46);
            this.btnReportSaleCar.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnReportSaleCar.TabIndex = 10;
            this.btnReportSaleCar.Text = "ລາຍງານຂາຍລົດ";
            this.btnReportSaleCar.Click += new System.EventHandler(this.btnReportSaleCar_Click);
            // 
            // btnReportBuyCar
            // 
            this.btnReportBuyCar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReportBuyCar.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnReportBuyCar.Location = new System.Drawing.Point(4, 51);
            this.btnReportBuyCar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnReportBuyCar.Name = "btnReportBuyCar";
            this.btnReportBuyCar.Size = new System.Drawing.Size(190, 46);
            this.btnReportBuyCar.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnReportBuyCar.TabIndex = 9;
            this.btnReportBuyCar.Text = "ລາຍງານຊຶ້ລົດເຂົ້າ";
            this.btnReportBuyCar.Click += new System.EventHandler(this.btnReportBuyCar_Click);
            // 
            // btnReportTotalCashTransfer
            // 
            this.btnReportTotalCashTransfer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReportTotalCashTransfer.Location = new System.Drawing.Point(4, 433);
            this.btnReportTotalCashTransfer.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnReportTotalCashTransfer.Name = "btnReportTotalCashTransfer";
            this.btnReportTotalCashTransfer.Size = new System.Drawing.Size(190, 46);
            this.btnReportTotalCashTransfer.TabIndex = 8;
            this.btnReportTotalCashTransfer.Text = "ລາຍງານຍອດເງິນໂອນ-ສົດ";
            // 
            // tcl
            // 
            this.tcl.AutoCloseTabs = true;
            this.tcl.BackColor = System.Drawing.Color.Transparent;
            this.tcl.CanReorderTabs = true;
            this.tcl.CloseButtonOnTabsVisible = true;
            this.tcl.CloseButtonPosition = DevComponents.DotNetBar.eTabCloseButtonPosition.Right;
            this.tcl.CloseButtonVisible = true;
            this.tcl.Controls.Add(this.ExpandableSplitter1);
            this.tcl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcl.Font = new System.Drawing.Font("Saysettha OT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcl.Location = new System.Drawing.Point(207, 0);
            this.tcl.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tcl.Name = "tcl";
            this.tcl.SelectedTabFont = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.tcl.SelectedTabIndex = 0;
            this.tcl.Size = new System.Drawing.Size(1348, 595);
            this.tcl.TabIndex = 9;
            this.tcl.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcl.Text = "Add Tab";
            // 
            // ExpandableSplitter1
            // 
            this.ExpandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.ExpandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.ExpandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ExpandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.ExpandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.ExpandableSplitter1.ExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.ExpandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.ExpandableSplitter1.GripDarkColor = System.Drawing.SystemColors.ControlText;
            this.ExpandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.ExpandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.ExpandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.ExpandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.ExpandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(139)))));
            this.ExpandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.ExpandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.ExpandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.ExpandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.ExpandableSplitter1.HotExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.ExpandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.ExpandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.ExpandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.ExpandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.ExpandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.ExpandableSplitter1.Location = new System.Drawing.Point(0, 30);
            this.ExpandableSplitter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ExpandableSplitter1.Name = "ExpandableSplitter1";
            this.ExpandableSplitter1.Size = new System.Drawing.Size(4, 565);
            this.ExpandableSplitter1.TabIndex = 1;
            this.ExpandableSplitter1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1555, 624);
            this.Controls.Add(this.tcl);
            this.Controls.Add(this.ExpandablePanel1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ExpandablePanel1.ResumeLayout(false);
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.expExchangeTreasury.ResumeLayout(false);
            this.expTransaction.ResumeLayout(false);
            this.expSummaryTreasury.ResumeLayout(false);
            this.expandablePanel3.ResumeLayout(false);
            this.expandablePanel2.ResumeLayout(false);
            this.expSetting.ResumeLayout(false);
            this.expReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcl)).EndInit();
            this.tcl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        internal DevComponents.DotNetBar.ExpandablePanel ExpandablePanel1;
        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal DevComponents.DotNetBar.ExpandablePanel expExchangeTreasury;
        internal DevComponents.DotNetBar.ButtonX btnBuyCar;
        internal DevComponents.DotNetBar.ExpandablePanel expTransaction;
        internal DevComponents.DotNetBar.ButtonX btnSaleCarHistory;
        internal DevComponents.DotNetBar.ButtonX btnSaleCar;
        internal DevComponents.DotNetBar.ExpandablePanel expSummaryTreasury;
        internal DevComponents.DotNetBar.ButtonX btnSaleSparePartList;
        internal DevComponents.DotNetBar.ButtonX btnBuySparePartList;
        internal DevComponents.DotNetBar.ExpandablePanel expSetting;
        internal DevComponents.DotNetBar.ButtonX btnRoleAccess;
        internal DevComponents.DotNetBar.ButtonX btnUser;
        internal DevComponents.DotNetBar.ButtonX btnSparePart;
        internal DevComponents.DotNetBar.ButtonX btnCustomer;
        internal DevComponents.DotNetBar.ButtonX btnCarInfo;
        internal DevComponents.DotNetBar.ButtonX frmExchangeRate;
        internal DevComponents.DotNetBar.ExpandablePanel expReport;
        internal DevComponents.DotNetBar.ButtonX btnReportBuySparePart;
        internal DevComponents.DotNetBar.ButtonX btnReportSaleCar;
        internal DevComponents.DotNetBar.ButtonX btnReportBuyCar;
        internal DevComponents.DotNetBar.ButtonX btnReportTotalCashTransfer;
        internal DevComponents.DotNetBar.ExpandableSplitter ExpandableSplitter1;
        internal DevComponents.DotNetBar.ButtonX btnBuyCarList;
        public DevComponents.DotNetBar.TabControl tcl;
        private System.Windows.Forms.ToolStripStatusLabel lbl_status_user;
        private System.Windows.Forms.ToolStripStatusLabel lbl_status_exchange;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        internal DevComponents.DotNetBar.ExpandablePanel expandablePanel2;
        internal DevComponents.DotNetBar.ButtonX btnExpenseList;
        internal DevComponents.DotNetBar.ExpandablePanel expandablePanel3;
        internal DevComponents.DotNetBar.ButtonX btnCheckSPPBalance;
        internal DevComponents.DotNetBar.ButtonX btnCheckCarBalance;
        internal DevComponents.DotNetBar.ButtonX btnProfitLoseReport;
        internal DevComponents.DotNetBar.ButtonX btnExpenseReport;
        internal DevComponents.DotNetBar.ButtonX btnSaleSSPReport;
        internal DevComponents.DotNetBar.ButtonX btnExpenseCode;

    }
}