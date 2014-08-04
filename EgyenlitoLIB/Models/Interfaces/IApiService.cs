using EgyenlitoLIB.Models.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoLIB.Models.Interfaces
{
    public interface IApiService
    {
        Task<List<Newspaper>> GetNewspapers();
        Task<List<Article>> GetArticles();
        Task<List<Article>> GetArticles(int newspaperId);
        Task<List<Event>> GetEvents();
    }
}
