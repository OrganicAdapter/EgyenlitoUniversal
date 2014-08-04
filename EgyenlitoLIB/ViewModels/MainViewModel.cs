using EgyenlitoLIB.Models.Datas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoLIB.ViewModels
{
    public delegate void FavouriteChangedEventHandler(object sender, Article favourite);

    public class MainViewModel
    {
        public event FavouriteChangedEventHandler FavouriteChangedEvent;

        #region Properties

        private static MainViewModel _instance;
        public static MainViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainViewModel();

                return _instance;
            }
        }


        private Article _newFavourite;
        public Article NewFavourite
        {
            get { return _newFavourite; }
            set { _newFavourite = value; if (FavouriteChangedEvent != null) FavouriteChangedEvent(this, _newFavourite); }
        }


        public Newspaper Newspaper { get; set; }
        public Article Article { get; set; }
        public Event Event { get; set; }

        #endregion //Properties

        #region Constructor

        public MainViewModel()
        {
        }

        #endregion //Constructor
    }
}
