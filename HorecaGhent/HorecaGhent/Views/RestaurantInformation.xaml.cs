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
            lblOffers.Text = "";
            lblKitchens.Text = "";

            // Showing the restaurant name in the topbar
            lblRestaurantName.Text = MainPage.ListRestaurantName[0].ToString();


            // Showing all the offers in the body
            string offer = MainPage.ListRestaurantOffer[0].ToString();
            if (offer != "")
            {
                string[] listOffers = offer.Split(';');
                for (int i = 0; i < listOffers.Length; i++)
                {
                    lblOffers.Text += "-  " + listOffers[i] + "\n";
                }
            }
            else
            {
                lblOffer.IsVisible = false;
                lblOffers.IsVisible = false;
            }
            
            


            // Showing all the kitchen types in the body
            string kitchen = MainPage.ListRestaurantKitchen[0].ToString();
            if (kitchen != "")
            {
                string[] listKitchen = kitchen.Split(';');
                for (int i = 0; i < listKitchen.Length; i++)
                {
                    lblKitchens.Text += "-  " + listKitchen[i] + "\n";
                }
            }
            else
            {
                lblKitchen.IsVisible = false;
                lblKitchens.IsVisible = false;
            }
            


            // Showing the restaurant addresss
            string address = MainPage.ListRestaurantAddress[0].ToString();
            string zipCode = MainPage.ListRestaurantZipCode[0].ToString();
            string city = MainPage.ListRestaurantCity[0].ToString();

            if (address != "" || zipCode != "" || city != "")
            {
                lblAddress.Text = address + ", " + zipCode + " " + city;
            }
            else
            {
                lblAddressTitle.IsVisible = false;
                lblAddress.IsVisible = false;
            }




            // Showing the PhoneNumber of the restaurant
            string phoneNumber = MainPage.ListRestaurantPhoneNumber[0].ToString();
            if (phoneNumber != "")
            {
                lblPhoneNumber.Text = phoneNumber;
            }
            else
            {
                lblPhoneNumber.IsVisible = false;
            }


            //Showing the URL of the restaurants site
            string siteUrl = MainPage.ListRestaurantSiteUrl[0].ToString();
            if (siteUrl != "")
            {
                lblSiteUrl.Text = siteUrl;
            }
            else
            {
                lblSiteUrl.IsVisible = false;
            }
        }

        private void PhoneNumberTapped(object sender, EventArgs e)
        {
            string phoneNumber = MainPage.ListRestaurantPhoneNumber[0].ToString();
            PhoneDialer.Open(phoneNumber);
        }

        private void SiteUrlTapped(object sender, EventArgs e)
        {
            string siteUrl = MainPage.ListRestaurantSiteUrl[0].ToString();
            Device.OpenUri(new Uri(siteUrl));
        }

        private void AddressTapped(object sender, EventArgs e)
        {
            string address = MainPage.ListRestaurantAddress[0].ToString();
            string zipCode = MainPage.ListRestaurantZipCode[0].ToString();
            string city = MainPage.ListRestaurantCity[0].ToString();

            string[] listAddress = address.Split(' ');


            string url = "https://www.google.be/maps/dir//" + listAddress[0] + "+" + listAddress[1] + ",+" + zipCode + "+" + city + "/@50.9699123,3.5180066,17z / data = !4m9!4m8!1m0!1m5!1m1!1s0x47c374002c8b2249: 0x86cf1a56b6a9fd7d!2m2!1d3.7398261!2d51.0358584!3e0";
            Device.OpenUri(new Uri(url));
        }
    }
}