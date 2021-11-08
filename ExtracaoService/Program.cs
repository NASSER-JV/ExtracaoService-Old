using System;
using ExtracaoService.Data;
using Microsoft.Extensions.Configuration;

namespace ExtracaoService
{
    class Program
    {
        public static IConfigurationRoot Config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        static void Main(string[] args)
        {
            
            var empresas = Config["Settings:Companies"];
            var apiKey = Config["Settings:ApiKey"];
            var limit = Config["Settings:LimitNews"];
            var operational = new Operational();
            operational.ObtainData(empresas, apiKey, limit);
        }
    }
}