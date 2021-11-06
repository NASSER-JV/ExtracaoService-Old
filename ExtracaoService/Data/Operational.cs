using ExtracaoService.Database.Services;
using Newtonsoft.Json;
using RestSharp;

namespace ExtracaoService.Data
{
    public class Operational
    {
        public void ObtainData()
        {
            var client = new RestClient("https://financialmodelingprep.com");
            var request = new RestRequest("api/v3/stock_news?tickers=AAPL&limit=50&apikey=b707642b3b91beeba687a7c84e858150");
            var response = client.Get(request);
            dynamic responseJson = JsonConvert.DeserializeObject(response.Content);
            foreach (var obj in responseJson)
            {
                var database = new OperationalDatabase();
                database.Insert(obj["symbol"].ToString(), "Apple", obj["title"].ToString(), obj["text"].ToString());
            }
        }
    }
}