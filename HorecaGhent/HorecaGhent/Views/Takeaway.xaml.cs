using HorecaGhent.Models;
using HorecaGhent.Repositories;
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
    public partial class Takeaway : ContentPage
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

        public Takeaway()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            TestHorecaRepository();
        }

        private async void TestHorecaRepository()
        {
            string takeawayOrDelivery = MainPage.ListTakeAway[0].ToString();
            
            lblTakeAway.Text = takeawayOrDelivery;
            lblFilter.Text = takeawayOrDelivery + " restaurants:";

            List<Horeca> listTakeawayFilters = await HorecaRepository.GetTakeawayFilter();
            List<Horeca> listDeliveryFilters = await HorecaRepository.GetDeliveryFilter();

            if (takeawayOrDelivery == "Delivery")
            {
                lvwRestaurantsOnFilter.ItemsSource = listDeliveryFilters;
            }
            else
            {
                lvwRestaurantsOnFilter.ItemsSource = listTakeawayFilters;
            }
        }

        private void lvwRestaurantsOnFilter_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedRestaurant = (Horeca)lvwRestaurantsOnFilter.SelectedItem;

            Navigation.PushAsync(new RestaurantInformation(selectedRestaurant));
        }
    }
}