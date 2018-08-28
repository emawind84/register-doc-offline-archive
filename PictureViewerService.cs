using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;
using System.Linq;

namespace pmis
{
    public class PictureViewerService
    {
        public List<RegisterFile> Images;
        public IEnumerable<KeyValuePair<string, string>> Directories;
        public EventHandler<RegisterFile> OnPictureSelected;

        private int currentImage = -1;
        private string pattern = @"^.*\.(jpg|gif|png|bmp|jpeg|tiff)$";

        public PictureViewerService() {
            Images = new List<RegisterFile>();

            LoadDirectoryList();
        }

        public IEnumerable<KeyValuePair<string, string>> LoadDirectoryList()
        {
            Dictionary<string, string> _d = new Dictionary<string, string>();
            try
            {
                string[] dirs = Directory.GetDirectories(
                Path.Combine(AppConfig.AppDataFullPath, Properties.Settings.Default.picture_folder_uri));
                foreach (string dir in dirs)
                {
                    _d.Add(dir, new DirectoryInfo(dir).Name);
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                ex.Log();
            }

            // we order the collection by directory name
            // @seemore https://www.dotnetperls.com/sort-dictionary
            Directories = from entry in _d orderby entry.Value ascending select entry;

            return Directories;
        }

        public void LoadImageList(String path)
        {
            string imageDirectory = path;
            string[] files = new string[0];
            try
            {
                LogUtil.Log(String.Format("Looking for files... {0}", imageDirectory));
                files = Directory.GetFiles(imageDirectory);
            }
            catch (DirectoryNotFoundException ex)
            {
                ex.Log();
            }

            Images.Clear();
            foreach (string fileName in files)
            {
                Match result = Regex.Match(fileName, pattern, RegexOptions.IgnoreCase);
                if (result.Success)
                {
                    Images.Add(new RegisterFile(fileName));
                }
            }
            currentImage = -1;
        }

        public BitmapImage NextImage()
        {
            if (Images.Count != 0)
            {
                if (Images.Count - 1 > currentImage)
                {
                    currentImage++;
                }
                else
                {
                    currentImage = 0;
                }
                
                return LoadImage(Images[currentImage]);
            }

            return null;
        }

        public BitmapImage PreviousImage()
        {
            if (Images.Count != 0)
            {
                if (currentImage > 0)
                {
                    currentImage--;
                }
                else
                {
                    currentImage = Images.Count - 1;
                }
                
                return LoadImage(Images[currentImage]);
            }

            return null;
        }

        public BitmapImage LoadImage(RegisterFile image)
        {
            var _source = new Uri(image.FilePath);
            var _bi = new BitmapImage();
            _bi.BeginInit();
            _bi.UriSource = _source;
            _bi.EndInit();

            EventHandler<RegisterFile> handler = OnPictureSelected;
            if (handler != null)
            {
                handler.Invoke(this, image);
            }

            return _bi;
        }

    }
}
