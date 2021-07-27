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
            

            Navigation.PushAsync(new RestaurantInformation(selectedRestaurant));
        }
    }
}
