using System;
using System.Windows.Forms;

namespace FileManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PathText = new System.Windows.Forms.TextBox();
            this.backbutton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ContextMenu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenu1_createbutton = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu1_deletebutton = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu1_copybutton = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu1_cutbutton = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu1_renamebutton = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu1_pastebutton = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu1_cleare = new System.Windows.Forms.ToolStripMenuItem();
            this.gobutton = new System.Windows.Forms.Button();
            this.ContextMenu2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenu2_createbutton = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu2_pastebutton = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu2_cleare = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstrip = new System.Windows.Forms.ToolStrip();
            this.Main = new System.Windows.Forms.ToolStripDropDownButton();
            this.Main_aboutbutton = new System.Windows.Forms.ToolStripMenuItem();
            this.Main_helpbutton = new System.Windows.Forms.ToolStripMenuItem();
            this.Utilites = new System.Windows.Forms.ToolStripDropDownButton();
            this.Utilites_taskmanager = new System.Windows.Forms.ToolStripMenuItem();
            this.Utilites_controlpanel = new System.Windows.Forms.ToolStripMenuItem();
            this.Utilites_systembutton = new System.Windows.Forms.ToolStripMenuItem();
            this.Functionality = new System.Windows.Forms.ToolStripDropDownButton();
            this.Functionality_openpipeline = new System.Windows.Forms.ToolStripMenuItem();
            this.Functionality_closepipeline = new System.Windows.Forms.ToolStripMenuItem();
            this.Functionality_openlogfile = new System.Windows.Forms.ToolStripMenuItem();
            this.Terminals = new System.Windows.Forms.ToolStripMenuItem();
            this.Terminals_linux = new System.Windows.Forms.ToolStripMenuItem();
            this.Terminals_windows = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu1.SuspendLayout();
            this.ContextMenu2.SuspendLayout();
            this.toolstrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // PathText
            // 
            this.PathText.Location = new System.Drawing.Point(9, 26);
            this.PathText.Margin = new System.Windows.Forms.Padding(2);
            this.PathText.Name = "PathText";
            this.PathText.Size = new System.Drawing.Size(294, 20);
            this.PathText.TabIndex = 0;
            // 
            // backbutton
            // 
            this.backbutton.Location = new System.Drawing.Point(307, 26);
            this.backbutton.Margin = new System.Windows.Forms.Padding(2);
            this.backbutton.Name = "backbutton";
            this.backbutton.Size = new System.Drawing.Size(17, 19);
            this.backbutton.TabIndex = 1;
            this.backbutton.Text = "⨞";
            this.backbutton.UseVisualStyleBackColor = true;
            this.backbutton.Click += new System.EventHandler(this.OnBackButtonClick);
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(9, 50);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(336, 323);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.StateImageList = this.imageList1;
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.DragOver += new System.Windows.Forms.DragEventHandler(this.listView1_DragOver);
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "disc.png");
            this.imageList1.Images.SetKeyName(1, "package.png");
            this.imageList1.Images.SetKeyName(2, "file.png");
            this.imageList1.Images.SetKeyName(3, "usb.png");
            // 
            // ContextMenu1
            // 
            this.ContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.ContextMenu1_createbutton, this.ContextMenu1_deletebutton, this.ContextMenu1_copybutton, this.ContextMenu1_cutbutton, this.ContextMenu1_renamebutton, this.ContextMenu1_pastebutton, this.ContextMenu1_cleare});
            this.ContextMenu1.Name = "ContextMenu1";
            this.ContextMenu1.Size = new System.Drawing.Size(165, 158);
            // 
            // ContextMenu1_createbutton
            // 
            this.ContextMenu1_createbutton.Name = "ContextMenu1_createbutton";
            this.ContextMenu1_createbutton.Size = new System.Drawing.Size(164, 22);
            this.ContextMenu1_createbutton.Text = "Create";
            this.ContextMenu1_createbutton.Click += new System.EventHandler(this.ContextMenu1_CreateButton);
            // 
            // ContextMenu1_deletebutton
            // 
            this.ContextMenu1_deletebutton.Name = "ContextMenu1_deletebutton";
            this.ContextMenu1_deletebutton.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.ContextMenu1_deletebutton.Size = new System.Drawing.Size(164, 22);
            this.ContextMenu1_deletebutton.Text = "Delete";
            this.ContextMenu1_deletebutton.Click += new System.EventHandler(this.ContextMenu1_DeleteButton);
            // 
            // ContextMenu1_copybutton
            // 
            this.ContextMenu1_copybutton.Name = "ContextMenu1_copybutton";
            this.ContextMenu1_copybutton.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.ContextMenu1_copybutton.Size = new System.Drawing.Size(164, 22);
            this.ContextMenu1_copybutton.Text = "Copy";
            this.ContextMenu1_copybutton.Click += new System.EventHandler(this.ContextMenu1_CopyButton);
            // 
            // ContextMenu1_cutbutton
            // 
            this.ContextMenu1_cutbutton.Name = "ContextMenu1_cutbutton";
            this.ContextMenu1_cutbutton.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.ContextMenu1_cutbutton.Size = new System.Drawing.Size(164, 22);
            this.ContextMenu1_cutbutton.Text = "Cut";
            this.ContextMenu1_cutbutton.Click += new System.EventHandler(this.ContextMenu1_CutButton);
            // 
            // ContextMenu1_renamebutton
            // 
            this.ContextMenu1_renamebutton.Name = "ContextMenu1_renamebutton";
            this.ContextMenu1_renamebutton.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.ContextMenu1_renamebutton.Size = new System.Drawing.Size(164, 22);
            this.ContextMenu1_renamebutton.Text = "Reaname";
            this.ContextMenu1_renamebutton.Click += new System.EventHandler(this.ContextMenu1_RenameButton);
            // 
            // ContextMenu1_pastebutton
            // 
            this.ContextMenu1_pastebutton.Name = "ContextMenu1_pastebutton";
            this.ContextMenu1_pastebutton.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.ContextMenu1_pastebutton.Size = new System.Drawing.Size(164, 22);
            this.ContextMenu1_pastebutton.Text = "Paste";
            this.ContextMenu1_pastebutton.Click += new System.EventHandler(this.ContextMenu1_PasteButton);
            // 
            // ContextMenu1_cleare
            // 
            this.ContextMenu1_cleare.Name = "ContextMenu1_cleare";
            this.ContextMenu1_cleare.Size = new System.Drawing.Size(164, 22);
            this.ContextMenu1_cleare.Text = "Cleare";
            this.ContextMenu1_cleare.Click += new System.EventHandler(this.ContextMenu1_cleare_Click);
            // 
            // gobutton
            // 
            this.gobutton.Location = new System.Drawing.Point(328, 26);
            this.gobutton.Margin = new System.Windows.Forms.Padding(2);
            this.gobutton.Name = "gobutton";
            this.gobutton.Size = new System.Drawing.Size(17, 19);
            this.gobutton.TabIndex = 6;
            this.gobutton.Text = "🔎";
            this.gobutton.UseVisualStyleBackColor = true;
            this.gobutton.Click += new System.EventHandler(this.onGoButtonClick);
            // 
            // ContextMenu2
            // 
            this.ContextMenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.ContextMenu2_createbutton, this.ContextMenu2_pastebutton, this.ContextMenu2_cleare});
            this.ContextMenu2.Name = "ContextMenu1";
            this.ContextMenu2.Size = new System.Drawing.Size(144, 70);
            // 
            // ContextMenu2_createbutton
            // 
            this.ContextMenu2_createbutton.Name = "ContextMenu2_createbutton";
            this.ContextMenu2_createbutton.Size = new System.Drawing.Size(143, 22);
            this.ContextMenu2_createbutton.Text = "Create";
            this.ContextMenu2_createbutton.Click += new System.EventHandler(this.ContextMenu2_CreateButton);
            // 
            // ContextMenu2_pastebutton
            // 
            this.ContextMenu2_pastebutton.Name = "ContextMenu2_pastebutton";
            this.ContextMenu2_pastebutton.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.ContextMenu2_pastebutton.Size = new System.Drawing.Size(143, 22);
            this.ContextMenu2_pastebutton.Text = "Paste";
            this.ContextMenu2_pastebutton.Click += new System.EventHandler(this.ContextMenu2_PasteButton);
            // 
            // ContextMenu2_cleare
            // 
            this.ContextMenu2_cleare.Name = "ContextMenu2_cleare";
            this.ContextMenu2_cleare.Size = new System.Drawing.Size(143, 22);
            this.ContextMenu2_cleare.Text = "Cleare";
            this.ContextMenu2_cleare.Click += new System.EventHandler(this.ContextMenu2_cleare_Click);
            // 
            // toolstrip
            // 
            this.toolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.Main, this.Utilites, this.Functionality});
            this.toolstrip.Location = new System.Drawing.Point(0, 0);
            this.toolstrip.Name = "toolstrip";
            this.toolstrip.Size = new System.Drawing.Size(354, 25);
            this.toolstrip.TabIndex = 7;
            this.toolstrip.Text = "toolStrip1";
            // 
            // Main
            // 
            this.Main.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Main.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.Main_aboutbutton, this.Main_helpbutton});
            this.Main.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(77, 22);
            this.Main.Text = "Главное⚙";
            // 
            // Main_aboutbutton
            // 
            this.Main_aboutbutton.Name = "Main_aboutbutton";
            this.Main_aboutbutton.Size = new System.Drawing.Size(152, 22);
            this.Main_aboutbutton.Text = "О программе";
            this.Main_aboutbutton.Click += new System.EventHandler(this.Main_About);
            // 
            // Main_helpbutton
            // 
            this.Main_helpbutton.Name = "Main_helpbutton";
            this.Main_helpbutton.Size = new System.Drawing.Size(152, 22);
            this.Main_helpbutton.Text = "Справка";
            this.Main_helpbutton.Click += new System.EventHandler(this.Main_Help);
            // 
            // Utilites
            // 
            this.Utilites.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Utilites.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.Utilites_taskmanager, this.Utilites_controlpanel, this.Utilites_systembutton});
            this.Utilites.Image = ((System.Drawing.Image) (resources.GetObject("Utilites.Image")));
            this.Utilites.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Utilites.Name = "Utilites";
            this.Utilites.Size = new System.Drawing.Size(79, 22);
            this.Utilites.Text = "Утилиты🧰";
            // 
            // Utilites_taskmanager
            // 
            this.Utilites_taskmanager.Name = "Utilites_taskmanager";
            this.Utilites_taskmanager.Size = new System.Drawing.Size(183, 22);
            this.Utilites_taskmanager.Text = "Диспетчер задач";
            this.Utilites_taskmanager.Click += new System.EventHandler(this.Utilits_TaskManager);
            // 
            // Utilites_controlpanel
            // 
            this.Utilites_controlpanel.Name = "Utilites_controlpanel";
            this.Utilites_controlpanel.Size = new System.Drawing.Size(183, 22);
            this.Utilites_controlpanel.Text = "Панель управления";
            this.Utilites_controlpanel.Click += new System.EventHandler(this.Utilits_ControlPanel);
            // 
            // Utilites_systembutton
            // 
            this.Utilites_systembutton.Name = "Utilites_systembutton";
            this.Utilites_systembutton.Size = new System.Drawing.Size(183, 22);
            this.Utilites_systembutton.Text = "О системе";
            this.Utilites_systembutton.Click += new System.EventHandler(this.Utilits_System);
            // 
            // Functionality
            // 
            this.Functionality.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Functionality.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.Functionality_openpipeline, this.Functionality_closepipeline, this.Functionality_openlogfile, this.Terminals});
            this.Functionality.Image = ((System.Drawing.Image) (resources.GetObject("Functionality.Image")));
            this.Functionality.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Functionality.Name = "Functionality";
            this.Functionality.Size = new System.Drawing.Size(101, 22);
            this.Functionality.Text = "Функционал🔨";
            // 
            // Functionality_openpipeline
            // 
            this.Functionality_openpipeline.Name = "Functionality_openpipeline";
            this.Functionality_openpipeline.Size = new System.Drawing.Size(179, 22);
            this.Functionality_openpipeline.Text = "Открыть канал";
            this.Functionality_openpipeline.Click += new System.EventHandler(this.Functionality_OpenPipeLine);
            // 
            // Functionality_closepipeline
            // 
            this.Functionality_closepipeline.Name = "Functionality_closepipeline";
            this.Functionality_closepipeline.Size = new System.Drawing.Size(179, 22);
            this.Functionality_closepipeline.Text = "Закрыть канал";
            this.Functionality_closepipeline.Click += new System.EventHandler(this.Functionality_ClosePipeLine);
            // 
            // Functionality_openlogfile
            // 
            this.Functionality_openlogfile.Name = "Functionality_openlogfile";
            this.Functionality_openlogfile.Size = new System.Drawing.Size(179, 22);
            this.Functionality_openlogfile.Text = "Открыть процессы";
            this.Functionality_openlogfile.Click += new System.EventHandler(this.Functionality_OpenLogFile);
            // 
            // Terminals
            // 
            this.Terminals.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.Terminals_linux, this.Terminals_windows});
            this.Terminals.Name = "Terminals";
            this.Terminals.Size = new System.Drawing.Size(179, 22);
            this.Terminals.Text = "Терминалы";
            // 
            // Terminals_linux
            // 
            this.Terminals_linux.Name = "Terminals_linux";
            this.Terminals_linux.Size = new System.Drawing.Size(123, 22);
            this.Terminals_linux.Text = "Linux";
            this.Terminals_linux.Click += new System.EventHandler(this.Terminals_linux_Click);
            // 
            // Terminals_windows
            // 
            this.Terminals_windows.Name = "Terminals_windows";
            this.Terminals_windows.Size = new System.Drawing.Size(123, 22);
            this.Terminals_windows.Text = "Windows";
            this.Terminals_windows.Click += new System.EventHandler(this.Terminals_windows_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(354, 381);
            this.Controls.Add(this.toolstrip);
            this.Controls.Add(this.gobutton);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.backbutton);
            this.Controls.Add(this.PathText);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Файловый Менеджер📁";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PipeLineClose);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEventHandler);
            this.ContextMenu1.ResumeLayout(false);
            this.ContextMenu2.ResumeLayout(false);
            this.toolstrip.ResumeLayout(false);
            this.toolstrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripMenuItem ContextMenu1_cleare;
        private System.Windows.Forms.ToolStripMenuItem ContextMenu2_cleare;

        private System.Windows.Forms.ToolStripMenuItem Terminals;
        private System.Windows.Forms.ToolStripMenuItem Terminals_linux;
        private System.Windows.Forms.ToolStripMenuItem Terminals_windows;

        private System.Windows.Forms.ToolStripDropDownButton Functionality;
        private System.Windows.Forms.ToolStripMenuItem Functionality_openpipeline;
        private System.Windows.Forms.ToolStripMenuItem Functionality_closepipeline;
        private System.Windows.Forms.ToolStripMenuItem Functionality_openlogfile;

        private System.Windows.Forms.ToolStripMenuItem Main_helpbutton;

        private System.Windows.Forms.ToolStripMenuItem Utilites_taskmanager;
        private System.Windows.Forms.ToolStripMenuItem Utilites_controlpanel;
        private System.Windows.Forms.ToolStripMenuItem Utilites_systembutton;

        private System.Windows.Forms.ToolStripDropDownButton Utilites;

        private System.Windows.Forms.ToolStripMenuItem Main_aboutbutton;

        private System.Windows.Forms.ToolStripDropDownButton Main;

        private System.Windows.Forms.ToolStrip toolstrip;
        
        private System.Windows.Forms.ToolStripMenuItem ContextMenu2_pastebutton;

        private System.Windows.Forms.ToolStripMenuItem ContextMenu1_pastebutton;

        private System.Windows.Forms.ToolStripMenuItem ContextMenu1_renamebutton;

        private System.Windows.Forms.ToolStripMenuItem ContextMenu1_cutbutton;

        private System.Windows.Forms.ToolStripMenuItem ContextMenu1_copybutton;

        private System.Windows.Forms.ContextMenuStrip ContextMenu2;
        private System.Windows.Forms.ToolStripMenuItem ContextMenu2_createbutton;

        private System.Windows.Forms.ToolStripMenuItem ContextMenu1_createbutton;
        private System.Windows.Forms.ToolStripMenuItem ContextMenu1_deletebutton;

        private System.Windows.Forms.Button gobutton;

        private System.Windows.Forms.ContextMenuStrip ContextMenu1;

        private System.Windows.Forms.ImageList imageList1;

        private System.Windows.Forms.ListView listView1;

        private System.Windows.Forms.TextBox PathText;
        private System.Windows.Forms.Button backbutton;

        #endregion
    }
}