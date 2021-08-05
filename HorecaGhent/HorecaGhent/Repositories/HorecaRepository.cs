using System;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using HorecaGhent.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Table;

namespace HorecaGhent.Repositories
{
    public class HorecaRepository
    {
        private const string _BASEAPI = "https://data.stad.gent/api/records/1.0/search/?dataset=koop-lokaal-horeca&q=&rows=215";

        private static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("accept", "application/json");
            return client;
        }

        public static async Task<List<Horeca>> GetHorecas()
        {
            try
            {
                using (HttpClient client = GetHttpClient())
                {
                    string json = await client.GetStringAsync(_BASEAPI);
                    if (json != null)
                    {
                        JObject fullobject = JsonConvert.DeserializeObject<JObject>(json);

                        // Get JSON result objects into a list
                        List<JToken> results = fullobject["records"].Children().ToList();

                        //Serialize JSON results into .NET objects
                        List<Horeca> listHoreca = new List<Horeca>();
                        foreach (JToken result in results)
                        {
                            //JToken.ToObjects is a ahelper method that uses JsonSerializer internally
                            Horeca available = result.ToObject<Horeca>();
                            listHoreca.Add(available);
                        }
                        return listHoreca;

                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<List<Horeca>> GetTakeawayFilter()
        {
            try
            {
                using (HttpClient client = GetHttpClient())
                {
                    string url = _BASEAPI + "&q=afhalen";
                    string json = await client.GetStringAsync(url);
                    if (json != null)
                    {
                        JObject fullobject = JsonConvert.DeserializeObject<JObject>(json);

                        // Get JSON result objects into a list
                        List<JToken> results = fullobject["records"].Children().ToList();

                        //Serialize JSON results into .NET objects
                        List<Horeca> listHoreca = new List<Horeca>();
                        foreach (JToken result in results)
                        {
                            //JToken.ToObjects is a ahelper method that uses JsonSerializer internally
                            Horeca available = result.ToObject<Horeca>();
                            listHoreca.Add(available);
                        }
                        return listHoreca;

                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<List<Horeca>> GetDeliveryFilter()
        {
            try
            {
                using (HttpClient client = GetHttpClient())
                {
                    string url = _BASEAPI + "&q=leveren";
                    string json = await client.GetStringAsync(url);
                    if (json != null)
                    {
                        JObject fullobject = JsonConvert.DeserializeObject<JObject>(json);

                        // Get JSON result objects into a list
                        List<JToken> results = fullobject["records"].Children().ToList();

                        //Serialize JSON results into .NET objects
                        List<Horeca> listHoreca = new List<Horeca>();
                        foreach (JToken result in results)
                        {
                            //JToken.ToObjects is a ahelper method that uses JsonSerializer internally
                            Horeca available = result.ToObject<Horeca>();
                            listHoreca.Add(available);
                        }
                        return listHoreca;

                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private const string _APIKEY = "44796bfa0b95a5cb1c533d8206252a96";
        private const string _APITOKEN = "ea040f39756dccc033149400deebb56301602875525bafd2b39be884f4a3f8f4";
        private const string _BASEURL = "https://api.trello.com/1";
        private const string _BOARDID = "61098e0f3c54145f128ae4b4";
        private const string _RESTAURANTID = "6109c610fa91d91fb22322fc";
        private const string _RESTAURANTNAME = "6109c616763e758a74abf2e7";
        private const string _RESTAURANTOFFER = "6109c9314c8fb65530cd69e3";
        private const string _RESTAURANTKITCHEN = "6109c9381c7a8041cb89a82d";
        private const string _RESTAURANTADDRESS = "6109c93d9840e34e02a480fb";
        private const string _RESTAURANTPHONENUMBER = "6109c944456a247d96b800a7";
        private const string _RESTAURANTSITEURL = "6109c94cc781777caa9f2ecd";

        public static async Task<List<TrelloBoard>> GetTrelloBoardsAsync()
        {
            string url = $"{_BASEURL}/members/me/boards?key={_APIKEY}&token={_APITOKEN}";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    List<TrelloBoard> list = JsonConvert.DeserializeObject<List<TrelloBoard>>(json);
                    return list;
                }
                catch (Exception ex)
                {

                    throw ex; // hier altijd een breakpoint zetten
                    // je applicatie gaat niet stoppen op je foutmelding in xamarin
                }
            }
        }

        public static async Task<List<TrelloList>> GetTrelloListAsync(string boardId)
        {
            string url = $"{_BASEURL}/boards/{boardId}/lists?key={_APIKEY}&token={_APITOKEN}";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    List<TrelloList> list = JsonConvert.DeserializeObject<List<TrelloList>>(json);
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex; // hier altijd een breakpoint zetten
                    // je applicatie gaat niet stoppen op je foutmelding in xamarin
                }
            }
        }

        public static async Task<List<TrelloCard>> GetTrelloCardsAsync(string listId)
        {

            string url = $"{_BASEURL}/list/{listId}/cards?key={_APIKEY}&token={_APITOKEN}";
            using (HttpClient client = GetHttpClient())
            {
                try
                {

                    string json = await client.GetStringAsync(url);
                    List<TrelloCard> list = JsonConvert.DeserializeObject<List<TrelloCard>>(json);
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex; // hier altijd een breakpoint zetten
                    // je applicatie gaat niet stoppen op je foutmelding in xamarin
                }
            }
        }



        public static async Task AddRestaurantId(string listId, TrelloCard card)
        {
            string url = $"{_BASEURL}/cards?idList={_RESTAURANTID}&key={_APIKEY}&token={_APITOKEN}";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(card);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content); //hier geef je mee als je een put moet doen of een post
                    if (!response.IsSuccessStatusCode)
                    {
                        string errorMsg = $"Unsuccesull Put to URL: {url}, object: {json}";
                        throw new Exception(errorMsg);
                    }

                    //string json = await client.GetStringAsync(url);
                    //TrelloCard item = JsonConvert.DeserializeObject<TrelloCard>(json);
                    //return item;
                }
                catch (Exception ex)
                {
                    throw ex; // hier altijd een breakpoint zetten
                    // je applicatie gaat niet stoppen op je foutmelding in xamarin
                }
            }
        }

        public static async Task AddRestaurantName(string listId, TrelloCard card)
        {
            string url = $"{_BASEURL}/cards?idList={_RESTAURANTNAME}&key={_APIKEY}&token={_APITOKEN}";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(card);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content); //hier geef je mee als je een put moet doen of een post
                    if (!response.IsSuccessStatusCode)
                    {
                        string errorMsg = $"Unsuccesull Put to URL: {url}, object: {json}";
                        throw new Exception(errorMsg);
                    }
                }
                catch (Exception ex)
                {
                    throw ex; // hier altijd een breakpoint zetten
                    // je applicatie gaat niet stoppen op je foutmelding in xamarin
                }
            }
        }

        public static async Task AddRestaurantOffer(string listId, TrelloCard card)
        {
            string url = $"{_BASEURL}/cards?idList={_RESTAURANTOFFER}&key={_APIKEY}&token={_APITOKEN}";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(card);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content); //hier geef je mee als je een put moet doen of een post
                    if (!response.IsSuccessStatusCode)
                    {
                        string errorMsg = $"Unsuccesull Put to URL: {url}, object: {json}";
                        throw new Exception(errorMsg);
                    }
                }
                catch (Exception ex)
                {
                    throw ex; // hier altijd een breakpoint zetten
                    // je applicatie gaat niet stoppen op je foutmelding in xamarin
                }
            }
        }

        public static async Task AddRestaurantKitchen(string listId, TrelloCard card)
        {
            string url = $"{_BASEURL}/cards?idList={_RESTAURANTKITCHEN}&key={_APIKEY}&token={_APITOKEN}";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(card);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content); //hier geef je mee als je een put moet doen of een post
                    if (!response.IsSuccessStatusCode)
                    {
                        string errorMsg = $"Unsuccesull Put to URL: {url}, object: {json}";
                        throw new Exception(errorMsg);
                    }
                }
                catch (Exception ex)
                {
                    throw ex; // hier altijd een breakpoint zetten
                    // je applicatie gaat niet stoppen op je foutmelding in xamarin
                }
            }
        }

        public static async Task AddRestaurantAddress(string listId, TrelloCard card)
        {
            string url = $"{_BASEURL}/cards?idList={_RESTAURANTADDRESS}&key={_APIKEY}&token={_APITOKEN}";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(card);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content); //hier geef je mee als je een put moet doen of een post
                    if (!response.IsSuccessStatusCode)
                    {
                        string errorMsg = $"Unsuccesull Put to URL: {url}, object: {json}";
                        throw new Exception(errorMsg);
                    }
                }
                catch (Exception ex)
                {
                    throw ex; // hier altijd een breakpoint zetten
                    // je applicatie gaat niet stoppen op je foutmelding in xamarin
                }
            }
        }

        public static async Task AddRestaurantPhoneNumber(string listId, TrelloCard card)
        {
            string url = $"{_BASEURL}/cards?idList={_RESTAURANTPHONENUMBER}&key={_APIKEY}&token={_APITOKEN}";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(card);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content); //hier geef je mee als je een put moet doen of een post
                    if (!response.IsSuccessStatusCode)
                    {
                        string errorMsg = $"Unsuccesull Put to URL: {url}, object: {json}";
                        throw new Exception(errorMsg);
                    }
                }
                catch (Exception ex)
                {
                    throw ex; // hier altijd een breakpoint zetten
                    // je applicatie gaat niet stoppen op je foutmelding in xamarin
                }
            }
        }

        public static async Task AddRestaurantSiteUrl(string listId, TrelloCard card)
        {
            string url = $"{_BASEURL}/cards?idList={_RESTAURANTSITEURL}&key={_APIKEY}&token={_APITOKEN}";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(card);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content); //hier geef je mee als je een put moet doen of een post
                    if (!response.IsSuccessStatusCode)
                    {
                        string errorMsg = $"Unsuccesull Put to URL: {url}, object: {json}";
                        throw new Exception(errorMsg);
                    }
                }
                catch (Exception ex)
                {
                    throw ex; // hier altijd een breakpoint zetten
                    // je applicatie gaat niet stoppen op je foutmelding in xamarin
                }
            }
        }


    }
}
