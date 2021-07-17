using System;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using HorecaGhent.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public static async Task<List<Horeca>> GetNamesHoreca()
        {
            try
            {
                using (HttpClient client = GetHttpClient())
                {
                    //string url = _BASEAPI + "";
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
    }
}
