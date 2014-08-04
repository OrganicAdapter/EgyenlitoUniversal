using EgyenlitoLIB.Models.Datas;
using EgyenlitoLIB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalExtensions;
using UniversalExtensions.MVVM;
using Windows.UI.Xaml.Controls;

namespace EgyenlitoLIB.ViewModels
{
    public class NewspapersViewModel : ViewModelBase
    {
        #region Fields

        private readonly IApiService _apiService;
        private readonly INavigationService _navigationService;

        #endregion //Fields

        #region Properties

        private List<Newspaper> _newspapers;
        public List<Newspaper> Newspapers
        {
            get { return _newspapers; }
            set { _newspapers = value; RaisePropertyChanged(); }
        }


        public RelayCommand Load { get; set; }
        public RelayCommand<Newspaper> Open { get; set; }

        #endregion //Properties

        #region Constructor

        public NewspapersViewModel(IApiService apiService, INavigationService navigationService, ITaskService taskService)
            :base(taskService)
        {
            _apiService = apiService;
            _navigationService = navigationService;

            Load = new RelayCommand(ExecuteLoad);
            Open = new RelayCommand<Newspaper>(ExecuteOpen);

            Init();
        }

        #endregion //Constructor

        #region Methods

        private void ExecuteLoad()
        {
            Init();
        }

        private async void Init()
        {
            Newspapers = await _apiService.GetNewspapers();
        }

        private void ExecuteOpen(Newspaper newspaper)
        {
            Main.Newspaper = newspaper;
            _navigationService.Navigate(Pages["Articles"]);      
        }

        #endregion //Methods
                
    }
}
