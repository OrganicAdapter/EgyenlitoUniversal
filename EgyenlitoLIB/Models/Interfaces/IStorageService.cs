using EgyenlitoLIB.Models.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoLIB.Models.Interfaces
{
    public interface IStorageService
    {
        void SaveFavourites(List<Article> favourites);
        List<int> LoadFavourites();
    }
}
