using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PictureGalleryApp.Model;
using PictureGalleryApp.Server.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PictureGalleryApp.ViewModel
{
    public class ProfileViewModel: ViewModelBase
    {
        public ICommand ChangeProfile { get; set; }
        public ICommand CancelCommand { get; set; }

        private SignUpModel _profileBindingModel;
        private IUserAppService _userAppService;


        public SignUpModel ProfileBindingModel
        {
            get { return _profileBindingModel; }
            set
            {
                Set(ref _profileBindingModel, value);
            }
        }

        [Obsolete("Only for design data", true)]
        public ProfileViewModel(): this(null)
        {
            
        }

        public ProfileViewModel(IUserAppService userAppService)
        {
            ChangeProfile = new RelayCommand(Change);
            CancelCommand = new RelayCommand(Cancel);
            _userAppService = userAppService;
        }

        public async void GetUser(string username)
        {
            ProfileBindingModel = await _userAppService.GetUser(username);
        }



        private async void Change()
        {
            await _userAppService.UpdateUser(ProfileBindingModel);
        }

        private void Cancel()
        {
            Console.WriteLine("cancel");
        }

    }
}
