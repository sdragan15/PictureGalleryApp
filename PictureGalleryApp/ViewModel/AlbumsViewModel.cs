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
        public ObservableCollection<AlbumModel> AlbumNames { get; set; }

        private AlbumWindow _albumWindow;
        private AlbumWindowViewModel _albumWindowViewModel;
        private IAlbumAppService _albumServer;
        public ICommand SelectAlbum { get; set; }


        [Obsolete("Only for design data", true)]
        public AlbumsViewModel(): this(null, null)
        {
        }


        public AlbumsViewModel(IAlbumAppService album, AlbumWindowViewModel albumWindowViewModel)
        {
            _albumWindowViewModel = albumWindowViewModel;
            SelectAlbum = new RelayCommand<int>(OpenAlbum);
            _albumServer = album;
            AlbumNames = new ObservableCollection<AlbumModel>();
        }

        private void OpenAlbum(int param)
        {
            _albumWindowViewModel.SetAlbumId(param);
            _albumWindow = new AlbumWindow(_albumWindowViewModel);
            _albumWindow.ShowDialog();
        }

        public async void GetAlbumsForUser(string username)
        {
           
            List<AlbumModel> names = await _albumServer.GetAllAlbumsForUser(username);
            foreach (AlbumModel name in names)
            {
                AlbumNames.Add(name);
            }
           
            
        }
    }
}
