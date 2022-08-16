using PictureGalleryApp.Commands;
using PictureGalleryApp.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PictureGalleryApp.ViewModel
{
    public class LoginViewModel: BaseViewModel, ILoginViewModel
    {
        private IMainViewModel _mainViewModel;
        public ICommand UpdateViewCommand { get; set; }

        public LoginViewModel(IMainViewModel main)
        {
            _mainViewModel = main;
            UpdateViewCommand = new UpdateViewCommand(_mainViewModel);
        }

        
    }
}
