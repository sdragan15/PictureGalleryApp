using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
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
    public class MainWindowViewModel: ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private SignUpViewModel _signUpViewModel;
        private LoginViewModel _loginViewModel;


        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                Set(ref _currentViewModel, value);
            }
        }

        [Obsolete("Only for design data", true)]
        public MainWindowViewModel(): this(new LoginViewModel(), null)
        {
            if (!this.IsInDesignMode)
            {
                throw new Exception("Use only for design mode");
            }
        }

        public MainWindowViewModel(LoginViewModel loginView, SignUpViewModel signUpView)
        {
            _signUpViewModel = signUpView;
            _loginViewModel = loginView;
            CurrentViewModel = _loginViewModel;
            Messenger.Default.Register<ChangePage>(this, UpdateCurrentView);
        }



        public void UpdateCurrentView(ChangePage message)
        {
            Console.WriteLine(message.ViewModelType);
            if(message.ViewModelType == typeof(LoginViewModel))
            {
                CurrentViewModel = _loginViewModel;
            }
            else if(message.ViewModelType == typeof(SignUpViewModel))
            {
                CurrentViewModel = _signUpViewModel;
                Console.WriteLine("Uslo" + CurrentViewModel);
            }
            else
            {
                throw new ArgumentException("Arrgument out of range " + message.ViewModelType.ToString());
            }

        }
    }
}
