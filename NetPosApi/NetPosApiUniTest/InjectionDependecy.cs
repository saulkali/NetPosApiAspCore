using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PyPosApi.common.database.context;
using PyPosApi.common.database.functions;
using PyPosApi.common.security;
using PyPosApi.modules.moduleArticles.model;
using PyPosApi.modules.moduleLogin.model;

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
			serviceCollection.AddTransient<LoginRepository>();
			serviceCollection.AddTransient<ArticlesRepository>();
			serviceCollection.AddTransient<DatabaseContext>();
			serviceCollection.AddTransient<DArticle>();
			serviceCollection.AddTransient<DClient>();
			serviceCollection.AddTransient<DUser>();
			serviceCollection.AddTransient<ILoggerFactory,LoggerFactory>();

			_serviceProvider = serviceCollection.BuildServiceProvider();
			
		
		}
	}
}

