using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Pokedex.Api;
using Pokedex.DataAccessLibrary.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests
{
    public class ApiTests : IDisposable
    {

        protected TestServer _testServer;

        public ApiTests()
        {
            var webBuilder = new WebHostBuilder();
            webBuilder.UseStartup<Startup>();

            _testServer = new TestServer(webBuilder);
        }

        public void Dispose()
        {
            _testServer.Dispose();
        }
    }
}
