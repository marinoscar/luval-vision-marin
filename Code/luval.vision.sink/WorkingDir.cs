using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.sink
{
    public static class WorkingDir
    {
        private static DirectoryInfo _imageDir { get; set; }
        private static DirectoryInfo _processedDir { get; set; }
        private static DirectoryInfo _resultDir { get; set; }
        private static DirectoryInfo _skippedDir { get; set; }

        private static void LoadAll()
        {
            if (!(_imageDir == null || _processedDir == null || _resultDir == null || _skippedDir == null))
                return;
            var dir = ConfigurationManager.AppSettings["workingFolder"];
            if (string.IsNullOrWhiteSpace(dir))
            {
                dir = Environment.CurrentDirectory;
            }
            _imageDir = new DirectoryInfo(dir);
            _processedDir = new DirectoryInfo(_imageDir.FullName + @"\Processed");
            _resultDir = new DirectoryInfo(_imageDir.FullName + @"\Result");
            _skippedDir = new DirectoryInfo(_imageDir.FullName + @"\Skipped");
            CheckAndCreate(_processedDir);
            CheckAndCreate(_resultDir);
            CheckAndCreate(_skippedDir);

        }
        private static void CheckAndCreate(DirectoryInfo dir)
        {
            if (!dir.Exists) dir.Create();
        }


        public static DirectoryInfo Image
        {
            get
            {
                LoadAll();
                return _imageDir;
            }
        }

        public static DirectoryInfo Processed
        {
            get
            {
                LoadAll();
                return _processedDir;
            }
        }

        public static DirectoryInfo Result
        {
            get
            {
                LoadAll();
                return _resultDir;
            }
        }

        public static DirectoryInfo Skipped
        {
            get
            {
                LoadAll();
                return _skippedDir;
            }
        }

        public static void MoveToProcessed(string fileName)
        {
            var file = new FileInfo(fileName);
            File.Move(string.Format(@"{0}\{1}", Image.FullName, fileName), string.Format(@"{0}\{1}", Processed, file.Name));
        }

        public static void MoveToSkipped(string fileName)
        {
            var file = new FileInfo(fileName);
            File.Move(string.Format(@"{0}\{1}", Image.FullName, fileName), string.Format(@"{0}\{1}", Skipped, file.Name));
        }
    }
}
