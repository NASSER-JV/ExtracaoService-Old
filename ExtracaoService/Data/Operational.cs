using ExtracaoService.Database.Services;
using Newtonsoft.Json;
using RestSharp;

namespace ExtracaoService.Data
{
    public class Operational
    {
        public void ObtainData(string empresas, string apikey, string limit)
        {
            var empresasSeparadas = empresas.Split(",");

            foreach (var emp in empresasSeparadas)
            {
                var client = new RestClient("https://financialmodelingprep.com");
                var request = new RestRequest($"api/v3/stock_news?tickers={emp}&limit={limit}&apikey={apikey}");
                var response = client.Get(request);
                dynamic responseJson = JsonConvert.DeserializeObject(response.Content);
                foreach (var obj in responseJson)
                {
                    var database = new OperationalDatabase();
                    database.Insert(obj["symbol"].ToString(), emp.Trim(), obj["title"].ToString(), obj["text"].ToString());
                }
            }
        }
    }
}