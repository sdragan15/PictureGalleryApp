using GalaSoft.MvvmLight;
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

        //[Obsolete("Only for design data", true)]
        public LoginViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand();
            LoginCommand = new RelayCommand(Login);
            LoginServerCommand = new LoginServerCommand(_loginUri, LoginBindingModel);
            _loginServer = new LoginService(_loginUri, LoginBindingModel);
        }

        //With parameter constructor
        //public LoginViewModel()
        //{

        //}


        private void Login()
        {
            Thread thread = new Thread(() =>
            {
                if (!_loginServer.Run())
                {
                    MessageBox.Show("Failed");
                }
                else
                {
                    UpdateViewCommand.Execute("loggedin");
                }
            });
            thread.Start();
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
