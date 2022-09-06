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

        public async Task Redo()
        {
            if(CommandHistory.Count > 0)
            {
                await CommandHistory.Last().command.Redo();
            }
            
        }
        public async Task Undo()
        {
            if(CommandHistory.Count > 0)
            {
                await CommandHistory.Last().command.Undo();
            }
            
        }
    }
}
