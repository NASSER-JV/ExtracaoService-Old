using Microsoft.Extensions.Configuration;

namespace ExtracaoService.Data
{
    public class Common
    {
        public static IConfigurationRoot Config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    }
}