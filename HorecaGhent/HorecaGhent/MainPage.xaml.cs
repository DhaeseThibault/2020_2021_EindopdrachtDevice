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
        public MainPage()
        {
            InitializeComponent();
            //TestHorecaRepository();
        }

        private async void TestHorecaRepository()
        {
            List<Horeca> listHorecaNames = await HorecaRepository.GetNamesHoreca();
            lvwRestaurants.ItemsSource = listHorecaNames;

            List<Horeca> listKitchenFilterBelgisch = await HorecaRepository.GetKitchenFilterBelgisch();
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

    }
}
