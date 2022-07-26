using System.IO;


namespace Mvc.Services.HitCounter
{
    public class HitCounter : IHitCounter
    {
        private string rootPath;


        public HitCounter(string path)
        {
            rootPath = path;
        }


        public int UpdateCount()
        {
            string filePath = "\\hitcount.txt";
            string fullPath = string.Concat(rootPath, filePath);

            if (!File.Exists(fullPath))
            {
                File.WriteAllText(fullPath, "0");
                return 0;
            }

            int count = int.Parse(File.ReadAllText(fullPath));
            count++;
            File.WriteAllText(fullPath, count.ToString());

            return count;
        }
    }
}
