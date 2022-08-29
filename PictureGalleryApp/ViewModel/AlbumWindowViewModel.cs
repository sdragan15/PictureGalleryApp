using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using PictureGalleryApp.Model;
using PictureGalleryApp.Server.Services;
using PictureGalleryApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PictureGalleryApp.ViewModel
{
    public class AlbumWindowViewModel : ViewModelBase
    {
        public RelayCommand AddPicture { get; set; }
        public RelayCommand BrowsePicture { get; set; }
        public RelayCommand<int> GetPictures { get; set; }
        public RelayCommand<Window> DeleteAlbumCommand { get;set; }
        public RelayCommand CloseWindowCommand { get; set; }
        public RelayCommand<int> SelectPictureCommand { get; set; }
        public ObservableCollection<PictureModel> Pictures { get; set; }

        private PictureModel _pictureBindingModel;
        private int _albumId;
        private AlbumService _albumService;
        private PictureWindowViewModel _pictureWindowViewModel;
        private PictureWindow _pictureWindow;
        private string _pictureName;
        private string _pictureTags;

        public string PictureTags
        {
            get { return _pictureTags; }
            set
            {
                Set(ref _pictureTags, value);
                AddPicture.RaiseCanExecuteChanged();
            }
        }

        public string PictureName
        {
            get { return _pictureName; }
            set
            {
                Set(ref _pictureName, value);
                AddPicture.RaiseCanExecuteChanged();
            }
        }


        public PictureModel PictureBindingModel
        {
            get {return _pictureBindingModel; }
            set
            {
                Set(ref _pictureBindingModel, value);
            }
        }

        public AlbumWindowViewModel(PictureWindowViewModel pictureWindowViewModel)
        {
            _pictureWindowViewModel = pictureWindowViewModel;
            _albumService = new AlbumService();
            AddPicture = new RelayCommand(AddPictureToServer, AddPictureValidation);
            BrowsePicture = new RelayCommand(BrowsePictureDialog);
            GetPictures = new RelayCommand<int>(GetAlbumPictures);
            PictureBindingModel = new PictureModel();
            Pictures = new ObservableCollection<PictureModel>();
            DeleteAlbumCommand = new RelayCommand<Window>(DeleteAlbum);
            SelectPictureCommand = new RelayCommand<int>(OpenPicture);
            PictureName = "";
            PictureTags = "";
        }

        public async void DeleteAlbum(Window window)
        {
            await _albumService.DeleteAlbum(_albumId);
            window.Close();
        }

        public void SetAlbumId(int id)
        {
            _albumId = id;
            Pictures.Clear();
            GetAlbumPictures(_albumId);
        }

        private bool AddPictureValidation()
        {
            if (String.IsNullOrWhiteSpace(PictureName) || String.IsNullOrWhiteSpace(PictureTags)
                || String.IsNullOrWhiteSpace(PictureBindingModel.Url))
            {
                return false;
            }
            return true;
        }

        private async void AddPictureToServer()
        {
            PictureBindingModel.AlbumId = _albumId;
            PictureBindingModel.Name = PictureName;
            PictureBindingModel.Tags = PictureTags;
            PictureBindingModel.Date = DateTime.Now;
            await _albumService.AddPictureToServer(PictureBindingModel);
            Pictures.Clear();
            GetAlbumPictures(_albumId);
            PictureBindingModel.Clear();
        }

        private async void GetAlbumPictures(int albumId)
        {
            List<PictureModel> res = await _albumService.GetAllPicturesForAlbum(albumId);
            foreach (PictureModel picture in res)
            {
                Pictures.Add(picture);
            }
        }

        private void OpenPicture(int id)
        {
            var picture = Pictures.Where(x => x.Id == id).FirstOrDefault();
            if (picture == null) return;
            _pictureWindow = new PictureWindow(_pictureWindowViewModel);
            _pictureWindowViewModel.SetPicture(picture);
            _pictureWindow.ShowDialog();
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
                    AddPicture.RaiseCanExecuteChanged();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
