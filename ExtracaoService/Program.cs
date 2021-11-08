using ExtracaoService.Data;
using ExtracaoService.Utilities;

namespace ExtracaoService
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiKey = Common.Config["Settings:ApiKey"];
            var operational = new Operational();
            operational.ObtainData(apiKey);
        }
    }
}