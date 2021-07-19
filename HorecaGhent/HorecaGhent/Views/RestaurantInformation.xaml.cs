using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HorecaGhent.Models;
using HorecaGhent.Repositories;
using HorecaGhent.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HorecaGhent.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantInformation : ContentPage
    {
        public RestaurantInformation()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            TestHorecaRepository();
        }

        private async void TestHorecaRepository()
        {
            lblRestaurantName.Text = MainPage.listRestaurantName[0].ToString();


            string offer = MainPage.listRestaurantOffer[0].ToString();
            string[] listOffers = offer.Split(';');
            for (int i = 0; i < listOffers.Length; i++)
            {
                lblOffer.Text += "-  " + listOffers[i] + "\n";
            }



        }
    }
}