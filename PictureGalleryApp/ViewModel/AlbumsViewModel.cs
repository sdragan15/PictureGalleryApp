using GalaSoft.MvvmLight;
using PictureGalleryApp.Server.Contract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PictureGalleryApp.ViewModel
{
    public class AlbumsViewModel: ViewModelBase
    {
        private ObservableCollection<string> _albumNames;
        private IAlbumServer _albumServer;

        public ObservableCollection<string> AlbumNames
        {
            get { return _albumNames; }
            set
            {
                Set(ref _albumNames, value);
            }
        }


        [Obsolete("Only for design data", true)]
        public AlbumsViewModel(): this(null)
        {
        }


        public AlbumsViewModel(IAlbumServer album)
        {
            _albumServer = album;
            AlbumNames = new ObservableCollection<string>();
            SetAlbumNames();
        }

        private void SetAlbumNames()
        {
           
            List<string> names = _albumServer.GetAllAlbumNamesForUser("slavko");
            foreach (string name in names)
            {
                AlbumNames.Add(name);
            }
           
            
        }
    }
}
