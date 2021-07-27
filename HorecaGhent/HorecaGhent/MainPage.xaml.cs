using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;

using HorecaGhent.Views;
using HorecaGhent.Models;
using HorecaGhent.Repositories;

namespace HorecaGhent
{
    public partial class MainPage : ContentPage
    {
        public static List<string> ListRestaurantName { get; set; } = new List<string>();
        public static List<string> ListRestaurantOffer { get; set; } = new List<string>();
        public static List<string> ListRestaurantKitchen { get; set; } = new List<string>();
        public static List<string> ListRestaurantAddress { get; set; } = new List<string>();
        public static List<string> ListRestaurantZipCode { get; set; } = new List<string>();
        public static List<string> ListRestaurantCity { get; set; } = new List<string>();
        public static List<string> ListRestaurantPhoneNumber { get; set; } = new List<string>();
        public static List<string> ListRestaurantSiteUrl { get; set; } = new List<string>();
        public static List<string> ListTakeAway { get; set; } = new List<string>();

        public MainPage()
        {
            InitializeComponent();
            //TestHorecaRepository();
        }

        private async void TestHorecaRepository()
        {
            List<Horeca> listHorecaNames = await HorecaRepository.GetHorecas();
            lvwRestaurants.ItemsSource = listHorecaNames;

            ListRestaurantName.Clear();
            ListRestaurantOffer.Clear();
            ListRestaurantKitchen.Clear();
            ListRestaurantAddress.Clear();
            ListRestaurantZipCode.Clear();
            ListRestaurantCity.Clear();
            ListRestaurantPhoneNumber.Clear();
            ListRestaurantSiteUrl.Clear();
            ListTakeAway.Clear();
            
        }

        protected override void OnAppearing()
        {
            TestHorecaRepository();
        }

        private void PckChoosen_Takeaway(object sender, EventArgs e)
        {
            if (pckTakeaway.SelectedIndex == 0)
            {
                ListTakeAway.Add("Delivery");
                Navigation.PushAsync(new Takeaway());
            }
            else if (pckTakeaway.SelectedIndex == 1)
            {
                ListTakeAway.Add("Take Away");
                Navigation.PushAsync(new Takeaway());
            }
        }

        private void LvwRestaurant_ItemSelected(object sender, SelectedItemChangedEventArgs e)        {
            var selectedRestaurant = (Horeca)lvwRestaurants.SelectedItem;
            var NameSelectedRestaurant = selectedRestaurant.Name;
            ListRestaurantName.Add(NameSelectedRestaurant.ToString());


            var OfferSelectedRestaurant = selectedRestaurant.Offer;
            if (OfferSelectedRestaurant != null)
            {
                ListRestaurantOffer.Add(OfferSelectedRestaurant.ToString());
            }
            else
            {
                ListRestaurantOffer.Add("");
            }

            var KitchenSelectedRestaurant = selectedRestaurant.Kitchen;
            if (KitchenSelectedRestaurant != null)
            {
                ListRestaurantKitchen.Add(KitchenSelectedRestaurant.ToString());
            }
            else
            {
                ListRestaurantKitchen.Add("");
            }

            var AddressSelectedRestaurant = selectedRestaurant.Address;
            if (AddressSelectedRestaurant != null)
            {
                ListRestaurantAddress.Add(AddressSelectedRestaurant.ToString());
            }
            else
            {
                ListRestaurantAddress.Add("");
            }

            var ZipCodeSelectedRestaurant = selectedRestaurant.ZipCode;
            if (ZipCodeSelectedRestaurant.ToString() != null)
            {
                ListRestaurantZipCode.Add(ZipCodeSelectedRestaurant.ToString());
            }
            else
            {
                ListRestaurantZipCode.Add("");
            }

            var CitySelectedRestaurant = selectedRestaurant.City;
            if (CitySelectedRestaurant != null)
            {
                ListRestaurantCity.Add(CitySelectedRestaurant.ToString());
            }
            else
            {
                ListRestaurantCity.Add("");
            }

            var PhoneNumberSelectedRestaurant = selectedRestaurant.PhoneNumber;
            if (PhoneNumberSelectedRestaurant != null)
            {
                ListRestaurantPhoneNumber.Add(PhoneNumberSelectedRestaurant.ToString());
            }
            else
            {
                ListRestaurantPhoneNumber.Add("");
            }


            var SiteUrlRestaurant = selectedRestaurant.SiteURL;
            if (SiteUrlRestaurant != null)
            {
                ListRestaurantSiteUrl.Add(SiteUrlRestaurant.ToString());
            }
            else
            {
                ListRestaurantSiteUrl.Add("");
            }

            Navigation.PushAsync(new RestaurantInformation());
        }
    }
}
