using System.ComponentModel;

namespace FileManager
{
    partial class DeleteFile
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
            this.fulldelete = new System.Windows.Forms.Button();
            this.totrash = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Как удалить?\r\n";
            // 
            // fulldelete
            // 
            this.fulldelete.Location = new System.Drawing.Point(12, 35);
            this.fulldelete.Name = "fulldelete";
            this.fulldelete.Size = new System.Drawing.Size(110, 30);
            this.fulldelete.TabIndex = 1;
            this.fulldelete.Text = "Безвозвратно";
            this.fulldelete.UseVisualStyleBackColor = true;
            this.fulldelete.Click += new System.EventHandler(this.fulldelete_Click);
            // 
            // totrash
            // 
            this.totrash.Location = new System.Drawing.Point(128, 35);
            this.totrash.Name = "totrash";
            this.totrash.Size = new System.Drawing.Size(110, 30);
            this.totrash.TabIndex = 2;
            this.totrash.Text = "В корзину";
            this.totrash.UseVisualStyleBackColor = true;
            this.totrash.Click += new System.EventHandler(this.totrash_Click);
            // 
            // DeleteFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 75);
            this.Controls.Add(this.totrash);
            this.Controls.Add(this.fulldelete);
            this.Controls.Add(this.label1);
            this.Name = "DeleteFile";
            this.Text = "DeleteFile";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button fulldelete;
        private System.Windows.Forms.Button totrash;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}