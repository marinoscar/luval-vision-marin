using luval.vision.core;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.utils
{
    public class ImageConverter
    {

        private Arguments _args;
        private DirectoryInfo _source;
        private string _filter;
        private DirectoryInfo _destination;

        public ImageConverter(Arguments args)
        {
            _args = args;
        }

        public void ConvertDir()
        {
            ValidateDir();
            var files = _source.GetFiles(_filter, SearchOption.TopDirectoryOnly);
            var cnt = 1;
            foreach(var file in files)
            {
                ImageManager.ChangeFormat(file.FullName, _destination.FullName, ImageFormat.Jpeg, _args.GetMaxWidth());
                ConsoleHelper.ShowProgress(files.Length, cnt);
                cnt++;
            }

        }

        private void ValidateDir()
        {
            var ex = new LuvalException("Invalid parameters");
            if (_args.GetSourceDir() == null) throw ex;
            _source = new DirectoryInfo(_args.GetSourceDir());
            if (!_source.Exists) throw ex;
            _filter = _args.GetFilter() ?? "*.*";
            var des = _args.GetDestinationDir() ?? _source.FullName + @"Converted";
            _destination = new DirectoryInfo(des);
        }
    }
}
