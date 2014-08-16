using EgyenlitoLIB.Models.Datas;
using EgyenlitoLIB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalExtensions;
using Windows.Storage;

namespace EgyenlitoLIB.Models.Implementations
{
    public class StorageService : IStorageService
    {
        public void SaveFavourites(List<Article> favourites)
        {
            if (favourites == null) return;

            var str = "";
            foreach (var article in favourites)
            {
                str += article.ArticleId + ",";
            }

            ApplicationData.Current.LocalSettings.Values["favourites"] = str;
        }

        public List<int> LoadFavourites()
        {
            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey("favourites")) return null;

            var str = ApplicationData.Current.LocalSettings.Values["favourites"].ToString();
            var split = str.Split(',');

            var list = new List<int>();

            for (int i = 0; i < split.Length - 1; i++)
            {
                list.Add(int.Parse(split[i]));
            }

            return list;
        }

        public async void SaveArticles(List<Article> articles)
        {
            if (articles == null) return;

            ApplicationData.Current.LocalSettings.Values["articles"] = await JsonSerializer.Serialize<Article>(articles);
        }

        public async Task<List<Article>> LoadArticles()
        {
            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey("articles")) return new List<Article>();

            var str = ApplicationData.Current.LocalSettings.Values["articles"].ToString();

            return await JsonSerializer.Deserialize<List<Article>>(str);
        }

        public async void RemoveArticle(int articleId)
        {
            StorageFolder tempFolder = await ApplicationData.Current.TemporaryFolder.GetFolderAsync(articleId.ToString());
            await tempFolder.DeleteAsync(StorageDeleteOption.PermanentDelete);
        }
    }
}
