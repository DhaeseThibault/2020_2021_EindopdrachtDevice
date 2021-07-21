using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
            // Showing the restaurant name in the topbar
            lblRestaurantName.Text = MainPage.listRestaurantName[0].ToString();


            // Showing all the offers in the body
            string offer = MainPage.listRestaurantOffer[0].ToString();
            string[] listOffers = offer.Split(';');
            for (int i = 0; i < listOffers.Length; i++)
            {
                lblOffer.Text += "-  " + listOffers[i] + "\n";
            }


            // Showing all the kitchen types in the body
            string kitchen = MainPage.listRestaurantKitchen[0].ToString();
            string[] listKitchen = kitchen.Split(';');
            for (int i = 0; i < listKitchen.Length; i++)
            {
                lblKitchen.Text += "-  " + listKitchen[i] + "\n";
            }


            // Showing the restaurant addresss
            string address = MainPage.listRestaurantAddress[0].ToString();
            string zipCode = MainPage.listRestaurantZipCode[0].ToString();
            string city = MainPage.listRestaurantCity[0].ToString();

            lblAddress.Text = address;
            lblZipCode.Text = zipCode;
            lblCity.Text = city;


            // Showing the PhoneNumber of the restaurant
            string phoneNumber = MainPage.listRestaurantPhoneNumber[0].ToString();
            lblPhoneNumber.Text = phoneNumber;


            //Showing the URL of the restaurants site
            string siteUrl = MainPage.listRestaurantSiteUrl[0].ToString();
            lblSiteUrl.Text = siteUrl;
        }

        public ICommand TapCommand => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri(url));
        });

    }
}