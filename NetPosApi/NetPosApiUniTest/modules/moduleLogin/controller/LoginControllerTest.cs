using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using Newtonsoft.Json;

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
		public async Task UserNotExistsTest()
		{
			var endPoint = "/api/Login/auth";
            var data = new
            {
                email = "johndoe@example.com",
				password = "test"
            };

			// Serializar el objeto a una cadena JSON
			var json = JsonConvert.SerializeObject(data);

            // Crear el HttpContent con la cadena JSON como contenido
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
			var httpResponse = await _client.PostAsync(endPoint,httpContent);
			Assert.IsTrue(httpResponse.IsSuccessStatusCode);
			
		}
	}
}

