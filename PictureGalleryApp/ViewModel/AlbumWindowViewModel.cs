using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using PictureGalleryApp.Commands;
using PictureGalleryApp.Model;
using PictureGalleryApp.Server.Contract;
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
        public RelayCommand RefreshCommand { get; set; }
        public ObservableCollection<PictureModel> Pictures { get; set; }
        public RelayCommand SearchCommand { get; set; }

        private PictureModel _pictureBindingModel;
        private int _albumId;
        private IAlbumAppService _albumService;
        private PictureWindowViewModel _pictureWindowViewModel;
        private PictureWindow _pictureWindow;
        private string _pictureName;
        private string _pictureTags;
        private AlbumModel _albumBindingModel;
        private string _searchText;
        private PictureCommand<PictureModel> _addPictureCommand;
        private GalleryAppCommand<PictureModel> _galleryAppCommand;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                Set(ref _searchText, value);
            }
        }

        public AlbumModel AlbumBindingModel
        {
            get { return _albumBindingModel; }
            set
            {
                Set(ref _albumBindingModel, value);
            }
        }

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

        public AlbumWindowViewModel(PictureWindowViewModel pictureWindowViewModel, IAlbumAppService albumService, GalleryAppCommand<PictureModel> galleryAppCommand)
        {
            _pictureWindowViewModel = pictureWindowViewModel;
            _albumService = albumService;
            AddPicture = new RelayCommand(AddPictureToServer, AddPictureValidation);
            BrowsePicture = new RelayCommand(BrowsePictureDialog);
            GetPictures = new RelayCommand<int>(GetAlbumPictures);
            PictureBindingModel = new PictureModel();
            Pictures = new ObservableCollection<PictureModel>();
            DeleteAlbumCommand = new RelayCommand<Window>(DeleteAlbum);
            SelectPictureCommand = new RelayCommand<int>(OpenPicture);
            PictureName = "";
            PictureTags = "";
            RefreshCommand = new RelayCommand(Refresh);
            SearchCommand = new RelayCommand(Search);
            _addPictureCommand = new AddPictureCommand(_albumService);
            _galleryAppCommand = galleryAppCommand;
        }

        private async void Search()
        {
            Pictures.Clear();
            List<PictureModel> res = await _albumService.SearchPictures(SearchText, _albumId);
            foreach (PictureModel picture in res)
            {
                Pictures.Add(picture);
            }
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

            await _galleryAppCommand.Execute(_addPictureCommand, PictureBindingModel);
            Pictures.Clear();
            GetAlbumPictures(_albumId);
            PictureBindingModel.Clear();
        }

        private async void GetAlbumPictures(int albumId)
        {
            GetAlbumDetails();
            Pictures.Clear();
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
            GetAlbumPictures(_albumId);
        }

        private async void GetAlbumDetails()
        {
            AlbumBindingModel = await _albumService.GetAlbum(_albumId);
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

        private void Refresh()
        {
            GetAlbumPictures(_albumId);
        }
    }
}
