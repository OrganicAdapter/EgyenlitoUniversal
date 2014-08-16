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
    public class EventViewModel : ViewModelBase
    {
        #region Fields

        private readonly INavigationService _navigationService;

        #endregion //Fields

        #region Properties

        private Event _event;
        public Event Event
        {
            get { return _event; }
            set { _event = value; RaisePropertyChanged(); }
        }

        public RelayCommand Load { get; set; }
        public RelayCommand GoBack { get; set; }

        #endregion //Properties

        #region Constructor

        public EventViewModel(ITaskService taskService, INavigationService navigationService)
            :base(taskService)
        {
            _navigationService = navigationService;

            Load = new RelayCommand(ExecuteLoad);
            GoBack = new RelayCommand(ExecuteGoBack);
        }

        #endregion //Constructor

        #region Methods

        private void ExecuteLoad()
        {
            Init();
        }

        private void Init()
        {
            CheckInternet();
            if (!IsInternetConnected) return;

            Event = Main.Event;
        }

        private void ExecuteGoBack()
        {
            _navigationService.GoBack();
        }

        #endregion //Methods
    }
}
