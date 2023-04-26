using System;
using NUnit.Framework;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using PyPosApi;

namespace NetPosApiUniTest.modules.moduleLogin.controller
{
	[TestFixture]
	public class LoginControllerTest:InjectionDependecy
	{
		protected TestServer _server;
		protected HttpClient _client;

		[OneTimeSetUp]
		public void SetUp()
		{
			IWebHostBuilder builder = new WebHostBuilder()
				.UseEnvironment("Development")
				.UseStartup<IStartup>();
			_server = new TestServer(builder);
			_client = _server.CreateClient();
			
		}

		[Test]
		public async Task GetLoginTest()
		{
			HttpResponseMessage response = await _client.GetAsync("/api/Login/auth");
		}
	}
}

