using System;
using ExtracaoService.Database.Contexts;
using ExtracaoService.Database.Models;
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
            // try
            // {
            //     using (var ctx = new ExtractionContext())
            //     {
            //         var empresa = new Empresa();
            //         empresa.Codigo = "AAPL";
            //         empresa.Id = 1;
            //         empresa.Nome = "Apple";
            //
            //         var dados = new Noticia();
            //         dados.Corpo = "Teste";
            //         dados.Id = 1;
            //         dados.EmpresaId = 1;
            //         dados.Titulo = "TesteNoticia";
            //
            //
            //         ctx.Empresas.Add(empresa);
            //         ctx.Noticias.Add(dados);
            //         ctx.SaveChanges();
            //     }
            // }
            // catch (Exception e)
            // {
            //     throw new Exception(e.Message);
            // }
        }
    }
}