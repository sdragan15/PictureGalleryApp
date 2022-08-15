using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.ViewModel
{
    public class MainWindowViewModel: BaseViewModel
    {
        public BaseViewModel CurrentViewModel { get; }

        public MainWindowViewModel()
        {
            CurrentViewModel = new LoginViewModel();
        }
    }
}
