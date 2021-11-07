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
            var empresas = Environment.GetEnvironmentVariable("Companies");
            var apiKey = Environment.GetEnvironmentVariable("ApiKey");
            var limit = Environment.GetEnvironmentVariable("LimitNews");
            var operational = new Operational();
            operational.ObtainData(empresas, apiKey, limit);
        }
    }
}