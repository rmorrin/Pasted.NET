using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;
using Hangfire.SqlServer;

[assembly: OwinStartup(typeof(Pasted.Web.Startup))]

namespace Pasted.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            var options = new SqlServerStorageOptions
            {
                // Set to true by default, but the option is there for later use.
                PrepareSchemaIfNecessary = true,
                // Default is 15 secs, options is there for later use.
                QueuePollInterval = TimeSpan.FromSeconds(15),
                // Default is 30 mins, options is there for later use.
                InvisibilityTimeout = TimeSpan.FromMinutes(30)
            };

            GlobalConfiguration.Configuration.UseSqlServerStorage("HangFireDb", options);
            app.UseHangfireDashboard();
            app.UseHangfireServer();

        }
    }
}
