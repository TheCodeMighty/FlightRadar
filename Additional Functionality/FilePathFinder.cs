namespace OOD_Project1
{
    public static class FilePathFinder
    {
        public static string FindFilePath(string fileName)
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(dir, fileName);
            return filePath;
        }
    }
}
