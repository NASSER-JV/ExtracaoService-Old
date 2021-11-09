using System;
using System.Linq;
using System.Net;
using ExtracaoService.Data.Entities;
using ExtracaoService.Database.Contexts;
using ExtracaoService.Database.Models;
using ExtracaoService.Database.Services;
using ExtracaoService.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace ExtracaoService.Tests
{
    [TestClass]
    public class OperationalTests
    {

        [TestMethod]
        public void SearchCompaniesInDatabase()
        {
            var database = new OperationalDatabase();

            var apple = new Empresa()
            {
                Ativo = true,
                Nome = "Apple",
            };
            
            var companiesDatabase = database.GetCompanies();
            
            Assert.AreEqual(apple.Nome, companiesDatabase.Where(c => c.Nome == apple.Nome));
        }
        
        [TestMethod]
        public void RequestInExternalAPIShouldReturnStatusOk()
        {
            var apiKey = Common.Config["Settings:ApiKey"];
            var client = new RestClient("https://financialmodelingprep.com");
            var request = new RestRequest($"api/v3/stock_news?tickers=AAPL&limit=1&apikey={apiKey}");
            var response = client.Get(request).StatusCode;
            Assert.Equals(HttpStatusCode.OK, response);
        }
        
        [TestMethod]
        public void InsertNewsInDatabase()
        {
            var ctx = new ExtractionContext();
            var empresa = ctx.Empresas.Where(e => e.Nome.Contains("Apple")).FirstOrDefault();
            var diaAtual = DateTime.Now.Date;
            var database = new OperationalDatabase();
            var news = new NewsDto()
            {
                text = "teste unitario",
                title = $"teste unitario - {diaAtual}",
                url = $"teste {diaAtual}"
            };
            database.InsertNews(empresa, news);
            Assert.IsTrue(ctx.Noticias.Any(n => n.Titulo == $"teste unitario - {diaAtual}"));
        }
    }
}