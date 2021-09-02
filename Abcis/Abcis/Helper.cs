using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms; 
using System.Net.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

namespace Abcis
{ 
    public static class Helper
    {
        private static readonly string baseURL = "https://localhost:5001/api/";
        public static async Task<object> GetAll()
        {
            using  (HttpClient client  = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + "abcis"))
                {

                    var data = res.Content.ReadAsAsync<IEnumerable<GetAbcis>>().Result;

                    if(data != null)
                    {
                        return data;
                    } 
                }
            }
            return string.Empty;
        }

        public static async Task<object> Get(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + "abcis/"+ id))
                {

                    var data = res.Content.ReadAsAsync<GetAbcis>().Result;

                    if (data != null)
                    {
                        return data;
                    }

                }
            }
            return string.Empty;
        }

        public static async Task<string> Post(string plu, string ordercode, string description, string cost, string sell)
        {
            var input_data = new Dictionary<string, string>
            {
                { "plu", plu },
                { "ordercode", ordercode },
                { "description", description },
                { "cost", cost },
                { "sell", sell }
            };
            var input_content = new FormUrlEncodedContent(input_data);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync(baseURL + "abcis", input_content))
                { 
                    //var data = res.Content.ReadAsAsync<IEnumerable<GetAbcis>>().Result;

                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if( data != null )
                        {
                            return data;
                        }
                    } 
                }
            }
            return string.Empty;
        }

        public class InputData
        {
            public int ID { get; set; }
            public string Plu { get; set; }
            public string OrderCode { get; set; }
            public string Description { get; set; }
            public string Cost { get; set; }
            public string Sell { get; set; }
        }

        public static async Task<string> PUT(string id, string plu, string ordercode, string description, string cost, string sell)
        {

            var input_data = new Dictionary<string, string>
            {
                { "plu", plu },
                { "ordercode", ordercode },
                { "description", description },
                { "cost", cost },
                { "sell", sell }
            };

            var input_content = new FormUrlEncodedContent(input_data);
              
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PutAsync(baseURL + "abcis/"+id, input_content))
                {
                    //var data = res.Content.ReadAsAsync<IEnumerable<GetAbcis>>().Result;

                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }

        public static string BeautifyJson(string jsonStr)
        {
            JToken parseJson = JToken.Parse(jsonStr);
            return parseJson.ToString(Formatting.Indented);
        }

    }
}
