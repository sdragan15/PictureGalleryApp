﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PictureGalleryApp.Commands;
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
    public class LoginViewModel: ViewModelBase
    {
        public ICommand UpdateViewCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        private LoginModel _loginBindingModel = new LoginModel();


        public LoginModel LoginBindingModel
        {
            get { return _loginBindingModel; }
            set
            {
                _loginBindingModel = value;
                Set(ref _loginBindingModel, value);
            }
        }

        //[Obsolete("Only for design data", true)]
        public LoginViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand();
            LoginCommand = new RelayCommand(Login);
        }

        //With parameter constructor
        //public LoginViewModel()
        //{

        //}

    

        private void Login()
        {
            Console.WriteLine(LoginBindingModel.Username + " da li radi?");
        }

        
    }
}
