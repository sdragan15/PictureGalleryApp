using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PictureGalleryApp.Commands;
using PictureGalleryApp.Messages;
using PictureGalleryApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PictureGalleryApp.ViewModel
{
    public class MainWindowViewModel: ViewModelBase
    {
        public ICommand ShowAllAlbumsCommand { get; set; }
        public ICommand ShowMyAlbumsCommand { get; set; }
        public ICommand SignOutCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        private ViewModelBase _currentViewModel;
        private SignUpViewModel _signUpViewModel;
        private LoginViewModel _loginViewModel;
        private AlbumsViewModel _albumsViewModel;
        private bool _isAdmin;

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                Set(ref _isAdmin, value);
            }
        }
        


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
        public MainWindowViewModel(): this(new LoginViewModel(), null, new AlbumsViewModel())
        {
            if (!this.IsInDesignMode)
            {
                throw new Exception("Use only for design mode");
            }
        }

        public MainWindowViewModel(LoginViewModel loginView, SignUpViewModel signUpView, AlbumsViewModel albumsView)
        {
            IsAdmin = false;
            _signUpViewModel = signUpView;
            _loginViewModel = loginView;
            _albumsViewModel = albumsView;
            CurrentViewModel = _loginViewModel;
            //CurrentViewModel = _albumsViewModel;
            Messenger.Default.Register<ChangePage>(this, UpdateCurrentView);
            ShowAllAlbumsCommand = new RelayCommand(ShowAllAlbums);
            ShowMyAlbumsCommand = new RelayCommand(ShowMyAlbums);
            SignOutCommand = new RelayCommand(SignOut);
            UpdateViewCommand = new UpdateViewCommand();
        }

        private void SignOut()
        {
            Properties.Settings.Default.Token = "";
            IsAdmin = false;
            _loginViewModel.SignOut();
            CurrentViewModel = _loginViewModel;
            Messenger.Default.Register<ChangePage>(this, UpdateCurrentView);
        }

        private void ShowAllAlbums()
        {
            _albumsViewModel.ShowOnlyMyAlbums(false);
        }

        private void ShowMyAlbums()
        {
            _albumsViewModel.ShowOnlyMyAlbums(true);
        }


        public void UpdateCurrentView(ChangePage message)
        {
            if (Properties.Settings.Default.Token.Equals("Admin"))
            {
                IsAdmin = true;
            }
            else
            {
                IsAdmin = false;
            }

            Console.WriteLine(message.ViewModelType);
            if(message.ViewModelType == typeof(LoginViewModel))
            {
                CurrentViewModel = _loginViewModel;
            }
            else if(message.ViewModelType == typeof(SignUpViewModel))
            {
                CurrentViewModel = _signUpViewModel;
            }
            else if(message.ViewModelType == typeof(AlbumsViewModel))
            {
                CurrentViewModel = _albumsViewModel;
            }
            else
            {
                throw new ArgumentException("Arrgument out of range " + message.ViewModelType.ToString());
            }

        }
    }
}
