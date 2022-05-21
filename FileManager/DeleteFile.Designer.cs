using System.ComponentModel;
using System.Windows.Forms;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteFile));
            this.label1 = new System.Windows.Forms.Label();
            this.fulldelete = new System.Windows.Forms.Button();
            this.totrash = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Как удалить?\r\n";
            // 
            // fulldelete
            // 
            this.fulldelete.Location = new System.Drawing.Point(9, 28);
            this.fulldelete.Margin = new System.Windows.Forms.Padding(2);
            this.fulldelete.Name = "fulldelete";
            this.fulldelete.Size = new System.Drawing.Size(90, 24);
            this.fulldelete.TabIndex = 1;
            this.fulldelete.Text = "Безвозвратно";
            this.fulldelete.UseVisualStyleBackColor = true;
            this.fulldelete.Click += new System.EventHandler(this.fulldelete_Click);
            // 
            // totrash
            // 
            this.totrash.Location = new System.Drawing.Point(103, 28);
            this.totrash.Margin = new System.Windows.Forms.Padding(2);
            this.totrash.Name = "totrash";
            this.totrash.Size = new System.Drawing.Size(82, 24);
            this.totrash.TabIndex = 2;
            this.totrash.Text = "В корзину";
            this.totrash.UseVisualStyleBackColor = true;
            this.totrash.Click += new System.EventHandler(this.totrash_Click);
            // 
            // DeleteFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 61);
            this.Controls.Add(this.totrash);
            this.Controls.Add(this.fulldelete);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(115, 244);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DeleteFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Удаление";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button fulldelete;
        private System.Windows.Forms.Button totrash;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}