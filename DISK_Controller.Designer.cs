namespace OS_Demo
{
    partial class DISK_Controller
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
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(" 1 ");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("1");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("1");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("1");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("1");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("1");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("1");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("1");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("55");
            this.Decemal_LV = new System.Windows.Forms.ListView();
            this.Hex_LV = new System.Windows.Forms.ListView();
            this.Prev_B = new System.Windows.Forms.Button();
            this.Next_B = new System.Windows.Forms.Button();
            this.Page_NUD = new System.Windows.Forms.NumericUpDown();
            this.PageTable_LV = new System.Windows.Forms.ListView();
            this.File_Type = new System.Windows.Forms.ColumnHeader();
            this.File_Start_Page = new System.Windows.Forms.ColumnHeader();
            this.File_Length = new System.Windows.Forms.ColumnHeader();
            this.File_Name = new System.Windows.Forms.ColumnHeader();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Page_NUD)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(this.Decemal_LV, 0, 0);
            tableLayoutPanel1.Controls.Add(this.Hex_LV, 2, 0);
            tableLayoutPanel1.Controls.Add(this.Prev_B, 0, 1);
            tableLayoutPanel1.Controls.Add(this.Next_B, 3, 1);
            tableLayoutPanel1.Controls.Add(this.Page_NUD, 1, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(364, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new System.Drawing.Size(920, 591);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // Decemal_LV
            // 
            tableLayoutPanel1.SetColumnSpan(this.Decemal_LV, 2);
            this.Decemal_LV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Decemal_LV.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Decemal_LV.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9});
            this.Decemal_LV.Location = new System.Drawing.Point(3, 0);
            this.Decemal_LV.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Decemal_LV.Name = "Decemal_LV";
            this.Decemal_LV.Size = new System.Drawing.Size(454, 541);
            this.Decemal_LV.TabIndex = 0;
            this.Decemal_LV.UseCompatibleStateImageBehavior = false;
            this.Decemal_LV.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Decemal_LV_MouseUp);
            // 
            // Hex_LV
            // 
            tableLayoutPanel1.SetColumnSpan(this.Hex_LV, 2);
            this.Hex_LV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Hex_LV.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Hex_LV.Location = new System.Drawing.Point(463, 0);
            this.Hex_LV.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Hex_LV.Name = "Hex_LV";
            this.Hex_LV.Size = new System.Drawing.Size(454, 541);
            this.Hex_LV.TabIndex = 1;
            this.Hex_LV.UseCompatibleStateImageBehavior = false;
            this.Hex_LV.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Hex_LV_MouseUp);
            // 
            // Prev_B
            // 
            this.Prev_B.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Prev_B.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Prev_B.Location = new System.Drawing.Point(210, 546);
            this.Prev_B.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.Prev_B.Name = "Prev_B";
            this.Prev_B.Size = new System.Drawing.Size(150, 40);
            this.Prev_B.TabIndex = 2;
            this.Prev_B.Text = "Предыдущая";
            this.Prev_B.UseVisualStyleBackColor = true;
            this.Prev_B.Click += new System.EventHandler(this.Prev_B_Click);
            // 
            // Next_B
            // 
            this.Next_B.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Next_B.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Next_B.Location = new System.Drawing.Point(560, 546);
            this.Next_B.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.Next_B.Name = "Next_B";
            this.Next_B.Size = new System.Drawing.Size(150, 40);
            this.Next_B.TabIndex = 3;
            this.Next_B.Text = "Следующая";
            this.Next_B.UseVisualStyleBackColor = true;
            this.Next_B.Click += new System.EventHandler(this.Next_B_Click);
            // 
            // Page_NUD
            // 
            this.Page_NUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel1.SetColumnSpan(this.Page_NUD, 2);
            this.Page_NUD.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Page_NUD.Location = new System.Drawing.Point(383, 548);
            this.Page_NUD.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Page_NUD.Name = "Page_NUD";
            this.Page_NUD.Size = new System.Drawing.Size(154, 35);
            this.Page_NUD.TabIndex = 4;
            this.Page_NUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Page_NUD.ValueChanged += new System.EventHandler(this.Page_NUD_ValueChanged);
            // 
            // PageTable_LV
            // 
            this.PageTable_LV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PageTable_LV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.File_Type,
            this.File_Start_Page,
            this.File_Length,
            this.File_Name});
            this.PageTable_LV.Dock = System.Windows.Forms.DockStyle.Left;
            this.PageTable_LV.FullRowSelect = true;
            this.PageTable_LV.GridLines = true;
            this.PageTable_LV.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.PageTable_LV.Location = new System.Drawing.Point(0, 0);
            this.PageTable_LV.MultiSelect = false;
            this.PageTable_LV.Name = "PageTable_LV";
            this.PageTable_LV.Size = new System.Drawing.Size(364, 591);
            this.PageTable_LV.TabIndex = 0;
            this.PageTable_LV.UseCompatibleStateImageBehavior = false;
            this.PageTable_LV.View = System.Windows.Forms.View.Details;
            this.PageTable_LV.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PageTable_LV_MouseUp);
            // 
            // File_Type
            // 
            this.File_Type.Text = "Тип";
            this.File_Type.Width = 40;
            // 
            // File_Start_Page
            // 
            this.File_Start_Page.Text = "Начало";
            this.File_Start_Page.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // File_Length
            // 
            this.File_Length.DisplayIndex = 3;
            this.File_Length.Text = "Размер";
            this.File_Length.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.File_Length.Width = 80;
            // 
            // File_Name
            // 
            this.File_Name.DisplayIndex = 2;
            this.File_Name.Text = "Название файла";
            this.File_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.File_Name.Width = 180;
            // 
            // DISK_Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 591);
            this.Controls.Add(tableLayoutPanel1);
            this.Controls.Add(this.PageTable_LV);
            this.DoubleBuffered = true;
            this.Name = "DISK_Controller";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Диспетчер дисковой памяти";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Page_NUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ListView PageTable_LV;
        private ColumnHeader File_Type;
        private ColumnHeader File_Start_Page;
        private ColumnHeader File_Name;
        private ColumnHeader File_Length;
        private ListView Decemal_LV;
        private ListView Hex_LV;
        private Button Prev_B;
        private Button Next_B;
        private NumericUpDown Page_NUD;
    }
}