using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PictureGalleryApp.Commands;
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
    public class SignUpViewModel: ViewModelBase
    {
        public ICommand UpdateViewCommand { get; set; }
        public ICommand SignUpCommand { get; set; }
        private string _signUpUri = "net.tcp://localhost:10106/Auth";

        private SignUpModel _signUpBindingModel = new SignUpModel();
        private AuthTemplate _signUpServer;

        public SignUpModel SignUpBindingModel
        {
            get { return _signUpBindingModel; }
            set
            {
                Set(ref _signUpBindingModel, value);
            }
        }

        //[Obsolete("Only for design data", true)]
        public SignUpViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand();
            SignUpCommand = new RelayCommand(SignUp);
            _signUpServer = new SignUpServer(_signUpUri, _signUpBindingModel);
        }

        private void SignUp()
        {
            Thread thread = new Thread(() =>
            {
                if (!_signUpServer.Run())
                {
                    MessageBox.Show("Failed");
                }
                else
                {
                    UpdateViewCommand.Execute("login");
                }
            });
            thread.Start();
        }
    }
}
