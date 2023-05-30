using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;


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

