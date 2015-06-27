using Hangfire;
using Hangfire.SqlServer;
using Owin;
using System;

namespace Pasted.Web
{
    public partial class Startup
    {
        public void ConfigureHangfire(IAppBuilder app)
        {
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