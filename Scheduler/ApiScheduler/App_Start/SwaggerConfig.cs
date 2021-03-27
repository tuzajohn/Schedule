using System.Web.Http;
using WebActivatorEx;
using ApiScheduler;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ApiScheduler
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                        c.SingleApiVersion("v1", "Shift Scheduller Api");
                    c.IncludeXmlComments(string.Format(@"{0}\bin\ApiScheduler.xml",
                                         System.AppDomain.CurrentDomain.BaseDirectory));
                })
                .EnableSwaggerUi(c =>
                {
                });
        }
    }
}
