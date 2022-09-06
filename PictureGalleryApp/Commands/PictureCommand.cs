using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.Commands
{
    public abstract class PictureCommand<T>
    {
        public abstract void Set(T value);
        public abstract Task Execute();
        public abstract Task Redo();
        public abstract Task Undo();
    }
}
