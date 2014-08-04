using EgyenlitoLIB.Models.Datas;
using EgyenlitoLIB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace EgyenlitoLIB.Models.Implementations
{
    public class NavigationService : INavigationService
    {
        #region Fields

        private readonly ITypeService _typeService;

        private static Random Rnd = new Random();

        #endregion //Fields

        #region Properties

        private Frame RootFrame { get; set; }

        #endregion //Properties

        #region Constructor

        public NavigationService(ITypeService typeService)
        {
            _typeService = typeService;

            RootFrame = Window.Current.Content as Frame;
        }

        #endregion //Constructor

        #region Methods

        public void Navigate(string uri)
        {
            var type = _typeService.GetType("Egyenlito." + uri);
            RootFrame.Navigate(type);
            RootFrame.ForwardStack.Clear();
        }

        public void GoBack()
        {
            RootFrame.GoBack();
            RootFrame.ForwardStack.Clear();
        }

        #endregion //Methods
    }
}
