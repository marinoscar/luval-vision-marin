using System.Web.Http;
using System.Web.Http.Cors;

namespace luval.vision.pdfconverter
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      EnableCrossSiteRequests(config);
      AddRoutes(config);
    }

    private static void AddRoutes(HttpConfiguration config)
    {
      config.Routes.MapHttpRoute(
        name: "Default",
        routeTemplate: "api/{controller}/{action}/{id}",
        defaults: new { id = RouteParameter.Optional }
      );
    }

    private static void EnableCrossSiteRequests(HttpConfiguration config)
    {
      var cors = new EnableCorsAttribute(
        origins: "*",
        headers: "*",
        methods: "*");
      config.EnableCors(cors);
    }
  }
}