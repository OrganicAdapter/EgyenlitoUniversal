using EgyenlitoLIB.Models.Datas;
using EgyenlitoLIB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalExtensions;
using UniversalExtensions.MVVM;

namespace EgyenlitoLIB.ViewModels
{
    public class ArticlesViewModel : AllArticlesViewModel
    {
        #region Constructor

        public ArticlesViewModel(IApiService apiService, INavigationService navigationService, IFacebookService facebookService, ITaskService taskService)
            : base(navigationService, apiService, facebookService, taskService)
        {
        }

        #endregion //Constructor

        #region Methods

        protected override async void Init()
        {
            Articles = await _apiService.GetArticles(Main.Newspaper.NewspaperId);
        }

        #endregion //Methods
                
    }
}
