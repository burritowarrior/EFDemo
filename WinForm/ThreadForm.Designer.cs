namespace WinForm
{
    partial class ThreadForm
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
            this.buttonGo = new System.Windows.Forms.Button();
            this.listboxResults = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(108, 226);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 0;
            this.buttonGo.Text = "button1";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // listboxResults
            // 
            this.listboxResults.FormattingEnabled = true;
            this.listboxResults.Location = new System.Drawing.Point(13, 22);
            this.listboxResults.Name = "listboxResults";
            this.listboxResults.Size = new System.Drawing.Size(259, 160);
            this.listboxResults.TabIndex = 1;
            // 
            // ThreadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.listboxResults);
            this.Controls.Add(this.buttonGo);
            this.Name = "ThreadForm";
            this.Text = "ThreadForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.ListBox listboxResults;
    }
}