namespace FileManager
{
    public class Singleton
    {
        private static Singleton instance;
        public string path;
        public string[] discs;
        public string localpath;
        private string trashpath = "C:\\FileManager\\Корзина";

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