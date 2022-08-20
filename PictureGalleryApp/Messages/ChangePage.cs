using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.Messages
{
    public class ChangePage
    {
        public Type ViewModelType { get; private set; }

        public ChangePage(Type viewModelType)
        {
            ViewModelType = viewModelType;
        }
    }
}
