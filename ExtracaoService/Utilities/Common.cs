using Microsoft.Extensions.Configuration;

namespace ExtracaoService.Utilities
{
    public class Common
    {
        public static IConfigurationRoot Config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    }
}