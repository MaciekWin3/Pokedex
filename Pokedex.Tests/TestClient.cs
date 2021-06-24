using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Pokedex.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests
{
    public class TestClient
    {
        public HttpClient Client { get; private set; }

        public TestClient()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = server.CreateClient();
        }
    }
}
