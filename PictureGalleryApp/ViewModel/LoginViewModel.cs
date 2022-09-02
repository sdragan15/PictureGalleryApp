﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PictureGalleryApp.Commands;
using PictureGalleryApp.Contract;
using PictureGalleryApp.Model;
using PictureGalleryApp.Server.Contract;
using PictureGalleryApp.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PictureGalleryApp.ViewModel
{
    public class LoginViewModel: ViewModelBase
    {
        public ICommand UpdateViewCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public IServerCommand LoginServerCommand { get; set; }
        private AlbumsViewModel _albumViewModel;

        PictureWindowViewModel _pictureWindowViewModel;
        private LoginModel _loginBindingModel = new LoginModel();
        private string _loginUri = "net.tcp://localhost:10106/Auth";
        private AuthTemplate _loginServer;


        public LoginModel LoginBindingModel
        {
            get { return _loginBindingModel; }
            set
            {
                Set(ref _loginBindingModel, value);
            }
        }

        [Obsolete("Only for design data", true)]
        public LoginViewModel()
        {
            
        }

        
        public LoginViewModel(AlbumsViewModel albumsViewModel, PictureWindowViewModel pictureWindowViewModel)
        {
            _pictureWindowViewModel = pictureWindowViewModel;
            _albumViewModel = albumsViewModel;
            UpdateViewCommand = new UpdateViewCommand();
            LoginCommand = new RelayCommand(Login);
            LoginServerCommand = new LoginServerCommand(_loginUri, LoginBindingModel);
            _loginServer = new LoginService(_loginUri, LoginBindingModel);
        }


        private async void Login()
        {
            bool IsLoggedIn = false;

            Task task = new Task(() =>
            {
                if (!_loginServer.Run())
                {
                    MessageBox.Show("Failed");
                }
                else
                {
                    IsLoggedIn = true;
                    UpdateViewCommand.Execute("loggedin");
                }
            });

            task.Start();

            await task;

            if (IsLoggedIn)
            {
                Console.WriteLine(Properties.Settings.Default.Token);
                _albumViewModel.GetAlbumsForUser(LoginBindingModel.Username);
                _albumViewModel.SetUsername(LoginBindingModel.Username);
                _pictureWindowViewModel.SetUsername(LoginBindingModel.Username);
            }
        }

        public void SignOut()
        {
            _albumViewModel.SetUsername("");
            LoginBindingModel.Username = "";
            LoginBindingModel.Password = "";
        }

        public string GetUsername()
        {
            return LoginBindingModel.Username;
        }

        //private void Login()
        //{
        //    Thread thread = new Thread(() =>
        //    {
        //        if (!LoginServerCommand.Execute())
        //        {
        //            MessageBox.Show("Failed");
        //        }
        //        else
        //        {
        //            UpdateViewCommand.Execute("loggedin");
        //        }
        //    });
        //    thread.Start();
        //}


    }
}
