using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using PictureGalleryApp.Model;
using PictureGalleryApp.Server.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ICommand GetPictures { get; set; }

        public ObservableCollection<PictureModel> Pictures { get; set; }
        private PictureModel _pictureBindingModel;
        private int _albumId;
        private AlbumService _albumService;


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
            _albumService = new AlbumService();
            AddPicture = new RelayCommand(AddPictureToServer);
            BrowsePicture = new RelayCommand(BrowsePictureDialog);
            GetPictures = new RelayCommand<int>(GetAlbumPictures);
            PictureBindingModel = new PictureModel() { Name="Hello", Date = DateTime.Now, Tags="asgj i;sdga", Raiting = 4.9};
            Pictures = new ObservableCollection<PictureModel>();
        }

        public void SetAlbumId(int id)
        {
            _albumId = id;
            Pictures.Clear();
            GetAlbumPictures(_albumId);
        }

        private async void AddPictureToServer()
        {
            PictureBindingModel.AlbumId = _albumId;
            await _albumService.AddPictureToServer(PictureBindingModel);
        }

        private async void GetAlbumPictures(int albumId)
        {
            List<PictureModel> res = await _albumService.GetAllPicturesForAlbum(albumId);
            foreach (PictureModel picture in res)
            {
                Pictures.Add(picture);
            }
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
