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
    }
}