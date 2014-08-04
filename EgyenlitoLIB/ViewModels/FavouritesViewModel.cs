using EgyenlitoLIB.Models.Datas;
using EgyenlitoLIB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalExtensions.GroupedItems;
using UniversalExtensions.MVVM;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace EgyenlitoLIB.ViewModels
{
    public class FavouritesViewModel : AllArticlesViewModel
    {
        #region Fields

        private readonly IStorageService _storageService;

        #endregion //Fields

        #region Properties

        private ObservableCollection<Article> _favourites;
        public ObservableCollection<Article> Favourites
        {
            get { return _favourites; }
            set { _favourites = value; RaisePropertyChanged(); RaisePropertyChanged("GroupedFavourites"); }
        }

        public List<GroupedListItem<Article>> GroupedFavourites
        {
            get
            {
                return GroupedListItem<Article>.GroupItems(Favourites.ToList());
            }
        }

        public RelayCommand<Article> Remove { get; set; }

        #endregion //Properties

        #region Constructor

        public FavouritesViewModel(IApiService apiService, IStorageService storageService, INavigationService navigationService, IFacebookService facebookService, ITaskService taskService)
            :base(navigationService, apiService, facebookService, taskService)
        {
            _storageService = storageService;

            Main.FavouriteChangedEvent += Main_FavouriteChangedEvent;

            Favourites = new ObservableCollection<Article>();

            Remove = new RelayCommand<Article>(ExecuteRemove);
        }

        #endregion //Constructor

        #region Methods

        protected override void Init()
        {
            
        }

        private async void GetFavourites()
        {
            var favouriteIds = _storageService.LoadFavourites();

            if (favouriteIds == null) return;

            var articles = await _apiService.GetArticles();

            var favourites = new List<Article>();

            foreach (var article in articles)
            {
                if (favouriteIds.Contains(article.ArticleId))
                    favourites.Add(article);
            }

            Favourites.Clear();

            foreach (var item in favourites)
            {
                Favourites.Add(item);
            }

            RaisePropertyChanged("GroupedFavourites");
        }

        private void ExecuteRemove(Article article)
        {
            Favourites.Remove(article);
            RaisePropertyChanged("GroupedFavourites");
            _storageService.SaveFavourites(Favourites.ToList());
        }

        private void Main_FavouriteChangedEvent(object sender, Article favourite)
        {
            if (Favourites.Contains(favourite)) return;

            Favourites.Add(favourite);
            RaisePropertyChanged("GroupedFavourites");
            _storageService.SaveFavourites(Favourites.ToList());
        }

        #endregion //Methods
                
    }
}
