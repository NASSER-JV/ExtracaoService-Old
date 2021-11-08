using ExtracaoService.Database.Services;
using Newtonsoft.Json;
using RestSharp;

namespace ExtracaoService.Data
{
    public class Operational
    {
        public void ObtainData(string apikey)
        {
            var database = new OperationalDatabase();
            var companies = database.GetCompanies();
            foreach (var company in companies)
            {
                var client = new RestClient("https://financialmodelingprep.com");
                var request = new RestRequest($"api/v3/stock_news?tickers={company.Codigo}&limit=100&apikey={apikey}");
                var response = client.Get(request);
                dynamic responseJson = JsonConvert.DeserializeObject(response.Content);
                foreach (var obj in responseJson)
                {
                    database.InsertNews(company, obj["title"].ToString(), obj["text"].ToString());
                }
            }
        }
    }
}