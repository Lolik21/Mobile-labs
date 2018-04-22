using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CitiesMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public CitiesMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new CitiesMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class CitiesMasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<CitiesMasterDetailPageMenuItem> MenuItems { get; set; }
            
            public CitiesMasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<CitiesMasterDetailPageMenuItem>(new[]
                {
                    new CitiesMasterDetailPageMenuItem { Id = 0, Title = "Page 1" },
                    new CitiesMasterDetailPageMenuItem { Id = 1, Title = "Page 2" },
                    new CitiesMasterDetailPageMenuItem { Id = 2, Title = "Page 3" },
                    new CitiesMasterDetailPageMenuItem { Id = 3, Title = "Page 4" },
                    new CitiesMasterDetailPageMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}