using Microsoft.Extensions.Configuration;

namespace SCA.Assets.Data.Options
{
    public class Config : IConfigure
    {
        private readonly IConfiguration _configuration;

        public Config(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            return _configuration.GetSection("ConnectionStrings:Connection").Value;
        }
    }
}
