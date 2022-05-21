using System.IO;

namespace FileManager
{
    public class Singleton
    {
        private static Singleton instance;
        public string path;
        public string[] discs;
        public string localpath;
        private string trashpath = "C:\\FileManager\\Корзина";
        public bool iscopy;
        public DirectoryInfo copyinfo;
        public string dragitem;

        private Singleton()
        {
            
        }

        public string gettrashpath()
        {
            return trashpath;
        }
        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
    }
}