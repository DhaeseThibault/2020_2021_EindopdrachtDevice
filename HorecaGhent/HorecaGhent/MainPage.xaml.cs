using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;

using HorecaGhent.Models;
using HorecaGhent.Repositories;

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
