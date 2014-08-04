using EgyenlitoLIB.Models.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoLIB.Models.Interfaces
{
    public interface IFacebookService
    {
        void Share(Article article, Newspaper newspaper);
    }
}
