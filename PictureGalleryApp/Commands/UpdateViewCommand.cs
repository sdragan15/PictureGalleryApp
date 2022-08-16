using PictureGalleryApp.Contract;
using PictureGalleryApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PictureGalleryApp.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private IMainViewModel _mainViewModel;

        public UpdateViewCommand(IMainViewModel main)
        {
            _mainViewModel = main;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine("hellooosadg " + parameter.ToString());
            if (parameter.Equals("login"))
            {
                _mainViewModel.UpdateCurrentView(new LoginViewModel(_mainViewModel));
            }
            else if (parameter.Equals("signup"))
            {
                _mainViewModel.UpdateCurrentView(new SignUpViewModel(_mainViewModel));
            }
        }
    }
}
