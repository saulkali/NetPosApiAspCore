using System;
using PyPosApi.common.database.context;
using PyPosApi.common.database.schemes;

namespace PyPosApi.common.database.functions
{
	public class DClient
	{
		private readonly DatabaseContext _databaseContext;
        public DClient(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
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

			}

			return isCreated;
		}
	}
}

