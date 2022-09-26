using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Interfaces
{
    public interface IImageProvider
    {
        public string GetImage();

        public List<string> GetImages(int count);
    }
}
