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
        public static List<string> ListTakeAway { get; set; } = new List<string>();

        public MainPage()
        {
            InitializeComponent();
            //TestHorecaRepository();
        }

        private Horeca horeca1;
        public MainPage(Horeca horeca)
        {
            InitializeComponent();
            horeca1 = horeca;
        }

        private async void TestHorecaRepository()
        {
            List<Horeca> listHorecaNames = await HorecaRepository.GetHorecas();
            lvwRestaurants.ItemsSource = listHorecaNames;

            ListTakeAway.Clear();

            //string kitchenString = horeca1.Kitchen.ToString();
            //string[] kitchens = kitchenString.Split(';');

            //for (int i = 0; i < kitchens.Length; i++)
            //{
            //    lblKitchens.Text += kitchens[i];
            //}
            
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

        private void Button_Pressed(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FavoriteRestaurant());
        }
    }
}
