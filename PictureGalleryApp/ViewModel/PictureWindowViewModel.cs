using GalaSoft.MvvmLight;
using PictureGalleryApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.ViewModel
{
    public class PictureWindowViewModel : ViewModelBase
    {
        private PictureModel _pictureBindingModel;
        private int _ratingSlider;

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

        public PictureWindowViewModel()
        {
            RatingSlider = 3;
        }

        public void SetPicture(PictureModel picture)
        {
            PictureBindingModel = picture;
        }
        
    }
}
