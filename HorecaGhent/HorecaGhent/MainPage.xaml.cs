using HorecaGhent.Models;
using HorecaGhent.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HorecaGhent
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            TestHorecaRepository();

        }

        private async void TestHorecaRepository()
        {
            List<Horeca> list = await HorecaRepository.GetNamesHoreca();
            lvwRestaurants.ItemsSource = list;

        }
    }
}
