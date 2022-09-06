using PictureGalleryApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.Model
{
    public class CommandHistoryItem<T>
    {
        public PictureCommand<T> command;
        public T item;
    }
}
