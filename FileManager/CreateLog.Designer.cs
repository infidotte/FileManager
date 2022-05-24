using System.ComponentModel;

namespace FileManager
{
    partial class CreateLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.logname = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя логфайла:";
            // 
            // logname
            // 
            this.logname.Location = new System.Drawing.Point(12, 35);
            this.logname.Name = "logname";
            this.logname.Size = new System.Drawing.Size(100, 20);
            this.logname.TabIndex = 1;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(12, 61);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(100, 23);
            this.save.TabIndex = 2;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // CreateLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(124, 101);
            this.Controls.Add(this.save);
            this.Controls.Add(this.logname);
            this.Controls.Add(this.label1);
            this.Name = "CreateLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CreateLog";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox logname;
        private System.Windows.Forms.Button save;

        #endregion
    }
}