using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HorecaGhent.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoriteRestaurant : ContentPage
    {
        public FavoriteRestaurant()
        {
            InitializeComponent();
            //TestHorecaRepository();
        }

        protected override void OnAppearing()
        {
            TestHorecaRepository();
        }

        private void TestHorecaRepository()
        {

        }

        
    }
}