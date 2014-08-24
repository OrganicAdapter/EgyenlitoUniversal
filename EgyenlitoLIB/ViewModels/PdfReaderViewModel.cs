using EgyenlitoLIB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalExtensions.MVVM;
using Windows.UI.Popups;

namespace EgyenlitoLIB.ViewModels
{
    public class PdfReaderViewModel : ViewModelBase
    {
        #region Fields

        private readonly IPdfService _pdfService;
        private readonly IFacebookService _facebookService;
        private readonly INavigationService _navigationService;
        private readonly IDownloadService _downloadService;
        private readonly ILocalService _localService;

        #endregion //Fields

        #region Properties

        private List<string> _pdfPages;
        public List<string> PdfPages
        {
            get { return _pdfPages; }
            set { _pdfPages = value; RaisePropertyChanged(); }
        }

        private int _zoom;
        public int Zoom
        {
            get { return _zoom; }
            set { _zoom = value; RaisePropertyChanged(); }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; RaisePropertyChanged(); }
        }


        public RelayCommand Load { get; set; }
        public RelayCommand Post { get; set; }
        public RelayCommand Remove { get; set; }
        public RelayCommand GoBack { get; set; }

        #endregion //Properties

        #region Constructor

        public PdfReaderViewModel(IPdfService pdfService, ITaskService taskService, IFacebookService facebookService, INavigationService navigationService, IDownloadService downloadService, ILocalService localService)
            :base(taskService)
        {
            _pdfService = pdfService;
            _facebookService = facebookService;
            _navigationService = navigationService;
            _downloadService = downloadService;
            _localService = localService;

            Load = new RelayCommand(ExecuteLoad);
            Post = new RelayCommand(ExecutePost);
            Remove = new RelayCommand(ExecuteRemove);
            GoBack = new RelayCommand(ExecuteGoBack);
        }

        #endregion //Constructor

        #region Methods

        private async void ExecuteLoad()
        {
            try
            {
                PdfPages = null;
                IsLoading = true;

                Zoom = 250;

                if (await _localService.ArticleExists(Main.Article.ArticleId))
                {
                    PdfPages = await _pdfService.RenderLocalPDF(Main.Article.ArticleId);
                }
                else
                {
                    await _downloadService.DownloadFile(Main.Article.PdfUri);

                    _localService.AddArticle(Main.Article);

                    PdfPages = await _pdfService.RenderPDF(Main.Article.ArticleId);
                }

                IsLoading = false;
            }
            catch
            {
                ShowMessage("Nincs internet kapcsolat.");
                IsLoading = false;
            }
        }

        private async void ShowMessage(string message)
        {
            MessageDialog dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }

        private void ExecutePost()
        {
            _facebookService.Share(Main.Article, Main.Newspaper);
        }

        private void ExecuteRemove()
        {
            _localService.DeleteArticle(Main.Article);
            _navigationService.GoBack();
        }

        private void ExecuteGoBack()
        {
            _navigationService.GoBack();
        }

        #endregion //Methods
                
    }
}
