using EgyenlitoLIB.Models.Datas;
using EgyenlitoLIB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalExtensions;
using UniversalExtensions.GroupedItems;
using UniversalExtensions.MVVM;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;

namespace EgyenlitoLIB.ViewModels
{
    public class AllArticlesViewModel : ViewModelBase
    {
        #region Fields

        protected readonly IApiService _apiService;
        protected readonly INavigationService _navigationService;
        protected readonly IFacebookService _facebookService;

        #endregion //Fields

        #region Properties

        private List<Article> _articles;
        public List<Article> Articles
        {
            get { return _articles; }
            set { _articles = value; RaisePropertyChanged("Articles"); RaisePropertyChanged("GroupedArticles"); }
        }

        public List<GroupedListItem<Article>> GroupedArticles
        {
            get
            {
                return GroupedListItem<Article>.GroupItems(Articles);
            }
        }


        public RelayCommand Load { get; set; }
        public RelayCommand<Article> Open { get; set; }
        public RelayCommand<Article> Share { get; set; }
        public RelayCommand<Article> AddToFavourites { get; set; }

        #endregion //Properties

        #region Constructor

        public AllArticlesViewModel(INavigationService navigationService, IApiService apiService, IFacebookService facebookService, ITaskService taskService)
            :base(taskService)
        {
            _apiService = apiService;
            _navigationService = navigationService;
            _facebookService = facebookService;

            Load = new RelayCommand(ExecuteLoad);
            Open = new RelayCommand<Article>(ExecuteOpen);
            Share = new RelayCommand<Article>(ExecuteShare);
            AddToFavourites = new RelayCommand<Article>(ExecuteAddToFavourites);
        }

        #endregion //Constructor

        #region Methods

        private void ExecuteLoad()
        {
            Init();
        }

        protected virtual async void Init()
        {
            CheckInternet();
            if (!IsInternetConnected) return;

            Articles = await _apiService.GetArticles();
        }

        private async void ExecuteOpen(Article article)
        {
//#if WINDOWS_PHONE_APP
            await Launcher.LaunchUriAsync(new Uri(article.PdfUri, UriKind.Absolute));
//#else
//            var newspapers = await _apiService.GetNewspapers();
//            Main.Newspaper = newspapers.Where((x) => x.NewspaperId == article.NewspaperId).FirstOrDefault();
//            Main.Article = article;
//            _navigationService.Navigate("PdfReader");
//#endif
        }

        private async void ExecuteShare(Article article)
        {
            var newspapers = await _apiService.GetNewspapers();
            var newspaper = newspapers.Where((x) => x.NewspaperId == article.NewspaperId).FirstOrDefault();

            _facebookService.Share(article, newspaper);
        }

        private void ExecuteAddToFavourites(Article article)
        {
            Main.NewFavourite = article;
        }

        #endregion //Methods
                
    }
}
