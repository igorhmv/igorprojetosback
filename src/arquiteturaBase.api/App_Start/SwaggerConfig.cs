using System.Web.Http;
using WebActivatorEx;
using arquiteturaBase.api;
using Swashbuckle.Application;
using arquiteturaBase.api.Filters;

//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace arquiteturaBase.api
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
            {
                c.DocumentFilter<SwaggerAuthTokenOperationFilter>();
                c.SingleApiVersion("V1", "API do Igor");
                c.PrettyPrint();
                //c.IncludeXmlComments(GetXmlCommentsPath());
                c.DescribeAllEnumsAsStrings();
                c.OperationFilter<SwaggerAuthorizationHeaderFilter>();
            }).EnableSwaggerUi(c =>
            {
                c.DocumentTitle("GMEX API");
                c.DisableValidator();
            });

            SwaggerConfig.MapRoutes(config);
        }

        private static string GetXmlCommentsPath()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory + @"\bin\gmex.Api.XML";
        }

        private static void MapRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "swagger_root",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger")
            );
        }
    }
}
