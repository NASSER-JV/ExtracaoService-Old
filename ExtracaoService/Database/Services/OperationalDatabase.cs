using System;
using System.Collections.Generic;
using System.Linq;
using ExtracaoService.Data.Entities;
using ExtracaoService.Database.Contexts;
using ExtracaoService.Database.Models;

namespace ExtracaoService.Database.Services
{
    public class OperationalDatabase
    {
        public void InsertNews(Empresa empresa, NewsDto news)
        {
            try
            {
                using (var ctx = new ExtractionContext())
                {
                    if (!ctx.Noticias.Any(c => c.Url.Equals(news.url)))
                    {
                        var dados = new Noticia
                        {
                            Titulo = news.title,
                            Corpo = news.text,
                            Url = news.url,
                            EmpresaId = empresa.Id,
                        };

                        ctx.Noticias.Add(dados);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        public List<Empresa> GetCompanies()
        {
            using (var ctx = new ExtractionContext())
            {
                return ctx.Empresas.Where(c => c.Ativo).ToList();
            }
        }
    }
}