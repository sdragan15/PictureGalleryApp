using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PictureGalleryApp.Model
{
    public class PictureModel: ViewModelBase
    {
        private int _id;
        private string _name;
        private string _tags;
        private double _raiting;
        private DateTime _date;
        private string _url;
        private int _albumId;
        private int _numberOfRatings;
        public List<string> UserRated;

    

        public int Id { get => _id; set => Set(ref _id, value); }
        public string Name { get => _name; set => Set(ref _name, value); }
        public string Tags { get => _tags; set => Set(ref _tags, value); }
        public double Raiting { get => _raiting; set => Set(ref _raiting, value); }
        public DateTime Date { get => _date; set => Set(ref _date, value); }
        public string Url { get => _url; set => Set(ref _url, value); }
        public int AlbumId { get => _albumId; set => Set(ref _albumId, value); }
        public int NumberOfRatings { get => _numberOfRatings; set => Set(ref _numberOfRatings, value); }

        public PictureModel()
        {
            Name = "";
            Tags = "";
            Raiting = 0;
            Date = DateTime.Now;
            NumberOfRatings = 0;
            UserRated = new List<string>();
            Url = "";
        }

        public void Clear()
        {
            Name = "";
            Tags = "";
            Raiting = 0;
            Date = DateTime.Now;
            NumberOfRatings = 0;
            UserRated = new List<string>();
            Url = "";
        }
    }
}
