using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.Server.Contract
{
    public abstract class AuthTemplate
    {
        protected string endpoint;

        protected abstract void Connect();
        protected abstract void Process();

        public bool Run()
        {
            try
            {
                Connect();
                Process();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
