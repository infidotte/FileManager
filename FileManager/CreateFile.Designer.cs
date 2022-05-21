using System.ComponentModel;
using System.Windows.Forms;

namespace FileManager
{
    partial class CreateFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateFile));
            this.name = new System.Windows.Forms.TextBox();
            this.create = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.extension = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(9, 28);
            this.name.Margin = new System.Windows.Forms.Padding(2);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(115, 20);
            this.name.TabIndex = 0;
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(76, 51);
            this.create.Margin = new System.Windows.Forms.Padding(2);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(56, 19);
            this.create.TabIndex = 1;
            this.create.Text = "Create";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Имя:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(128, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Расширение:";
            // 
            // extension
            // 
            this.extension.Location = new System.Drawing.Point(128, 28);
            this.extension.Margin = new System.Windows.Forms.Padding(2);
            this.extension.Name = "extension";
            this.extension.Size = new System.Drawing.Size(76, 20);
            this.extension.TabIndex = 4;
            // 
            // CreateFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 79);
            this.Controls.Add(this.extension);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.create);
            this.Controls.Add(this.name);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(580, 267);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CreateFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Создание";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox extension;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Button create;

        #endregion
    }
}