using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Model;
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
        public ObservableCollection<AlbumModel> AllAlbumNames { get; set; }
        public ICommand SelectAlbum { get; set; }
        public ICommand AddAlbum { get; set; }

        private AlbumModel _album;
        private AlbumWindow _albumWindow;
        private AlbumWindowViewModel _albumWindowViewModel;
        private IAlbumAppService _albumServer;
        private string _username = "";
        private bool _showAll;
        
        public bool ShowAll
        {
            get
            {
                return _showAll;
            }
            set
            {
                Set(ref _showAll, value);
            }
        }

        public AlbumModel Album
        {
            get { return _album; }
            set
            {
                Set(ref _album, value);
            }
        }

        [Obsolete("Only for design data", true)]
        public AlbumsViewModel(): this(null, null)
        {
        }


        public AlbumsViewModel(IAlbumAppService album, AlbumWindowViewModel albumWindowViewModel)
        {
            ShowAll = true;
            Album = new AlbumModel();
            _albumWindowViewModel = albumWindowViewModel;
            SelectAlbum = new RelayCommand<int>(OpenAlbum);
            AddAlbum = new RelayCommand(AddAlbumToUser);
            _albumServer = album;
            AlbumNames = new ObservableCollection<AlbumModel>();
            AllAlbumNames = new ObservableCollection<AlbumModel>();
        }

        private void OpenAlbum(int param)
        {
            _albumWindowViewModel.SetAlbumId(param);
            _albumWindow = new AlbumWindow(_albumWindowViewModel);
            _albumWindow.ShowDialog();
            GetAlbumsForUser(_username);
        }

        public async void GetAlbumsForUser(string username)
        {
            if (!ShowAll)
            {
                AlbumNames.Clear();
                List<AlbumModel> names = await _albumServer.GetAllPublicAlbums();
                foreach (AlbumModel name in names)
                {
                    AlbumNames.Add(name);
                }
            }
            else
            {
                AlbumNames.Clear();
                List<AlbumModel> names = await _albumServer.GetAllAlbumsForUser(username);
                foreach (AlbumModel name in names)
                {
                    AlbumNames.Add(name);
                }
            }
            
        }

        public void ShowOnlyMyAlbums(bool value)
        {
            if (_username == "") return;

            Console.WriteLine("Working .. .. . . .");
            ShowAll = value;
            GetAlbumsForUser(_username);
        }

        public void SetUsername(string username)
        {
            _username = username;
        }

        private async void AddAlbumToUser()
        {
            Album.User = new UserModelDto() { Username = _username };
            await _albumServer.AddAlbum(Album);
            GetAlbumsForUser(_username);
        }
    }
}
