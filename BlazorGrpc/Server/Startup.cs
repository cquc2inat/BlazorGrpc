using BlazorGrpc.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;

namespace BlazorGrpc.Server
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
 //           app.UseHttpMethodOverride();
            app.UseRouting();

            // must be added after UseRouting and before UseEndpoints 
            app.UseGrpcWeb();

            app.UseEndpoints((Action<IEndpointRouteBuilder>)(endpoints =>
            {
                // map to and register the gRPC service
                GrpcEndpointRouteBuilderExtensions.MapGrpcService<WeatherService>(endpoints).EnableGrpcWeb<GrpcServiceEndpointConventionBuilder>();
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            }));

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });

        }
    }
}
