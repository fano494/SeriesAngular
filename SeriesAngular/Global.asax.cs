using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SeriesAngularWebAPI;
using System.Globalization;
using System.Web.Http;

namespace AcademiaWebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var settings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;

            settings.Culture = new CultureInfo("es-ES");
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
        }
    }
}
