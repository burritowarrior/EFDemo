namespace WinForm
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.form2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.form3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainFormToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.threadFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testHarnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entityFrameworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eFInsertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(499, 237);
            this.dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.launchToolStripMenuItem,
            this.otherToolStripMenuItem,
            this.entityFrameworkToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(499, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fILEToolStripMenuItem.Text = "&File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // launchToolStripMenuItem
            // 
            this.launchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.form2ToolStripMenuItem,
            this.form3ToolStripMenuItem,
            this.mainFormToolStripMenuItem,
            this.mainFormToolStripMenuItem1,
            this.threadFormToolStripMenuItem});
            this.launchToolStripMenuItem.Name = "launchToolStripMenuItem";
            this.launchToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.launchToolStripMenuItem.Text = "&Launch";
            // 
            // form2ToolStripMenuItem
            // 
            this.form2ToolStripMenuItem.Name = "form2ToolStripMenuItem";
            this.form2ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.form2ToolStripMenuItem.Text = "&Form2";
            this.form2ToolStripMenuItem.Click += new System.EventHandler(this.form2ToolStripMenuItem_Click);
            // 
            // form3ToolStripMenuItem
            // 
            this.form3ToolStripMenuItem.Name = "form3ToolStripMenuItem";
            this.form3ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.form3ToolStripMenuItem.Text = "F&orm3";
            this.form3ToolStripMenuItem.Click += new System.EventHandler(this.form3ToolStripMenuItem_Click);
            // 
            // mainFormToolStripMenuItem
            // 
            this.mainFormToolStripMenuItem.Name = "mainFormToolStripMenuItem";
            this.mainFormToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.mainFormToolStripMenuItem.Text = "&Main Form";
            this.mainFormToolStripMenuItem.Click += new System.EventHandler(this.mainFormToolStripMenuItem_Click);
            // 
            // mainFormToolStripMenuItem1
            // 
            this.mainFormToolStripMenuItem1.Name = "mainFormToolStripMenuItem1";
            this.mainFormToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.mainFormToolStripMenuItem1.Text = "Main Fo&rm 2";
            this.mainFormToolStripMenuItem1.Click += new System.EventHandler(this.mainFormToolStripMenuItem1_Click);
            // 
            // threadFormToolStripMenuItem
            // 
            this.threadFormToolStripMenuItem.Name = "threadFormToolStripMenuItem";
            this.threadFormToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.threadFormToolStripMenuItem.Text = "&Thread Form";
            this.threadFormToolStripMenuItem.Click += new System.EventHandler(this.threadFormToolStripMenuItem_Click);
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testHarnessToolStripMenuItem,
            this.showTimeToolStripMenuItem,
            this.sampleReportToolStripMenuItem});
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.otherToolStripMenuItem.Text = "&Other";
            // 
            // testHarnessToolStripMenuItem
            // 
            this.testHarnessToolStripMenuItem.Name = "testHarnessToolStripMenuItem";
            this.testHarnessToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.testHarnessToolStripMenuItem.Text = "Test &Harness";
            this.testHarnessToolStripMenuItem.Click += new System.EventHandler(this.testHarnessToolStripMenuItem_Click);
            // 
            // showTimeToolStripMenuItem
            // 
            this.showTimeToolStripMenuItem.Name = "showTimeToolStripMenuItem";
            this.showTimeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.showTimeToolStripMenuItem.Text = "S&how Time";
            this.showTimeToolStripMenuItem.Click += new System.EventHandler(this.showTimeToolStripMenuItem_Click);
            // 
            // sampleReportToolStripMenuItem
            // 
            this.sampleReportToolStripMenuItem.Name = "sampleReportToolStripMenuItem";
            this.sampleReportToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.sampleReportToolStripMenuItem.Text = "Sample &Report";
            this.sampleReportToolStripMenuItem.Click += new System.EventHandler(this.sampleReportToolStripMenuItem_Click);
            // 
            // entityFrameworkToolStripMenuItem
            // 
            this.entityFrameworkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eFInsertToolStripMenuItem});
            this.entityFrameworkToolStripMenuItem.Name = "entityFrameworkToolStripMenuItem";
            this.entityFrameworkToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.entityFrameworkToolStripMenuItem.Text = "&Entity Framework";
            // 
            // eFInsertToolStripMenuItem
            // 
            this.eFInsertToolStripMenuItem.Name = "eFInsertToolStripMenuItem";
            this.eFInsertToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eFInsertToolStripMenuItem.Text = "EF &Insert";
            this.eFInsertToolStripMenuItem.Click += new System.EventHandler(this.eFInsertToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 261);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem form2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem form3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainFormToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem threadFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testHarnessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sampleReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entityFrameworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eFInsertToolStripMenuItem;
    }
}

