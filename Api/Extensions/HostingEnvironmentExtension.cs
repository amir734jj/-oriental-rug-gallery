using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Api.Extensions
{
    public static class HostingEnvironmentExtension
    {
        /// <summary>
        /// Test whether environment is localhost
        /// </summary>
        /// <param name="environment"></param>
        /// <returns></returns>
        public static bool IsLocalhost(this IWebHostEnvironment environment)
        {
            return environment.IsEnvironment("Localhost");
        }

        /// <summary>
        /// Test whether environment is development
        /// </summary>
        /// <param name="environment"></param>
        /// <returns></returns>
        public static bool IsDevelopment(this IWebHostEnvironment environment)
        {
            return environment.IsEnvironment("Development");
        }

        /// <summary>
        /// Test whether environment is stage
        /// </summary>
        /// <param name="environment"></param>
        /// <returns></returns>
        public static bool IsStage(this IWebHostEnvironment environment)
        {
            return environment.IsEnvironment("Stage");
        }
    }
}