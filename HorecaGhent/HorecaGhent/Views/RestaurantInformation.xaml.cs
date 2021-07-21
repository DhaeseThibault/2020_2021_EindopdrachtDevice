using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HorecaGhent.Models;
using HorecaGhent.Repositories;
using HorecaGhent.Views;
using Xamarin.Essentials;
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
            lblOffer.Text = "";
            lblKitchen.Text = "";

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

            lblAddress.Text = address + ", " + zipCode + " " + city;
            //lblZipCode.Text += zipCode + " " + city;
            //lblCity.Text = city;


            // Showing the PhoneNumber of the restaurant
            string phoneNumber = MainPage.listRestaurantPhoneNumber[0].ToString();
            lblPhoneNumber.Text = phoneNumber;


            //Showing the URL of the restaurants site
            string siteUrl = MainPage.listRestaurantSiteUrl[0].ToString();
            lblSiteUrl.Text = siteUrl;

            //https://www.google.be/maps/dir//Binnenweg+26,+9050+Gent/@50.9699123,3.5180066,17z/data=!4m9!4m8!1m0!1m5!1m1!1s0x47c374002c8b2249:0x86cf1a56b6a9fd7d!2m2!1d3.7398261!2d51.0358584!3e0


        }

        private void PhoneNumberTapped(object sender, EventArgs e)
        {
            string phoneNumber = MainPage.listRestaurantPhoneNumber[0].ToString();
            PhoneDialer.Open(phoneNumber);
        }

        private void SiteUrlTapped(object sender, EventArgs e)
        {
            string siteUrl = MainPage.listRestaurantSiteUrl[0].ToString();
            Device.OpenUri(new Uri(siteUrl));
        }

        private void AddressTapped(object sender, EventArgs e)
        {
            string address = MainPage.listRestaurantAddress[0].ToString();
            string zipCode = MainPage.listRestaurantZipCode[0].ToString();
            string city = MainPage.listRestaurantCity[0].ToString();

            string[] listAddress = address.Split(' ');


            //string url = "https://www.google.be/maps/dir//Binnenweg+26,+9050+Gent/@50.9699123,3.5180066,17z/data=!4m9!4m8!1m0!1m5!1m1!1s0x47c374002c8b2249:0x86cf1a56b6a9fd7d!2m2!1d3.7398261!2d51.0358584!3e0";
            string url = "https://www.google.be/maps/dir//" + listAddress[0] + "+" + listAddress[1] + ",+" + zipCode + "+" + city + "/@50.9699123,3.5180066,17z / data = !4m9!4m8!1m0!1m5!1m1!1s0x47c374002c8b2249: 0x86cf1a56b6a9fd7d!2m2!1d3.7398261!2d51.0358584!3e0";
            Device.OpenUri(new Uri(url));
        }
    }
}