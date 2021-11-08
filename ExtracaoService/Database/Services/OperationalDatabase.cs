using System;
using System.Linq;
using ExtracaoService.Database.Contexts;
using ExtracaoService.Database.Models;

namespace ExtracaoService.Database.Services
{
    public class OperationalDatabase
    {
        public void Insert(string codigo, string nomeEmpresa, string titulo, string corpo)
        {
            try
            {
                using (var ctx = new ExtractionContext())
                {
                    var empresa = new Empresa();

                    empresa = ctx.Empresas.FirstOrDefault(s => s.Nome.Contains(nomeEmpresa));
                    if (empresa == null)
                    {
                        empresa = new Empresa
                        {
                            Codigo = codigo,
                            Nome = nomeEmpresa,
                        };

                        ctx.Empresas.Add(empresa);
                        ctx.SaveChanges();
                    }


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
    }
}