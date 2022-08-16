using PictureGalleryApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.Contract
{
    public interface IMainViewModel
    {
        void UpdateCurrentView(BaseViewModel baseView);
    }
}
