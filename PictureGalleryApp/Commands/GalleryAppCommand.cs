using PictureGalleryApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.Commands
{
    public class GalleryAppCommand<T>
    {
        public List<CommandHistoryItem<T>> CommandHistory = new List<CommandHistoryItem<T>>();

        public GalleryAppCommand()
        {
        }

        public async Task Execute(PictureCommand<T> command, T picture)
        {
            command.Set(picture);
            await command.Execute();
            CommandHistory.Add(new CommandHistoryItem<T>() { command = command, item = picture });
        }

        //public Task Redo()
        //{
        //    return;
        //}
        //public Task Undo()
        //{
        //    return;
        //}
    }
}
