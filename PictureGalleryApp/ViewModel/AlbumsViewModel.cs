using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PictureGalleryApp.Commands;
using PictureGalleryApp.Contract;
using PictureGalleryApp.Model;
using PictureGalleryApp.Server.Contract;
using PictureGalleryApp.Server.Services;
using PictureGalleryApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PictureGalleryApp.ViewModel
{
    public class AlbumsViewModel: ViewModelBase
    {
        private AlbumWindow _albumWindow;
        private AlbumWindowViewModel _albumWindowViewModel;
        private ObservableCollection<string> _albumNames;
        private IAlbumAppService _albumServer;
        public ICommand SelectAlbum { get; set; }

        public ObservableCollection<string> AlbumNames
        {
            get { return _albumNames; }
            set
            {
                Set(ref _albumNames, value);
            }
        }


        [Obsolete("Only for design data", true)]
        public AlbumsViewModel(): this(null, null)
        {
        }


        public AlbumsViewModel(IAlbumAppService album, AlbumWindowViewModel albumWindowViewModel)
        {
            _albumWindowViewModel = albumWindowViewModel;
            SelectAlbum = new RelayCommand<string>(OpenAlbum);
            _albumServer = album;
            AlbumNames = new ObservableCollection<string>() {};
            SetAlbumNames();
        }

        private void OpenAlbum(string param)
        {
            _albumWindowViewModel.SetAlbumId(param);
            _albumWindow = new AlbumWindow(_albumWindowViewModel);
            _albumWindow.ShowDialog();
        }

        private async void SetAlbumNames()
        {
           
            List<string> names = await _albumServer.GetAllAlbumNamesForUser("slavko");
            foreach (string name in names)
            {
                AlbumNames.Add(name);
            }
           
            
        }
    }
}
