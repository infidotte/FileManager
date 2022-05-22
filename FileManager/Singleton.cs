using System.IO;

namespace FileManager
{
    public class Singleton
    {
        #region All aplication variables
        private static Singleton instance;
        public string path;
        public string[] discs;
        public string localpath;
        private string trashpath;
        public bool iscopy;
        public DirectoryInfo copyinfo;
        public string dragitem;
        public string rename;
        public bool locker;
        #endregion
        

        public string gettrashpath()
        {
            return trashpath;
        }

        public void settrashpath(string path)
        {
            this.trashpath = path;
        }
        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
    }
}