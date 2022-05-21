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
using System.Runtime.CompilerServices;
using System.Threading;

namespace FileManager
{
    public partial class Form1 : Form
    {
        private Singleton singleton = Program.singleton;

        public Form1()
        {
            InitializeComponent();
            getStartDirectory();
            Thread tr = new Thread(thread);
        }


        private void thread()
        {
            while (true)
            {
                label1.Text = singleton.path;
                label2.Text = singleton.localpath;
                Thread.Sleep(2000);
            }
        }

        private void getStartDirectory()
        {
            textBox1.Text = "";

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

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];

            if (singleton.discs.Contains(item.Text) || singleton.discs.Contains(singleton.path))
            {
                singleton.path += item.Text;
            }
            else
            {
                singleton.path += "\\" + item.Text;
            }


            try
            {
                DirectoryInfo info = new DirectoryInfo(singleton.path);
                if ((info.Attributes & FileAttributes.Directory) == 0)
                {
                    string way = singleton.path;
                    textBox1.Text = singleton.path = Directory.GetParent(singleton.path).FullName;
                    Process.Start(way);
                }
                else
                {
                    listView1.Clear();
                    textBox1.Text = singleton.path;
                    getFilesAndDirs(info);
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

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                label1.Text = singleton.path;
                label2.Text = singleton.localpath;
                if (listView1.SelectedItems.Count != 0 && listView1.FocusedItem.Bounds.Contains(e.Location))
                {
                    ListViewItem focus = listView1.FocusedItem;
                    setLocalPath(focus);

                    if (singleton.localpath.Length == 3)
                    {
                        if (new DriveInfo(singleton.localpath).DriveType == DriveType.Fixed)
                        {
                            deleteToolStripMenuItem.Visible = false;
                            createToolStripMenuItem.Visible = false;
                            copyToolStripMenuItem.Visible = false;
                            cutToolStripMenuItem.Visible = false;
                            reanameToolStripMenuItem.Visible = false;
                            pasteToolStripMenuItem.Visible = false;
                        }
                        else
                        {
                            deleteToolStripMenuItem.Visible = false;
                            createToolStripMenuItem.Visible = true;
                            copyToolStripMenuItem.Visible = false;
                            cutToolStripMenuItem.Visible = false;
                            reanameToolStripMenuItem.Visible = false;
                            pasteToolStripMenuItem.Visible = true;
                        }
                    }
                    else if (new DriveInfo(singleton.localpath.Substring(0, 3)).DriveType == DriveType.Fixed &&
                             singleton.localpath.Contains("System"))
                    {
                        deleteToolStripMenuItem.Visible = false;
                        createToolStripMenuItem.Visible = false;
                        copyToolStripMenuItem.Visible = false;
                        cutToolStripMenuItem.Visible = false;
                        reanameToolStripMenuItem.Visible = false;
                        pasteToolStripMenuItem.Visible = false;
                    }
                    else if (focus.Text == "Корзина")
                    {
                        deleteToolStripMenuItem.Visible = false;
                        createToolStripMenuItem.Visible = true;
                        copyToolStripMenuItem.Visible = false;
                        cutToolStripMenuItem.Visible = false;
                        reanameToolStripMenuItem.Visible = false;
                        pasteToolStripMenuItem.Visible = true;
                    }

                    else if (singleton.localpath.Split('\\').Length == 2 &&
                             singleton.localpath.Split('\\')[1].Equals("FileManager"))
                    {
                        deleteToolStripMenuItem.Visible = false;
                        createToolStripMenuItem.Visible = false;
                        copyToolStripMenuItem.Visible = false;
                        cutToolStripMenuItem.Visible = false;
                        reanameToolStripMenuItem.Visible = false;
                        pasteToolStripMenuItem.Visible = true;
                    }
                    else if ((new DirectoryInfo(singleton.localpath).Attributes & FileAttributes.Directory) == 0)
                    {
                        deleteToolStripMenuItem.Visible = true;
                        createToolStripMenuItem.Visible = false;
                        copyToolStripMenuItem.Visible = true;
                        cutToolStripMenuItem.Visible = true;
                        reanameToolStripMenuItem.Visible = true;
                        pasteToolStripMenuItem.Visible = false;
                    }
                    else
                    {
                        deleteToolStripMenuItem.Visible = true;
                        createToolStripMenuItem.Visible = true;
                        copyToolStripMenuItem.Visible = true;
                        cutToolStripMenuItem.Visible = true;
                        reanameToolStripMenuItem.Visible = true;
                        pasteToolStripMenuItem.Visible = true;
                    }

                    contextMenuStrip1.Show(Cursor.Position);
                }
                else
                {
                    if (singleton.path.Equals(""))
                    {
                        createtoolStripMenu2Item.Visible = false;
                        pasteToolStripMenuItem1.Visible = false;
                    }
                    else if (singleton.path.Length == 3)
                    {
                        if (new DriveInfo(singleton.path.Substring(0, 3)).DriveType == DriveType.Fixed)
                        {
                            createtoolStripMenu2Item.Visible = false;
                            pasteToolStripMenuItem1.Visible = false;
                        }
                        else
                        {
                            createtoolStripMenu2Item.Visible = true;
                            pasteToolStripMenuItem1.Visible = true;
                        }
                    }
                    else if (new DriveInfo(singleton.path.Substring(0, 3)).DriveType != DriveType.Fixed)
                    {
                        createtoolStripMenu2Item.Visible = true;
                        pasteToolStripMenuItem1.Visible = true;
                    }
                    else if (new DriveInfo(singleton.path.Substring(0, 3)).DriveType == DriveType.Fixed &&
                             singleton.path.Contains("System"))
                    {
                        createtoolStripMenu2Item.Visible = false;
                        pasteToolStripMenuItem1.Visible = false;
                    }
                    else
                    {
                        createtoolStripMenu2Item.Visible = true;
                        pasteToolStripMenuItem1.Visible = true;
                    }

                    contextMenuStrip2.Show(Cursor.Position);
                }
            }
        }

        private void getFilesAndDirs(DirectoryInfo info)
        {
            if (singleton.discs.Contains(singleton.path) && new DriveInfo(singleton.path).DriveType == DriveType.Fixed)
            {
                foreach (var i in info.GetDirectories())
                {
                    if (i.Name.Equals("FileManager"))
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
            textBox1.Text = singleton.path;
            CreateFile cf = new CreateFile(Cursor.Position, singleton.localpath);
            cf.ShowDialog();
            listView1.Clear();
            DirectoryInfo info = new DirectoryInfo(singleton.path);
            getFilesAndDirs(info);
        }

        private void DeleteToolStripMenuItemOnClick(object sender, EventArgs e)
        {
            DeleteFile df = new DeleteFile(Cursor.Position, singleton.localpath, singleton.gettrashpath());
            df.ShowDialog();
            listView1.Clear();
            DirectoryInfo info = new DirectoryInfo(singleton.path);
            getFilesAndDirs(info);
        }

        private void CreateToolStripMenuItemOnClickEmpty(object sender, EventArgs e)
        {
            textBox1.Text = singleton.path;
            CreateFile cf = new CreateFile(Cursor.Position, singleton.path);
            cf.ShowDialog();
            listView1.Clear();
            DirectoryInfo info = new DirectoryInfo(singleton.path);
            getFilesAndDirs(info);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView1.FocusedItem;
            setLocalPath(item);

            singleton.copyinfo = new DirectoryInfo(singleton.localpath);
            singleton.iscopy = true;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView1.FocusedItem;
            setLocalPath(item);
            singleton.copyinfo = new DirectoryInfo(singleton.localpath);
            singleton.iscopy = false;
        }

        private void reanameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView1.FocusedItem;
            setLocalPath(item);
            DirectoryInfo info = new DirectoryInfo(singleton.localpath);
            Rename rename = new Rename(Cursor.Position, info);
            label3.Text = info.Name;
            rename.ShowDialog();
            listView1.Clear();
            DirectoryInfo info1 = new DirectoryInfo(singleton.path);
            getFilesAndDirs(info1);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView1.FocusedItem;
            setLocalPath(item);
            DirectoryInfo info = new DirectoryInfo(singleton.path);
            DirectoryInfo local = new DirectoryInfo(singleton.localpath);
            paste(local);
            listView1.Clear();
            getFilesAndDirs(info);
        }

        private void paste(DirectoryInfo local1)
        {
            DirectoryInfo info = singleton.copyinfo;
            DirectoryInfo local = local1;
            if ((info.Attributes & FileAttributes.Directory) != 0)
            {
                //dir
                if (singleton.iscopy)
                {
                    Directory.CreateDirectory(local.FullName + "\\" + info.Name);
                    DirectoryInfo destinfo = new DirectoryInfo(local.FullName + "\\" + info.Name);
                    CopyDirectory(info.FullName, destinfo.FullName, true);
                }
                else
                {
                    Directory.Move(info.FullName, local.FullName + "\\" + info.Name);
                    //cut
                }
            }
            else
            {
                //file
                if (singleton.iscopy)
                {
                    File.Copy(info.FullName, local.FullName + "\\" + info.Name);
                }
                else
                {
                    File.Move(info.FullName, local.FullName + "\\" + info.Name);
                    //cut
                }
            }
        }

        private void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DirectoryInfo info = new DirectoryInfo(singleton.path);
            paste(info);
            listView1.Clear();
            getFilesAndDirs(info);
        }

        #region Utilits

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Операционные системы и оболочки\nЯзык программирования: C#\nЕвдокимов Денис Вячеславович\nРПИС-03");
        }

        private void windowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("cmd");
        }

        private void диспетчерЗадачToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("Taskmgr.exe");
        }

        private void панельУправленияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("control");
        }

        private void оСистемеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("msinfo32");
        }

        #endregion


        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            const int WM_DEVICECHANGE = 0x219;
            const int DBT_DEVICEARRIVAL = 0x8000; //connect
            const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
            if (m.Msg == WM_DEVICECHANGE)
            {
                switch ((int) m.WParam)
                {
                    case DBT_DEVICEARRIVAL:
                        if (singleton.path.Equals(""))
                        {
                            getStartDirectory();
                        }

                        break;
                    case DBT_DEVICEREMOVECOMPLETE:
                        getStartDirectory();
                        break;
                }
            }
        }

        private void KeyDownEventHandler(object sender, KeyEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                if (e.Control && e.KeyCode == Keys.V)
                {
                    pasteToolStripMenuItem1_Click(sender, e);
                    e.SuppressKeyPress = true; // Stops other controls on the form receiving event.
                }
            }
            else
            {
                if (e.Control && e.KeyCode == Keys.C)
                {
                    copyToolStripMenuItem_Click(sender, e);
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    pasteToolStripMenuItem_Click(sender, e);
                }
                else if (e.Control && e.KeyCode == Keys.X)
                {
                    cutToolStripMenuItem_Click(sender, e);
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    DeleteToolStripMenuItemOnClick(sender, e);
                }
                else if (e.Control && e.KeyCode == Keys.R)
                {
                    reanameToolStripMenuItem_Click(sender, e);
                }
            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("readme.txt");
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ListViewItem itemdrag = listView1.FocusedItem;
            setLocalPath(itemdrag);
            if (singleton.localpath.Length == 3)
            {
                if (new DriveInfo(singleton.localpath).DriveType == DriveType.Fixed)
                {
                    MessageBox.Show("No access!");
                }
                else
                {
                    MessageBox.Show("No access!");
                }
            }
            else if (new DriveInfo(singleton.localpath.Substring(0, 3)).DriveType == DriveType.Fixed &&
                     singleton.localpath.Contains("System"))
            {
                MessageBox.Show("No access!");
            }
            else if (itemdrag.Text == "Корзина")
            {
                MessageBox.Show("No access!");
            }

            else if (singleton.localpath.Split('\\').Length == 2 &&
                     singleton.localpath.Split('\\')[1].Equals("FileManager"))
            {
                MessageBox.Show("No access!");
            }
            else
            {
                singleton.dragitem = singleton.localpath;
                listView1.DoDragDrop(itemdrag, DragDropEffects.Move);
            }
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];
            setLocalPath(item);
            DirectoryInfo targetinfo = new DirectoryInfo(singleton.localpath);
            DirectoryInfo dragedinfo = new DirectoryInfo(singleton.dragitem);
            if ((targetinfo.Attributes & FileAttributes.Directory) != 0)
            {
                if ((dragedinfo.Attributes & FileAttributes.Directory) != 0)
                {
                    try
                    {
                        Directory.Move(dragedinfo.FullName, Path.Combine(targetinfo.FullName, dragedinfo.Name));
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                else
                {
                    try
                    {
                        File.Move(dragedinfo.FullName, Path.Combine(targetinfo.FullName, dragedinfo.Name));
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }

            listView1.Clear();
            getFilesAndDirs(new DirectoryInfo(singleton.path));
        }

        private void listView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            ListViewItem dragover = listView1.HitTest(listView1.PointToClient(new Point(e.X, e.Y))).Item;
            dragover.Selected = true;
        }
    }
}