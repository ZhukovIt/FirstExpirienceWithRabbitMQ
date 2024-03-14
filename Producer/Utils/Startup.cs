using Producer.RabbitMQ;
using ProducerLogic.LogMessages;
using ProducerLogic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer.Utils
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton(new SessionFactory(Configuration["ConnectionString"]));
            services.AddScoped<UnitOfWork>();
            services.AddTransient<LogMessageRepository>();
            services.AddSingleton<RPCClient>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandler>();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", (context) => context.Response.WriteAsync("Server is launch!"));
                endpoints.MapControllers();
            });
        }
    }
}
