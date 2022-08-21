using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IPictureDbService
    {
        bool AddPicture(PictureModelDto picture);
        bool UpdatePicture(PictureModelDto picture);
        bool DeletePicture(int id);
        PictureModelDto GetPicture(int id);
    }
}
