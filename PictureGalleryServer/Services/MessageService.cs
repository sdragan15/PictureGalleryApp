using Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryServer
{
    public class MessageService : IMessageService
    {
        private AuthenticationService _authenticationService;

        public MessageService()
        {
            _authenticationService = new AuthenticationService();
        }

        public void SendMessage(string message, string token)
        {
            try
            {
                _authenticationService.IsAuthenticated(token);
                _authenticationService.IsAuthorized(new List<Roles>() { Roles.Admin}, token);
                Console.WriteLine(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
