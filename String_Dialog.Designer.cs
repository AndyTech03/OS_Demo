namespace OS_Demo
{
    partial class String_Dialog
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Message_L = new System.Windows.Forms.Label();
            this.Input_TB = new System.Windows.Forms.TextBox();
            this.Accept_B = new System.Windows.Forms.Button();
            this.Cancel_B = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Message_L, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Input_TB, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Accept_B, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Cancel_B, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 211);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Message_L
            // 
            this.Message_L.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Message_L.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.Message_L, 2);
            this.Message_L.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Message_L.Location = new System.Drawing.Point(3, 71);
            this.Message_L.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.Message_L.Name = "Message_L";
            this.Message_L.Size = new System.Drawing.Size(378, 30);
            this.Message_L.TabIndex = 0;
            this.Message_L.Text = "label1";
            this.Message_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Input_TB
            // 
            this.Input_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.Input_TB, 2);
            this.Input_TB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Input_TB.Location = new System.Drawing.Point(50, 121);
            this.Input_TB.Margin = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.Input_TB.Name = "Input_TB";
            this.Input_TB.Size = new System.Drawing.Size(284, 29);
            this.Input_TB.TabIndex = 1;
            this.Input_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Accept_B
            // 
            this.Accept_B.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Accept_B.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Accept_B.Location = new System.Drawing.Point(90, 170);
            this.Accept_B.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.Accept_B.Name = "Accept_B";
            this.Accept_B.Size = new System.Drawing.Size(82, 32);
            this.Accept_B.TabIndex = 2;
            this.Accept_B.Text = "Ввод";
            this.Accept_B.UseVisualStyleBackColor = true;
            this.Accept_B.Click += new System.EventHandler(this.Accept_B_Click);
            // 
            // Cancel_B
            // 
            this.Cancel_B.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Cancel_B.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Cancel_B.Location = new System.Drawing.Point(212, 170);
            this.Cancel_B.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(82, 32);
            this.Cancel_B.TabIndex = 3;
            this.Cancel_B.Text = "Отмена";
            this.Cancel_B.UseVisualStyleBackColor = true;
            this.Cancel_B.Click += new System.EventHandler(this.Cancel_B_Click);
            // 
            // String_Dialog
            // 
            this.AcceptButton = this.Accept_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_B;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "String_Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "String_Dialog";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label Message_L;
        private TextBox Input_TB;
        private Button Accept_B;
        private Button Cancel_B;
    }
}