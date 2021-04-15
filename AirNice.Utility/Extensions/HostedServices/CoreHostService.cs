using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirNice.Utility.Extensions.HostedServices
{
    public class CoreHostService : IHostedService
    {
        private readonly IHostingEnvironment env;
        public CoreHostService(IHostingEnvironment env)
        {
            this.env = env;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var client = new HttpClient();
            var file = $@"{env.ContentRootPath}\wwwroot\HostedServices\services.json";
            var test = "";
            int i = 12000001;
            //for (int i = 12000001; i <= 12270860; i++)
            //    test += "INC-" + i + ".eml \n ";

         

            //while (true || i <= 12270860)
            //{
            //    var response = await client.GetAsync("http://localhost:52903/api/Passenger/Index");
            //    using (var output = File.OpenWrite(file)) using (var content = await response.Content.ReadAsStreamAsync())
            //    {
            //        content.CopyTo(output);
            //    }

            //    test += "INC-" + i + ".eml \n ";
            //    File.WriteAllText(@"C:\Environment\PP\counter.csv", test);

            //    Thread.Sleep(10000);
            //}
            //i = i + 1;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}