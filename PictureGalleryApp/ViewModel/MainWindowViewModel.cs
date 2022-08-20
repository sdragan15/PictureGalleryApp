using GalaSoft.MvvmLight.Messaging;
using PictureGalleryApp.Contract;
using PictureGalleryApp.Messages;
using PictureGalleryApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PictureGalleryApp.ViewModel
{
    public class MainWindowViewModel: BaseViewModel, IMainViewModel
    {
        private BaseViewModel _currentViewModel;
        private LoginViewModel _loginViewModel;
        private SignUpViewModel _signUpViewModel;


        public BaseViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public MainWindowViewModel()
        {
            _signUpViewModel = new SignUpViewModel(this);
            _loginViewModel = new LoginViewModel();
            CurrentViewModel = _loginViewModel;
            Messenger.Default.Register<ChangePage>(this, UpdateCurrentView);
            
        }

        public void UpdateCurrentView(ChangePage message)
        {
            if(message.ViewModelType == typeof(LoginViewModel))
            {
                CurrentViewModel = _loginViewModel;
            }
            else if(message.ViewModelType == typeof(SignUpViewModel))
            {
                CurrentViewModel = _signUpViewModel;
            }
            else
            {
                throw new ArgumentException("Arrgument out of range " + message.ViewModelType.ToString());
            }

        }
    }
}
