using Egyenlito.Implementations;
using EgyenlitoLIB.Models.Implementations;
using EgyenlitoLIB.Models.Interfaces;
using EgyenlitoLIB.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Egyenlito.Injection
{
    public class InjectionManager
    {
        public InjectionManager()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IApiService, ApiService>();
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<ITypeService, TypeService>();
            SimpleIoc.Default.Register<IFacebookService, FacebookService>();
            SimpleIoc.Default.Register<IStorageService, StorageService>();
            SimpleIoc.Default.Register<ITaskService, TaskService>();
            SimpleIoc.Default.Register<ILocalService, LocalService>();
            SimpleIoc.Default.Register<IDownloadService, DownloadService>();
            SimpleIoc.Default.Register<IPdfService, PdfService>();

            SimpleIoc.Default.Register<NewspapersViewModel>();
            SimpleIoc.Default.Register<AllArticlesViewModel>();
            SimpleIoc.Default.Register<ArticlesViewModel>();
            SimpleIoc.Default.Register<EventsViewModel>();
            SimpleIoc.Default.Register<EventViewModel>();
            SimpleIoc.Default.Register<FavouritesViewModel>();
            SimpleIoc.Default.Register<ViewModelBase>();
            SimpleIoc.Default.Register<PdfReaderViewModel>();
        }

        public ViewModelBase Base
        {
            get { return SimpleIoc.Default.GetInstance<ViewModelBase>(); }
        }

        public NewspapersViewModel Newspapers
        {
            get { return SimpleIoc.Default.GetInstance<NewspapersViewModel>(); }
        }

        public AllArticlesViewModel AllArticles
        {
            get { return SimpleIoc.Default.GetInstance<AllArticlesViewModel>(); }
        }

        public FavouritesViewModel Favourites
        {
            get { return SimpleIoc.Default.GetInstance<FavouritesViewModel>(); }
        }

        public ArticlesViewModel Articles
        {
            get { return SimpleIoc.Default.GetInstance<ArticlesViewModel>(); }
        }

        public EventsViewModel Events
        {
            get { return SimpleIoc.Default.GetInstance<EventsViewModel>(); }
        }

        public EventViewModel Event
        {
            get { return SimpleIoc.Default.GetInstance<EventViewModel>(); }
        }

        public PdfReaderViewModel PdfReader
        {
            get { return SimpleIoc.Default.GetInstance<PdfReaderViewModel>(); }
        }
    }
}
