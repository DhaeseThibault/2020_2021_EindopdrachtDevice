using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HorecaGhent.Models;
using HorecaGhent.Repositories;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HorecaGhent.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoriteRestaurant : ContentPage
    {
        public static List<string> ListRestaurantNames { get; set; } = new List<string>();
        //public static List<string> names { get; set; } = new List<string>();

        public FavoriteRestaurant()
        {
            InitializeComponent();
            //TestHorecaRepository();
        }

        protected override void OnAppearing()
        {
            TestHorecaRepository();
        }

        private async void TestHorecaRepository()
        {
            // 1. Board select
            List<TrelloBoard> boardsList = await HorecaRepository.GetTrelloBoardsAsync();
            TrelloBoard selectedBoard = boardsList.Where(x => x.IsFavorite == true).First(); // geef mij alle items waar isFavorite true is, Dit is een if stuctuur

            // 2. Trellolists
            List<TrelloList> trelloLists = await HorecaRepository.GetTrelloListAsync(selectedBoard.BoardId);


            //TrelloCard searchRestaurantId = (await HorecaRepository.GetTrelloCardsAsync(trelloLists[0].ListId)).FirstOrDefault();
            //List<TrelloCard> searchRestaurantId = (await HorecaRepository.GetTrelloCardsAsync(trelloLists[0].ListId));




            List<TrelloCard> searchRestaurantName = (await HorecaRepository.GetTrelloCardsAsync(trelloLists[1].ListId));
            lvwFavorites.ItemsSource = searchRestaurantName;
            //TrelloCard searchRestaurantOffer = (await HorecaRepository.GetTrelloCardsAsync(trelloLists[2].ListId)).FirstOrDefault();
            //TrelloCard searchRestaurantKitchen = (await HorecaRepository.GetTrelloCardsAsync(trelloLists[3].ListId)).FirstOrDefault();
            //TrelloCard searchRestaurantAddress = (await HorecaRepository.GetTrelloCardsAsync(trelloLists[4].ListId)).FirstOrDefault();
            //TrelloCard searchRestaurantPhoneNumber = (await HorecaRepository.GetTrelloCardsAsync(trelloLists[5].ListId)).FirstOrDefault();
            //TrelloCard searchRestaurantSiteUrl = (await HorecaRepository.GetTrelloCardsAsync(trelloLists[6].ListId)).FirstOrDefault();
        }

        private void Button_Pressed(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());

        }

        private void lvwFavorites_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedRestaurant = (Horeca)lvwFavorites.SelectedItem;

            Navigation.PushAsync(new RestaurantInformation(selectedRestaurant));
        }
    }
}