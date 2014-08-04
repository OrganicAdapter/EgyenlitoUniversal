using EgyenlitoLIB.Models.Datas;
using EgyenlitoLIB.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalExtensions;

namespace EgyenlitoLIB.Models.Implementations
{
    public class ApiService : IApiService
    {
        #region Properties

        private HttpClientService Service { get; set; }
        private HttpClientService EventService { get; set; }

        #endregion //Properties

        #region Constructor

        public ApiService()
        {
            Service = new HttpClientService("http://ujegyenlito.softit.hu/Egyenlito/WCF/DataProviderService.svc/");
            EventService = new HttpClientService("http://ujegyenlito.softit.hu/Egyenlito/WCF/WinEventService.svc/");
        }

        #endregion //Constructor

        #region Methods

        public async Task<List<Newspaper>> GetNewspapers()
        {
            var json = await Service.GetRequest("GetNewspapers");
            json = CutJson(json);
            return JsonConvert.DeserializeObject<List<Newspaper>>(json);
        }

        public async Task<List<Article>> GetArticles()
        {
            var json = await Service.GetRequest("GetAllArticles");
            json = CutJson(json);
            return JsonConvert.DeserializeObject<List<Article>>(json);
        }

        public async Task<List<Article>> GetArticles(int newspaperId)
        {
            var json = await Service.GetRequest("GetArticles/?key=" + newspaperId);
            json = CutJson(json);
            return JsonConvert.DeserializeObject<List<Article>>(json);
        }

        public async Task<List<Event>> GetEvents()
        {
            var json = await EventService.GetRequest("GetEvents");
            json = CutJson(json);
            return JsonConvert.DeserializeObject<List<Event>>(json);
        }

        private string CutJson(string json)
        {
            var idx0 = json.IndexOf('<');
            var idx1 = json.IndexOf('>');

            json = json.Remove(idx0, idx1 - idx0 + 1);

            idx0 = json.IndexOf('<');
            idx1 = json.IndexOf('>');

            json = json.Remove(idx0, idx1 - idx0 + 1);

            return json;
        }

        #endregion //Methods
    }
}
