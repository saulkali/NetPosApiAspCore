using PyPosApi.common.database.context;
using System;
namespace PyPosApi.modules.moduleClient.model
{
	public class ClientRepository
	{
		private readonly ILogger<ClientRepository> _logger;
		private readonly DatabaseContext _databaseContext;
		public ClientRepository(DatabaseContext databaseContext,ILogger<ClientRepository> logger)
		{
			_logger = logger;
			_databaseContext = databaseContext;
		}
	}
}

