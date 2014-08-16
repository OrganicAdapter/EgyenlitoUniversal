using EgyenlitoLIB.Models.Datas;
using EgyenlitoLIB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoLIB.Models.Implementations
{
    public class LocalService : ILocalService
    {
        #region Fields

        private readonly IStorageService _localDataService;

        #endregion //Fields

        #region Properties

        public List<Article> Articles { get; set; }

        #endregion //Properties

        #region Constructor

        public LocalService(IStorageService localDataService)
        {
            _localDataService = localDataService;
        }

        #endregion //Constructor

        #region Methods

        public async Task GetArticles()
        {
            Articles = await _localDataService.LoadArticles();
        }

        public async Task<bool> ArticleExists(int articleId)
        {
            await GetArticles();

            var article = (from a in Articles
                           where a.ArticleId == articleId
                           select a).FirstOrDefault();

            return (article == null) ? false : true;
        }

        public void AddArticle(Article article)
        {
            Articles.Add(article);

            _localDataService.SaveArticles(Articles);
        }

        public void DeleteArticle(Article article)
        {
            var art = (from a in Articles
                       where a.ArticleId == article.ArticleId
                       select a).FirstOrDefault();

            Articles.Remove(art);
            _localDataService.RemoveArticle(article.ArticleId);
            _localDataService.SaveArticles(Articles);
        }

        #endregion //Methods
    }
}
