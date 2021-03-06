﻿using pmis;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace pmis
{
    public class PicturePresenter
    {

        private MainWindow _form;
        private PictureViewerService _service;

        public PicturePresenter(MainWindow form, PictureViewerService service) {
            _form = form;
            _service = service;
        }

        public void LoadPictureDirectories()
        {
            _service.LoadDirectoryList();
            if (_service.Directories.Count > 0)
            {
                _form.PictureDirectoriesDS = _service.Directories.AsEnumerable();
            }
        }

        public void LoadPictureFiles(String dirPath)
        {
            _service.LoadImageList(dirPath);
            _form.PictureFilesDS = null;
            _form.PictureFilesDS = _service.Images.AsEnumerable();

            NextImage();
        }

        public void NextImage()
        {
            _form.ImageBox = null;
            _form.ImageBox = _service.NextImage();
        }

        public void PreviousImage()
        {
            _form.ImageBox = null;
            _form.ImageBox = _service.PreviousImage();
        }

        public void ShowImage(RegisterFile file)
        {
            _form.ImageBox = null;
            _form.ImageBox = _service.LoadImage(file);
        }
    }
}
