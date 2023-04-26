using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PyPosApi.common.security;

namespace NetPosApiUniTest
{
	public class InjectionDependecy
	{
		protected ServiceProvider _serviceProvider;
		protected IConfiguration Configuration;

        public InjectionDependecy()
		{
			IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json",optional:false,reloadOnChange:true);

			Configuration = configurationBuilder.Build();

			var serviceCollection = new ServiceCollection();
			serviceCollection.AddSingleton(Configuration);

			_serviceProvider = serviceCollection.BuildServiceProvider();
			
		
		}
	}
}

