using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PictureGalleryApp.Model;
using PictureGalleryApp.Server.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PictureGalleryApp.ViewModel
{
    public class PictureWindowViewModel : ViewModelBase
    {
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand<Window> DeleteCommand { get; set; }
        public RelayCommand RateCommand { get; set; }

        private IAlbumAppService _albumAppService;
        private string _username;
        private PictureModel _pictureBindingModel;
        private int _ratingSlider;
        private string _pictureName;
        private string _pictureTags;



        public string PictureName
        {
            get { return _pictureName; }
            set
            {
                Set(ref _pictureName, value);
                PictureBindingModel.Name = value;
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        public string PictureTags
        {
            get { return _pictureTags; }
            set
            {
                Set(ref _pictureTags, value);
                PictureBindingModel.Tags = value;
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        public int RatingSlider
        {
            get { return _ratingSlider; }
            set
            {
                Set(ref _ratingSlider, value);
            }
        }
       

        public PictureModel PictureBindingModel
        {
            get { return _pictureBindingModel; }
            set
            {
                Set(ref _pictureBindingModel, value);
            }
        }

        public PictureWindowViewModel(IAlbumAppService albumAppService)
        {
            _albumAppService = albumAppService;
            RatingSlider = 3;
            UpdateCommand = new RelayCommand(Update, UpdateValidate);
            DeleteCommand = new RelayCommand<Window>(Delete);
            RateCommand = new RelayCommand(Rate, RateValidate);
        }

        public void SetPicture(PictureModel picture)
        {
            PictureBindingModel = picture;
            PictureBindingModel.Raiting = Math.Round(PictureBindingModel.Raiting, 2);
            PictureName = PictureBindingModel.Name;
            PictureTags = PictureBindingModel.Tags;
        }

        private bool RateValidate()
        {
            if (PictureBindingModel.UserRated.Contains(_username))
            {
                return false;
            }
            return true;
        }

        private async void Rate()
        {
            PictureBindingModel.Raiting = RatingSlider;
            PictureBindingModel.UserRated = new List<string> { _username };
            await _albumAppService.RatePicture(PictureBindingModel);
            PictureBindingModel = await _albumAppService.GetPicture(PictureBindingModel.AlbumId, PictureBindingModel.Id);
            PictureBindingModel.Raiting = Math.Round(PictureBindingModel.Raiting, 2);
            RateCommand.RaiseCanExecuteChanged();
        }
        
        public void SetUsername(string username)
        {
            _username = username;
        }

        private async void Update()
        {
            await _albumAppService.UpdatePicture(PictureBindingModel);
        }

        private bool UpdateValidate()
        {
            if (String.IsNullOrWhiteSpace(PictureBindingModel.Name)
                || String.IsNullOrWhiteSpace(PictureBindingModel.Tags))
            {
                return false;
            }

            return true;
        }

        private async void Delete(Window window)
        {
            await _albumAppService.DeletePicture(PictureBindingModel.AlbumId, PictureBindingModel.Id);
            window.Close();
        }
    }
}
