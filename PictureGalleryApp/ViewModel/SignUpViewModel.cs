using GalaSoft.MvvmLight;
using PictureGalleryApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PictureGalleryApp.ViewModel
{
    public class SignUpViewModel: ViewModelBase
    {
        public ICommand UpdateViewCommand { get; set; }

        public SignUpViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand();
        }
    }
}
