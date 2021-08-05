using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using HorecaGhent.Models;
using HorecaGhent.Repositories;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HorecaGhent.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantInformation : ContentPage
    {
        public RestaurantInformation()
        {
            InitializeComponent();
        }

        private Horeca horeca1;
        public RestaurantInformation(Horeca horeca)
        {
            InitializeComponent();
            horeca1 = horeca;
        }

        protected override void OnAppearing()
        {
            TestHorecaRepository();
        }

        private async void TestHorecaRepository()
        {
            lblOffer.Text = "";
            lblKitchen.Text = "";

            // Showing the restaurant name in the topbar
            lblRestaurantName.Text = horeca1.Name;


            // Showing all the offers in the body
            string offersString = horeca1.Offer.ToString();
            string[] offers = offersString.Split(';');

            for (int i = 0; i < offers.Length; i++)
            {
                lblOffer.Text += "- " + offers[i] + "\n";
            }

            // Showing all the kitchen types in the body
            string kitchensString = horeca1.Kitchen.ToString();
            string[] kitchens = kitchensString.Split(';');

            for (int i = 0; i < kitchens.Length; i++)
            {
                lblKitchen.Text += "- " + kitchens[i] + "\n";
            }


            // Showing the restaurant addresss
            lblAddress.Text = "- " + horeca1.Address + ", " + horeca1.ZipCode + " " + horeca1.City;

            
            // Showing the PhoneNumber of the restaurant
            string phoneNumber = horeca1.PhoneNumber;
            if (phoneNumber != null)
            {
                lblPhoneNumber.Text = "- " +  horeca1.PhoneNumber;
            }
            else
            {
                lblPhoneNumber.Text = "- Not Available";
            }

            //Showing the URL of the restaurants site
            lblSiteUrl.Text = horeca1.SiteURL;
        }

        private void PhoneNumberTapped(object sender, EventArgs e)
        {
            string phoneNumber = horeca1.PhoneNumber;
            if (phoneNumber != null)
            {
                PhoneDialer.Open(phoneNumber);
            }
        }

        private void SiteUrlTapped(object sender, EventArgs e)
        {
            string siteUrl = horeca1.SiteURL;
            if (siteUrl != null)
            {
                Device.OpenUri(new Uri(siteUrl));
            }
        }

        private void AddressTapped(object sender, EventArgs e)
        {
            string address = horeca1.Address;
            string zipCode = horeca1.ZipCode.ToString();
            string city = horeca1.City;

            string[] listAddress = address.Split(' ');


            string url = "https://www.google.be/maps/dir//" + listAddress[0] + "+" + listAddress[1] + ",+" + zipCode + "+" + city + "/@50.9699123,3.5180066,17z / data = !4m9!4m8!1m0!1m5!1m1!1s0x47c374002c8b2249: 0x86cf1a56b6a9fd7d!2m2!1d3.7398261!2d51.0358584!3e0";
            if (url != null)
            {
                Device.OpenUri(new Uri(url));
            }
        }

        private async void Button_Pressed(object sender, EventArgs e)
        {
            // 1. Board select
            List<TrelloBoard> boardsList = await HorecaRepository.GetTrelloBoardsAsync();
            TrelloBoard selectedBoard = boardsList.Where(x => x.IsFavorite == true).First();    // geef mij alle items waar isFavorite true is, Dit is een if stuctuur

            // 2. Trello Lists
            List<TrelloList> trelloLists = await HorecaRepository.GetTrelloListAsync(selectedBoard.BoardId);

            // 3. Add Trello Cards
            string RestaurantId = horeca1.recordid;
            string RestaurantName = horeca1.Name;
            string RestaurantOffer = horeca1.Offer;
            string RestaurantKitchen = horeca1.Kitchen;
            string RestaurantAddress = horeca1.Address + ", " + horeca1.ZipCode + " " + horeca1.City;
            string RestaurantPhoneNumber = horeca1.PhoneNumber;
            string RestaurantSiteUrl = horeca1.SiteURL;

            TrelloCard newCardId = new TrelloCard { Name = RestaurantId, IsClosed = false };
            TrelloCard newCardName = new TrelloCard { Name = RestaurantName, IsClosed = false };
            TrelloCard newCardOffer = new TrelloCard { Name = RestaurantOffer, IsClosed = false };
            TrelloCard newCardKitchen = new TrelloCard { Name = RestaurantKitchen, IsClosed = false };
            TrelloCard newCardAddress = new TrelloCard { Name = RestaurantAddress, IsClosed = false };
            TrelloCard newCardPhoneNumber = new TrelloCard { Name = RestaurantPhoneNumber, IsClosed = false };
            TrelloCard newCardSiteUrl = new TrelloCard { Name = RestaurantSiteUrl, IsClosed = false };

            await HorecaRepository.AddRestaurantId(trelloLists[0].ListId, newCardId);
            await HorecaRepository.AddRestaurantName(trelloLists[0].ListId, newCardName);
            await HorecaRepository.AddRestaurantOffer(trelloLists[0].ListId, newCardOffer);
            await HorecaRepository.AddRestaurantKitchen(trelloLists[0].ListId, newCardKitchen);
            await HorecaRepository.AddRestaurantAddress(trelloLists[0].ListId, newCardAddress);
            await HorecaRepository.AddRestaurantPhoneNumber(trelloLists[0].ListId, newCardPhoneNumber);
            await HorecaRepository.AddRestaurantSiteUrl(trelloLists[0].ListId, newCardSiteUrl);

           
        }
    }
}