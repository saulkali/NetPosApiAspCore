using System;
using PyPosApi.common.database.context;
using PyPosApi.common.database.schemes;

namespace PyPosApi.common.database.functions
{
	public class DClient
	{
		private readonly DatabaseContext _databaseContext;
		private readonly ILogger<DClient> _logger;
        public DClient(DatabaseContext databaseContext,ILogger<DClient> logger)
		{
			_databaseContext = databaseContext;
			_logger = logger;
		}

		public bool Create(ClientsScheme client)
		{
			bool isCreated = false;
			try
			{
				if (client == null)
					throw new ArgumentNullException($"null {nameof(client)}");

				bool existIdClient = _databaseContext.Clients.Any(cli => cli.Id == client.Id);
                if (existIdClient)
					throw new Exception("user id exists");

				bool existINEClient = _databaseContext.Clients.Any(cli => cli.INE == client.INE);
				if (existINEClient)
					throw new Exception("user INE Exists");

				bool existRFCClient = _databaseContext.Clients.Any(cli => cli.RFC == client.RFC);
				if (existRFCClient)
					throw new Exception("user RFC exists");

				_databaseContext.Clients.Add(client);
				_databaseContext.SaveChanges();
			}
			catch (Exception ex)
			{
                _logger.LogError(ex, "Ocurred error");
            }

			return isCreated;
		}

		public async Task<bool> Delete(Guid idClient)
		{
			bool isDeleted = false;
			try
			{
				ClientsScheme? client = _databaseContext.Clients.Where(cli => cli.Id == idClient).FirstOrDefault();
				if (client == null)
					throw new Exception($"client not exists {idClient}");

				_databaseContext.Clients.Remove(client);
				await _databaseContext.SaveChangesAsync();
			}
			catch (Exception ex)
			{
                _logger.LogError(ex, "Ocurred error");
            }

			return isDeleted;
		}
	}
}

