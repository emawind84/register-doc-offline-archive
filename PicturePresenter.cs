using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis
{
    public class PicturePresenter
    {

        public List<RegisterFile> Images;
        public Dictionary<string, string> Directories;
        private ArchiveMainForm _form;
        private int currentImage = -1;

        public EventHandler<RegisterFile> OnPictureSelected;

        public PicturePresenter(ArchiveMainForm form) {
            _form = form;
            Images = new List<RegisterFile>();

            Directories = new Dictionary<string, string>();
            try
            {
                string[] dirs = Directory.GetDirectories(
                Path.Combine(AppConfig.AppDataFullPath, Properties.Settings.Default.picture_folder_uri));
                foreach (string dir in dirs)
                {
                    Directories.Add(dir, new DirectoryInfo(dir).Name);
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                ex.Log();
            }
        }

        public void InitList(String path)
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
                Images.Add(new RegisterFile(fileName));
            }
            currentImage = -1;
            NextImage();

            ShowPictureFiles();
        }

        private void ShowPictureFiles()
        {
            _form.PictureFilesDS = null;
            _form.PictureFilesDS = Images;
        }

        public void NextImage()
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
                _form.ImageBox = Image.FromFile(Images[currentImage].FilePath);

                EventHandler<RegisterFile> handler = OnPictureSelected;
                if (handler != null)
                {
                    handler.Invoke(this, Images[currentImage]);
                }
            }
        }

        public void PreviousImage()
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
                _form.ImageBox = Image.FromFile(Images[currentImage].FilePath);

                EventHandler<RegisterFile> handler = OnPictureSelected;
                if (handler != null)
                {
                    handler.Invoke(this, Images[currentImage]);
                }
            }
        }
    }
}
