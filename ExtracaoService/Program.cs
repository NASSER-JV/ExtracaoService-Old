using System;
using ExtracaoService.Data;

namespace ExtracaoService
{
    class Program
    {
        static void Main(string[] args)
        {
            var empresas = Environment.GetEnvironmentVariable("Companies", EnvironmentVariableTarget.Machine);
            var apiKey = Environment.GetEnvironmentVariable("ApiKey", EnvironmentVariableTarget.Machine);
            var limit = Environment.GetEnvironmentVariable("LimitNews", EnvironmentVariableTarget.Machine);
            var operational = new Operational();
            operational.ObtainData(empresas, apiKey, limit);
        }
    }
}