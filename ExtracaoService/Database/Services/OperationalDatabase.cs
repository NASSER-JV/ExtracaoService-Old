using System;
using System.Collections.Generic;
using System.Linq;
using ExtracaoService.Database.Contexts;
using ExtracaoService.Database.Models;

namespace ExtracaoService.Database.Services
{
    public class OperationalDatabase
    {
        public void InsertNews(Empresa empresa, string titulo, string corpo)
        {
            try
            {
                using (var ctx = new ExtractionContext())
                {
                    var dados = new Noticia
                    {
                        Titulo = titulo,
                        Corpo = corpo,
                        EmpresaId = empresa.Id,
                    };

                    ctx.Noticias.Add(dados);
                    ctx.SaveChanges();
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
                return ctx.Empresas.ToList();
            }
        }
    }
}