using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using PictureGalleryApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PictureGalleryApp.ViewModel
{
    public class AlbumWindowViewModel : ViewModelBase
    {
        public ICommand AddPicture { get; set; }
        public ICommand BrowsePicture { get; set; }

        private PictureModel _pictureBindingModel;
        private string _albumId;

        public PictureModel PictureBindingModel
        {
            get { return _pictureBindingModel; }
            set
            {
                Set(ref _pictureBindingModel, value);
            }
        }

        public AlbumWindowViewModel()
        {
            AddPicture = new RelayCommand(AddPictureToServer);
            BrowsePicture = new RelayCommand(BrowsePictureDialog);
            PictureBindingModel = new PictureModel() { Name="Hello", Date = DateTime.Now, Tags="asgj i;sdga", Raiting = 4.9};
        }

        public void SetAlbumId(string id)
        {
            _albumId = id;
        }

        private void AddPictureToServer()
        {
            Console.WriteLine(PictureBindingModel.Name);
            Console.WriteLine(PictureBindingModel.Tags);
            Console.WriteLine(PictureBindingModel.Url);
            Console.WriteLine(PictureBindingModel.Raiting);
            Console.WriteLine(PictureBindingModel.Date);
        }

        private void GetAlbumDetails()
        {

        }

        private void BrowsePictureDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Upload photo";
            fileDialog.Filter = "Images (*.png, *jpg)|*.png;*.jpg";

            if (fileDialog.ShowDialog() == true)
            {
                try
                {
                    PictureBindingModel.Url = fileDialog.FileName;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
