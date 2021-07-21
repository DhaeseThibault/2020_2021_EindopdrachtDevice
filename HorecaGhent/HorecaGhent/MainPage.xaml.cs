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
        public static List<string> listRestaurantName { get; set; } = new List<string>();
        public static List<string> listRestaurantOffer { get; set; } = new List<string>();
        public static List<string> listRestaurantKitchen { get; set; } = new List<string>();
        public static List<string> listRestaurantAddress { get; set; } = new List<string>();
        public static List<int> listRestaurantZipCode { get; set; } = new List<int>();
        public static List<string> listRestaurantCity { get; set; } = new List<string>();
        public static List<string> listRestaurantPhoneNumber { get; set; } = new List<string>();
        public static List<string> listRestaurantSiteUrl { get; set; } = new List<string>();

        public MainPage()
        {
            InitializeComponent();
            //TestHorecaRepository();
        }

        private async void TestHorecaRepository()
        {
            List<Horeca> listHorecaNames = await HorecaRepository.GetHorecas();
            lvwRestaurants.ItemsSource = listHorecaNames;

            listRestaurantName.Clear();
            listRestaurantOffer.Clear();
            listRestaurantKitchen.Clear();
            listRestaurantAddress.Clear();
            listRestaurantZipCode.Clear();
            listRestaurantCity.Clear();
            listRestaurantPhoneNumber.Clear();
            listRestaurantSiteUrl.Clear();
            
        }

        protected override void OnAppearing()
        {
            TestHorecaRepository();
        }

        private void pckChoosen_Takeaway(object sender, EventArgs e)
        {
            if (pckTakeaway.SelectedIndex == 0)
            {
                Navigation.PushAsync(new Takeaway());
            }
            else if (pckTakeaway.SelectedIndex == 1)
            {

            }
        }

        private void lvwRestaurant_ItemSelected(object sender, SelectedItemChangedEventArgs e)        {
            var selectedRestaurant = (Horeca)lvwRestaurants.SelectedItem;
            var NameSelectedRestaurant = selectedRestaurant.Name;
            listRestaurantName.Add(NameSelectedRestaurant.ToString());


            var OfferSelectedRestaurant = selectedRestaurant.Offer;
            if (OfferSelectedRestaurant != "")
            {
                listRestaurantOffer.Add(OfferSelectedRestaurant.ToString());
            }

            var KitchenSelectedRestaurant = selectedRestaurant.Kitchen;
            if (KitchenSelectedRestaurant != "")
            {
                listRestaurantKitchen.Add(KitchenSelectedRestaurant.ToString());
            }

            var AddressSelectedRestaurant = selectedRestaurant.Address;
            if (AddressSelectedRestaurant != "")
            {
                listRestaurantAddress.Add(AddressSelectedRestaurant.ToString());
            }

            var ZipCodeSelectedRestaurant = selectedRestaurant.ZipCode;
            if (ZipCodeSelectedRestaurant.ToString() != "")
            {
                listRestaurantZipCode.Add(ZipCodeSelectedRestaurant);
            }

            var CitySelectedRestaurant = selectedRestaurant.City;
            if (CitySelectedRestaurant != "")
            {
                listRestaurantCity.Add(CitySelectedRestaurant.ToString());
            }

            var PhoneNumberSelectedRestaurant = selectedRestaurant.PhoneNumber;
            if (PhoneNumberSelectedRestaurant != "")
            {
                listRestaurantPhoneNumber.Add(PhoneNumberSelectedRestaurant.ToString());
            }

            var SiteUrlRestaurant = selectedRestaurant.SiteURL;
            if (SiteUrlRestaurant != "")
            {
                listRestaurantSiteUrl.Add(SiteUrlRestaurant.ToString());
            }

            Navigation.PushAsync(new RestaurantInformation());
        }
    }
}
