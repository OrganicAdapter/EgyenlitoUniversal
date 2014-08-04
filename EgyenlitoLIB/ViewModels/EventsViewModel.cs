using EgyenlitoLIB.Models.Datas;
using EgyenlitoLIB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalExtensions.MVVM;

namespace EgyenlitoLIB.ViewModels
{
    public class EventsViewModel : ViewModelBase
    {
        #region Fields

        private readonly IApiService _apiService;
        private readonly INavigationService _navigationService;

        #endregion //Fields

        #region Properties

        private List<Event> _events;
        public List<Event> Events
        {
            get { return _events; }
            set { _events = value; RaisePropertyChanged(); }
        }

        public RelayCommand Load { get; set; }
        public RelayCommand<Event> Open { get; set; }

        #endregion //Properties

        #region Constructor

        public EventsViewModel(IApiService apiService, INavigationService navigationService, ITaskService taskService)
            :base(taskService)
        {
            _apiService = apiService;
            _navigationService = navigationService;

            Load = new RelayCommand(ExecuteLoad);
            Open = new RelayCommand<Event>(ExecuteOpen);
        }

        #endregion //Constructor

        #region Methods

        private void ExecuteLoad()
        {
            Init();
        }

        private async void Init()
        {
            Events = await _apiService.GetEvents();
        }

        private void ExecuteOpen(Event eve)
        { 
            Main.Event = eve;
            _navigationService.Navigate("Event");
        }

        #endregion //Methods
                
    }
}
