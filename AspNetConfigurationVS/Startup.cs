namespace AspNetConfigurationVS
{
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Http;
    using Microsoft.Extensions.Configuration;

    public class Startup
    {
        private readonly IConfigurationRoot _configuration;

        public Startup()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler();

            var setting = _configuration["setting"];
            var defaultConnection = _configuration["data:connectionStrings:default"];

            app.Run(async context =>
            {
                await context.Response.WriteAsync(
                    $"<div>Setting = {setting}</div>" +
                    $"<div>Default Connection = {defaultConnection}</div>");
            });
        }
    }
}