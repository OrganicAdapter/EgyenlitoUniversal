using EgyenlitoLIB.Models.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoLIB.Models.Interfaces
{
    public interface ILocalService
    {
        Task<bool> ArticleExists(int articleId);
        void AddArticle(Article article);
        void DeleteArticle(Article article);
    }
}
