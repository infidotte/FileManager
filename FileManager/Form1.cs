using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace FileManager
{
    public partial class Form1 : Form
    {
        private Singleton singleton = Program.singleton;

        public Form1()
        {
            InitializeComponent();
            getStartDirectory();
        }

        private void getStartDirectory()
        {
            textBox1.Text = "";
            lock (singleton)
            {
                singleton.path = "";
                singleton.discs = Environment.GetLogicalDrives();
                listView1.Clear();
                foreach (string i in singleton.discs)
                {
                    if (new DriveInfo(i).DriveType == DriveType.Fixed)
                    {
                        listView1.Items.Add(i, 0);
                    }
                    else
                    {
                        listView1.Items.Add(i, 3);
                    }
                    
                }
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];
            lock (singleton)
            {
                if (singleton.discs.Contains(item.Text) || singleton.discs.Contains(singleton.path))
                {
                    singleton.path += item.Text;
                }
                else
                {
                    singleton.path += "\\" + item.Text;
                }
            }

            try
            {
                DirectoryInfo info = new DirectoryInfo(singleton.path);
                if ((info.Attributes & FileAttributes.Directory) == 0)
                {
                    lock (singleton)
                    {
                        Process.Start(singleton.path);
                        textBox1.Text = singleton.path = Directory.GetParent(singleton.path).FullName;
                    }
                }
                else
                {
                    lock (singleton)
                    {
                        listView1.Clear();
                        textBox1.Text = singleton.path;
                        getFilesAndDirs(info);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            lock (singleton)
            {
                if (singleton.discs.Contains(singleton.path))
                {
                    getStartDirectory();
                }
                else if (singleton.path.Equals(""))
                {
                    getStartDirectory();
                }
                else if (!Directory.Exists(singleton.path))
                {
                    getStartDirectory();
                }
                else
                {
                    DirectoryInfo info = Directory.GetParent(singleton.path);
                    textBox1.Text = singleton.path = info.FullName;
                    getFilesAndDirs(info);
                }
            }
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.SelectedItems.Count != 0 && listView1.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
                else
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void getFilesAndDirs(DirectoryInfo info)
        {
            if (singleton.discs.Contains(singleton.path) && new DriveInfo(singleton.path).DriveType == DriveType.Fixed)
            {
                foreach (var i in info.GetDirectories())
                {
                    if (i.Name.Equals("FileManager") )
                    {
                        listView1.Items.Add(i.Name, 1);
                    }
                }
            }
            else
            {
                gFaD(info);
            }
        }

        private void gFaD(DirectoryInfo info)
        {
            foreach (DirectoryInfo i in info.GetDirectories())
            {
                if ((i.Attributes & FileAttributes.Directory) != 0)
                {
                    listView1.Items.Add(i.Name, 1);
                }
            }

            foreach (FileInfo i in info.GetFiles())
            {
                if ((i.Attributes & FileAttributes.Hidden) == 0 || (i.Attributes & FileAttributes.System) == 0)
                {
                    listView1.Items.Add(i.Name, 2);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            singleton.path = textBox1.Text;
            if (Directory.Exists(singleton.path))
            {
                DirectoryInfo info = new DirectoryInfo(singleton.path);
                listView1.Clear();
                getFilesAndDirs(info);
            }
            else
            {
                MessageBox.Show("Wrong way!");
            }
        }

        private void setLocalPath(ListViewItem focusedItem)
        {
            if (singleton.discs.Contains(focusedItem.Text) || singleton.discs.Contains(singleton.path))
            {
                singleton.localpath = singleton.path + focusedItem.Text;
            }
            else
            {
                singleton.localpath = singleton.path + "\\" + focusedItem.Text;
            }
        }

        private void CreateToolStripMenuItemOnClick(object sender, EventArgs e)
        {
            var focusedItem = listView1.FocusedItem;
            setLocalPath(focusedItem);
            label2.Text = singleton.localpath;
            CreateFile cf = new CreateFile();
            cf.Show();
        }

        private void DeleteToolStripMenuItemOnClick(object sender, EventArgs e)
        {
            ListViewItem focus = listView1.FocusedItem;
            setLocalPath(focus);
            DeleteFile df = new DeleteFile();
            df.Show();
            DirectoryInfo info1 = new DirectoryInfo(singleton.path);
            listView1.Clear();
            getFilesAndDirs(info1);
        }
    }
}