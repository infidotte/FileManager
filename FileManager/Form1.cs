using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Windows.Forms;

namespace FileManager
{
    public partial class Form1 : Form
    {
        private Singleton singleton = Program.singleton;

        public Form1()
        {
            InitializeComponent();
            getStartDirectory();
            singleton.settrashpath(FindPath("Корзина"));
            EventWatcherPolling thrd = new EventWatcherPolling();
        }

        #region Directory and Path methods

        //Выводит стартовую директорию
        private void getStartDirectory()
        {
            PathText.Text = "";
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

        //Устанавливает локальную путь (Путь выбранного элемента)
        private void setLocalPath(ListViewItem focusedItem)
        {
            if (singleton.discs.Contains(focusedItem.Text) || singleton.discs.Contains(singleton.path))
            {
                singleton.localpath = singleton.path + focusedItem.Text;
            }
            else
            {
                singleton.localpath = Path.Combine(singleton.path, focusedItem.Text);
            }
        }

        //Ищет нужную папку
        private string FindPath(string name)
        {
            foreach (var disc in DriveInfo.GetDrives())
            {
                foreach (var manag in Directory.GetDirectories(disc.Name, "FileManager"))
                {
                    foreach (var dirs in new DirectoryInfo(Path.Combine(disc.Name, manag)).GetDirectories(name,
                                 SearchOption.AllDirectories))
                    {
                        return dirs.FullName;
                    }
                }
            }

            return null;
        }

        #endregion

        //done

        #region ListView Methods

        //Происходит при активации элемента ListView(Double-Click)
        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem item = listView1.FocusedItem;

            if (singleton.path.Length > 3 &&
                new DriveInfo(singleton.path.Substring(0, 3)).DriveType == DriveType.Fixed &&
                item.Text.Equals("System"))
            {
                MessageBox.Show("No access!");
            }
            else
            {
                if (singleton.discs.Contains(item.Text) || singleton.discs.Contains(singleton.path))
                {
                    singleton.path += item.Text;
                }
                else
                {
                    singleton.path = Path.Combine(singleton.path, item.Text);
                }

                try
                {
                    DirectoryInfo info = new DirectoryInfo(singleton.path);
                    if ((info.Attributes & FileAttributes.Directory) == 0)
                    {
                        string way = singleton.path;
                        PathText.Text = singleton.path = Directory.GetParent(singleton.path).FullName;
                        Process.Start(way);
                    }
                    else
                    {
                        listView1.Clear();
                        PathText.Text = singleton.path;
                        getFilesAndDirs(info);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        //Происходит при отжатии правой кнопки мыши для вызова контекстных меню
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.SelectedItems.Count != 0 && listView1.FocusedItem.Bounds.Contains(e.Location))
                {
                    ListViewItem focus = listView1.FocusedItem;
                    setLocalPath(focus);

                    if (singleton.localpath.Length == 3)
                    {
                        if (new DriveInfo(singleton.localpath).DriveType == DriveType.Fixed)
                        {
                            ContextMenu1_deletebutton.Visible = false;
                            ContextMenu1_createbutton.Visible = false;
                            ContextMenu1_copybutton.Visible = false;
                            ContextMenu1_cutbutton.Visible = false;
                            ContextMenu1_renamebutton.Visible = false;
                            ContextMenu1_pastebutton.Visible = false;
                            ContextMenu1_clear.Visible = false;
                        }
                        else
                        {
                            ContextMenu1_deletebutton.Visible = false;
                            ContextMenu1_createbutton.Visible = true;
                            ContextMenu1_copybutton.Visible = false;
                            ContextMenu1_cutbutton.Visible = false;
                            ContextMenu1_renamebutton.Visible = false;
                            ContextMenu1_pastebutton.Visible = true;
                            ContextMenu1_clear.Visible = false;
                        }
                    }
                    else if (new DriveInfo(singleton.localpath.Substring(0, 3)).DriveType == DriveType.Fixed &&
                             singleton.localpath.Contains("System"))
                    {
                        ContextMenu1_deletebutton.Visible = false;
                        ContextMenu1_createbutton.Visible = false;
                        ContextMenu1_copybutton.Visible = false;
                        ContextMenu1_cutbutton.Visible = false;
                        ContextMenu1_renamebutton.Visible = false;
                        ContextMenu1_pastebutton.Visible = false;
                        ContextMenu1_clear.Visible = false;
                    }
                    else if (focus.Text == "Корзина")
                    {
                        ContextMenu1_deletebutton.Visible = false;
                        ContextMenu1_createbutton.Visible = true;
                        ContextMenu1_copybutton.Visible = false;
                        ContextMenu1_cutbutton.Visible = false;
                        ContextMenu1_renamebutton.Visible = false;
                        ContextMenu1_pastebutton.Visible = true;
                        ContextMenu1_clear.Visible = true;
                    }

                    else if (singleton.localpath.Split('\\').Length == 2 &&
                             singleton.localpath.Split('\\')[1].Equals("FileManager"))
                    {
                        ContextMenu1_deletebutton.Visible = false;
                        ContextMenu1_createbutton.Visible = true;
                        ContextMenu1_copybutton.Visible = false;
                        ContextMenu1_cutbutton.Visible = false;
                        ContextMenu1_renamebutton.Visible = false;
                        ContextMenu1_pastebutton.Visible = true;
                        ContextMenu1_clear.Visible = false;
                    }
                    else if ((new DirectoryInfo(singleton.localpath).Attributes & FileAttributes.Directory) == 0)
                    {
                        ContextMenu1_deletebutton.Visible = true;
                        ContextMenu1_createbutton.Visible = false;
                        ContextMenu1_copybutton.Visible = true;
                        ContextMenu1_cutbutton.Visible = true;
                        ContextMenu1_renamebutton.Visible = true;
                        ContextMenu1_pastebutton.Visible = false;
                        ContextMenu1_clear.Visible = false;
                    }
                    else
                    {
                        ContextMenu1_deletebutton.Visible = true;
                        ContextMenu1_createbutton.Visible = true;
                        ContextMenu1_copybutton.Visible = true;
                        ContextMenu1_cutbutton.Visible = true;
                        ContextMenu1_renamebutton.Visible = true;
                        ContextMenu1_pastebutton.Visible = true;
                        ContextMenu1_clear.Visible = false;
                    }

                    ContextMenu1.Show(Cursor.Position);
                }
                else
                {
                    if (singleton.path.Equals(""))
                    {
                        ContextMenu2_createbutton.Visible = false;
                        ContextMenu2_pastebutton.Visible = false;
                        ContextMenu2_clear.Visible = false;
                    }
                    else if (singleton.path.Length == 3)
                    {
                        if (new DriveInfo(singleton.path.Substring(0, 3)).DriveType == DriveType.Fixed)
                        {
                            ContextMenu2_createbutton.Visible = false;
                            ContextMenu2_pastebutton.Visible = false;
                            ContextMenu2_clear.Visible = false;
                        }
                        else
                        {
                            ContextMenu2_createbutton.Visible = true;
                            ContextMenu2_pastebutton.Visible = true;
                            ContextMenu2_clear.Visible = false;
                        }
                    }
                    else if (new DriveInfo(singleton.path.Substring(0, 3)).DriveType == DriveType.Fixed &&
                             singleton.path.Contains("System"))
                    {
                        ContextMenu2_createbutton.Visible = false;
                        ContextMenu2_pastebutton.Visible = false;
                        ContextMenu2_clear.Visible = false;
                    }
                    else if (singleton.path.Equals(singleton.gettrashpath()))
                    {
                        ContextMenu2_createbutton.Visible = true;
                        ContextMenu2_pastebutton.Visible = true;
                        ContextMenu2_clear.Visible = true;
                    }
                    else
                    {
                        ContextMenu2_createbutton.Visible = true;
                        ContextMenu2_pastebutton.Visible = true;
                        ContextMenu2_clear.Visible = false;
                    }

                    ContextMenu2.Show(Cursor.Position);
                }
            }
        }

        #endregion //

//done

        #region Back and Go buttons ( "<" & ">" )

        //Происходит при нажатии кнопки Назад ("<")
        private void OnBackButtonClick(object sender, EventArgs e)
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
                PathText.Text = singleton.path = info.FullName;
                getFilesAndDirs(info);
            }
        }

        //Происходит при нажатии кнопки Вперед(">")
        private void onGoButtonClick(object sender, EventArgs e)
        {
            singleton.path = PathText.Text;
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

        #endregion

//done

        #region Get files and directorys methods

        //Получает файлы и дериктории 
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

        #endregion

//done

        #region Context Menu Methods

        private void ContextMenu1_CreateButton(object sender, EventArgs e)
        {
            PathText.Text = singleton.path;
            CreateFile cf = new CreateFile(Cursor.Position, singleton.localpath);
            cf.ShowDialog();
            listView1.Clear();
            DirectoryInfo info = new DirectoryInfo(singleton.path);
            getFilesAndDirs(info);
        }

        private void ContextMenu1_DeleteButton(object sender, EventArgs e)
        {
            DeleteFile df = new DeleteFile(Cursor.Position, singleton.localpath, singleton.gettrashpath());
            df.ShowDialog();
            listView1.Clear();
            DirectoryInfo info = new DirectoryInfo(singleton.path);
            getFilesAndDirs(info);
        }

        private void ContextMenu2_CreateButton(object sender, EventArgs e)
        {
            PathText.Text = singleton.path;
            CreateFile cf = new CreateFile(Cursor.Position, singleton.path);
            cf.ShowDialog();
            listView1.Clear();
            DirectoryInfo info = new DirectoryInfo(singleton.path);
            getFilesAndDirs(info);
        }

        private void ContextMenu1_CopyButton(object sender, EventArgs e)
        {
            singleton.copyinfo = new DirectoryInfo(singleton.localpath);
            singleton.iscopy = true;
        }

        private void ContextMenu1_CutButton(object sender, EventArgs e)
        {
            singleton.copyinfo = new DirectoryInfo(singleton.localpath);
            singleton.iscopy = false;
        }

        private void ContextMenu1_RenameButton(object sender, EventArgs e)
        {
            DirectoryInfo info = new DirectoryInfo(singleton.localpath);
            Rename rename = new Rename(Cursor.Position, info);
            rename.ShowDialog();
            listView1.Clear();
            DirectoryInfo info1 = new DirectoryInfo(singleton.path);
            getFilesAndDirs(info1);
            if (singleton.locker)
            {
                PipeLineWriter(info.Name + " переименован в -> " + singleton.rename + " в: " + DateTime.Now +
                               " по местному времени");
            }
        }

        private void ContextMenu1_PasteButton(object sender, EventArgs e)
        {
            DirectoryInfo info = new DirectoryInfo(singleton.path);
            DirectoryInfo local = new DirectoryInfo(singleton.localpath);
            PasteDirectory(local);
            listView1.Clear();
            getFilesAndDirs(info);
        }

        private void ContextMenu1_clear_Click(object sender, EventArgs e)
        {
            if (singleton.localpath.Equals(singleton.gettrashpath()))
            {
                DirectoryInfo info = new DirectoryInfo(singleton.localpath);
                foreach (var dirs in info.GetDirectories())
                {
                    try
                    {
                        dirs.Delete(true);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }

                foreach (var file in info.GetFiles())
                {
                    try
                    {
                        file.Delete();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void ContextMenu2_clear_Click(object sender, EventArgs e)
        {
            if (singleton.path.Equals(singleton.gettrashpath()))
            {
                DirectoryInfo info = new DirectoryInfo(singleton.path);
                foreach (var dirs in info.GetDirectories())
                {
                    try
                    {
                        dirs.Delete(true);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }

                foreach (var file in info.GetFiles())
                {
                    try
                    {
                        file.Delete();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }

                listView1.Clear();
                getFilesAndDirs(info);
            }
        }

        private void ContextMenu2_PasteButton(object sender, EventArgs e)
        {
            DirectoryInfo info = new DirectoryInfo(singleton.path);
            PasteDirectory(info);
            listView1.Clear();
            getFilesAndDirs(info);
        }

        private void PasteDirectory(DirectoryInfo local)
        {
            DirectoryInfo info = singleton.copyinfo;
            if ((info.Attributes & FileAttributes.Directory) != 0)
            {
                //dir
                if (singleton.iscopy)
                {
                    try
                    {
                        Directory.CreateDirectory(local.FullName + "\\" + info.Name);
                        DirectoryInfo destinfo = new DirectoryInfo(local.FullName + "\\" + info.Name);
                        CopyDirectory(info.FullName, destinfo.FullName, true);
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
                        Directory.Move(info.FullName, local.FullName + "\\" + info.Name);
                        //cut
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
            else
            {
                //file
                if (singleton.iscopy)
                {
                    try
                    {
                        File.Copy(info.FullName, local.FullName + "\\" + info.Name);
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
                        File.Move(info.FullName, local.FullName + "\\" + info.Name);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }

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

        #endregion

        //done

        #region Main and Utilits

        private void Main_About(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Операционные системы и оболочки\nЯзык программирования: C#\nЕвдокимов Денис Вячеславович\nРПИС-03");
        }

        private void Main_Help(object sender, EventArgs e)
        {
            Process.Start("readme.txt");
        }

        private void Utilits_TaskManager(object sender, EventArgs e)
        {
            Process.Start("Taskmgr.exe");
        }

        private void Utilits_ControlPanel(object sender, EventArgs e)
        {
            Process.Start("control");
        }

        private void Utilits_System(object sender, EventArgs e)
        {
            Process.Start("msinfo32");
        }

        #endregion
//done
        #region override methods

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
                        if (singleton.path.Length >= 3 && new DriveInfo(singleton.path.Substring(0, 3)).DriveType != DriveType.Fixed)
                            getStartDirectory();
                        break;
                }
            }
        }

        #endregion
//done
        #region HotKeys

        private void KeyDownEventHandler(object sender, KeyEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                if (e.Control && e.KeyCode == Keys.V)
                {
                    ContextMenu2_PasteButton(sender, e);
                    // Stops other controls on the form receiving event.
                    e.SuppressKeyPress = true;
                }
            }
            else
            {
                if (e.Control && e.KeyCode == Keys.C)
                {
                    ContextMenu1_CopyButton(sender, e);
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    ContextMenu1_PasteButton(sender, e);
                }
                else if (e.Control && e.KeyCode == Keys.X)
                {
                    ContextMenu1_CutButton(sender, e);
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    ContextMenu1_DeleteButton(sender, e);
                }
                else if (e.Control && e.KeyCode == Keys.R)
                {
                    ContextMenu1_RenameButton(sender, e);
                }
            }
        }

        #endregion
        //done
        #region Drag&Drop

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

        #endregion

        #region PipeLine

        private void PipeLineWriter(string message)
        {
            NamedPipeServerStream pipeLineServer = new NamedPipeServerStream("pipeLine", PipeDirection.Out);
            pipeLineServer.WaitForConnection();
            if (pipeLineServer.IsConnected)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(pipeLineServer))
                    {
                        writer.WriteLine(message);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void PipeLineClose(object sender, FormClosedEventArgs e)
        {
            if (singleton.locker)
            {
                PipeLineWriter("Close");
            }
        }

        #endregion

        #region Functionality

        private void Functionality_OpenPipeLine(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(FindPath("Loging"), "bin\\Debug\\Loging.exe"));
            singleton.locker = true;
        }

        private void Functionality_ClosePipeLine(object sender, EventArgs e)
        {
            PipeLineWriter("Close");
            singleton.locker = false;
        }

        private void Functionality_OpenLogFile(object sender, EventArgs e)
        {
            Process.Start("logfile.txt");
        }

        private void Terminals_linux_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(FindPath("LinuxTerminal"), "bin\\Debug\\LinuxTerminal.exe"));
        }

        private void Terminals_windows_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(FindPath("WinTerminal"), "bin\\Debug\\WinTerminal.exe"));
        }

        #endregion
    }
}