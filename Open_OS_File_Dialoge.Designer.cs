namespace OS_Demo
{
    partial class Open_OS_File_Dialoge
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Hello world.txt");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("test");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("test.exe");
            this.Files_LV = new System.Windows.Forms.ListView();
            this.Accept_B = new System.Windows.Forms.Button();
            this.Cancel_B = new System.Windows.Forms.Button();
            this.Filename_TB = new System.Windows.Forms.TextBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            tableLayoutPanel1.Controls.Add(this.Files_LV, 0, 0);
            tableLayoutPanel1.Controls.Add(this.Accept_B, 1, 1);
            tableLayoutPanel1.Controls.Add(this.Cancel_B, 2, 1);
            tableLayoutPanel1.Controls.Add(this.Filename_TB, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new System.Drawing.Size(584, 361);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // Files_LV
            // 
            tableLayoutPanel1.SetColumnSpan(this.Files_LV, 3);
            this.Files_LV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Files_LV.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.Files_LV.Location = new System.Drawing.Point(3, 3);
            this.Files_LV.Name = "Files_LV";
            this.Files_LV.Size = new System.Drawing.Size(578, 305);
            this.Files_LV.TabIndex = 0;
            this.Files_LV.UseCompatibleStateImageBehavior = false;
            this.Files_LV.View = System.Windows.Forms.View.SmallIcon;
            this.Files_LV.SelectedIndexChanged += new System.EventHandler(this.Files_LV_SelectedIndexChanged);
            // 
            // Accept_B
            // 
            this.Accept_B.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Accept_B.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Accept_B.Location = new System.Drawing.Point(302, 318);
            this.Accept_B.Name = "Accept_B";
            this.Accept_B.Size = new System.Drawing.Size(114, 35);
            this.Accept_B.TabIndex = 1;
            this.Accept_B.Text = "Выбрать";
            this.Accept_B.UseVisualStyleBackColor = true;
            this.Accept_B.Click += new System.EventHandler(this.Accept_B_Click);
            // 
            // Cancel_B
            // 
            this.Cancel_B.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_B.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Cancel_B.Location = new System.Drawing.Point(452, 318);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(114, 35);
            this.Cancel_B.TabIndex = 2;
            this.Cancel_B.Text = "Отмена";
            this.Cancel_B.UseVisualStyleBackColor = true;
            this.Cancel_B.Click += new System.EventHandler(this.Cancel_B_Click);
            // 
            // Filename_TB
            // 
            this.Filename_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Filename_TB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Filename_TB.Location = new System.Drawing.Point(40, 321);
            this.Filename_TB.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.Filename_TB.Name = "Filename_TB";
            this.Filename_TB.Size = new System.Drawing.Size(241, 29);
            this.Filename_TB.TabIndex = 3;
            this.Filename_TB.TextChanged += new System.EventHandler(this.Filename_TB_TextChanged);
            // 
            // Open_OS_File_Dialoge
            // 
            this.AcceptButton = this.Accept_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_B;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Open_OS_File_Dialoge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Файлы";
            this.Shown += new System.EventHandler(this.Open_OS_File_Dialoge_Shown);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ListView Files_LV;
        private Button Accept_B;
        private Button Cancel_B;
        private TextBox Filename_TB;
    }
}