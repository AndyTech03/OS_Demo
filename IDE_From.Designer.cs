namespace OS_Demo
{
    partial class IDE_From
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
            this.Main_RTB = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.File_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.New_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Open_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Save_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Building_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ReBuild_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Build_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_RTB
            // 
            this.Main_RTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_RTB.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Main_RTB.Location = new System.Drawing.Point(0, 24);
            this.Main_RTB.Name = "Main_RTB";
            this.Main_RTB.Size = new System.Drawing.Size(800, 426);
            this.Main_RTB.TabIndex = 0;
            this.Main_RTB.Text = "wm  R1\nset R2\n";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_TSMI,
            this.Building_TSMI});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // File_TSMI
            // 
            this.File_TSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.New_TSMI,
            this.Open_TSMI,
            this.toolStripSeparator1,
            this.Save_TSMI,
            this.SaveAs_TSMI});
            this.File_TSMI.Name = "File_TSMI";
            this.File_TSMI.Size = new System.Drawing.Size(48, 20);
            this.File_TSMI.Text = "Файл";
            // 
            // New_TSMI
            // 
            this.New_TSMI.Name = "New_TSMI";
            this.New_TSMI.Size = new System.Drawing.Size(154, 22);
            this.New_TSMI.Text = "Новый";
            this.New_TSMI.Click += new System.EventHandler(this.New_TSMI_Click);
            // 
            // Open_TSMI
            // 
            this.Open_TSMI.Name = "Open_TSMI";
            this.Open_TSMI.Size = new System.Drawing.Size(154, 22);
            this.Open_TSMI.Text = "Открыть";
            this.Open_TSMI.Click += new System.EventHandler(this.Open_TSMI_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // Save_TSMI
            // 
            this.Save_TSMI.Name = "Save_TSMI";
            this.Save_TSMI.Size = new System.Drawing.Size(154, 22);
            this.Save_TSMI.Text = "Сохранить";
            this.Save_TSMI.Click += new System.EventHandler(this.SaveAs_TSMI_Click);
            // 
            // SaveAs_TSMI
            // 
            this.SaveAs_TSMI.Name = "SaveAs_TSMI";
            this.SaveAs_TSMI.Size = new System.Drawing.Size(154, 22);
            this.SaveAs_TSMI.Text = "Сохранить как";
            this.SaveAs_TSMI.Click += new System.EventHandler(this.SaveAs_TSMI_Click);
            // 
            // Building_TSMI
            // 
            this.Building_TSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReBuild_TSMI,
            this.Build_TSMI});
            this.Building_TSMI.Name = "Building_TSMI";
            this.Building_TSMI.Size = new System.Drawing.Size(60, 20);
            this.Building_TSMI.Text = "Сборка";
            // 
            // ReBuild_TSMI
            // 
            this.ReBuild_TSMI.Name = "ReBuild_TSMI";
            this.ReBuild_TSMI.Size = new System.Drawing.Size(146, 22);
            this.ReBuild_TSMI.Text = "Пересобрать";
            this.ReBuild_TSMI.Click += new System.EventHandler(this.Build_TSMI_Click);
            // 
            // Build_TSMI
            // 
            this.Build_TSMI.Name = "Build_TSMI";
            this.Build_TSMI.Size = new System.Drawing.Size(146, 22);
            this.Build_TSMI.Text = "Собрать в";
            this.Build_TSMI.Click += new System.EventHandler(this.Build_TSMI_Click);
            // 
            // IDE_From
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Main_RTB);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IDE_From";
            this.Text = "IDE_From";
            this.Shown += new System.EventHandler(this.IDE_From_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox Main_RTB;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem File_TSMI;
        private ToolStripMenuItem New_TSMI;
        private ToolStripMenuItem Open_TSMI;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem Save_TSMI;
        private ToolStripMenuItem SaveAs_TSMI;
        private ToolStripMenuItem Building_TSMI;
        private ToolStripMenuItem ReBuild_TSMI;
        private ToolStripMenuItem Build_TSMI;
    }
}