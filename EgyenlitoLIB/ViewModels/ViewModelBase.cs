using EgyenlitoLIB.Models.Datas;
using EgyenlitoLIB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UniversalExtensions.MVVM;

namespace EgyenlitoLIB.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion //Events

        #region Fields

        private readonly ITaskService _taskService;

        #endregion //Fields

        #region Properties

        public MainViewModel Main { get; set; }
        public Dictionary<string, string> Pages { get; set; }


        public RelayCommand SendEmail { get; set; }
        public RelayCommand OpenWebPage { get; set; }
        public RelayCommand OpenFacebook { get; set; }
        
        #endregion //Properties

        #region Constructor

        public ViewModelBase(ITaskService taskService)
        {
            _taskService = taskService;

            Main = MainViewModel.Instance;

            Pages = new Dictionary<string, string>()
            {
                {"Articles", "Articles"},
                {"Newspapers", "MainPage"},
                {"PdfReader", "Reader"},
                {"Event", "Event"}
            };

            SendEmail = new RelayCommand(ExecuteSendEmail);
            OpenWebPage = new RelayCommand(ExecuteOpenWebPage);
            OpenFacebook = new RelayCommand(ExecuteOpenFacebook);
        }

        #endregion //Constructor

        #region Methods

        public void RaisePropertyChanged([CallerMemberName] string e = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(e));
        }

        private void ExecuteSendEmail()
        {
            _taskService.SendEmail();
        }

        private void ExecuteOpenWebPage()
        {
            _taskService.OpenWebpage();
        }

        private void ExecuteOpenFacebook()
        {
            _taskService.OpenFacebook();
        }

        #endregion //Methods
                          
    }
}
