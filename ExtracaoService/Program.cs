using System;
using ExtracaoService.Data;

namespace ExtracaoService
{
    class Program
    {
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