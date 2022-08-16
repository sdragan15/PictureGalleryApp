using PictureGalleryApp.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.ViewModel
{
    public class MainWindowViewModel: BaseViewModel, IMainViewModel
    {
        private BaseViewModel _currentViewModel;

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
            CurrentViewModel = new LoginViewModel(this);
        }

        public void UpdateCurrentView(BaseViewModel baseView)
        {
            CurrentViewModel = baseView;
        }
    }
}
