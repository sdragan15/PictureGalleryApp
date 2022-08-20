using GalaSoft.MvvmLight.Messaging;
using PictureGalleryApp.Messages;
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


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine("Hello " + parameter);
            if (parameter.Equals("login"))
            {
                Messenger.Default.Send(new ChangePage(typeof(LoginViewModel)));
            }
            else if (parameter.Equals("signup"))
            {
                Messenger.Default.Send(new ChangePage(typeof(SignUpViewModel)));
            }
        }
    }
}
