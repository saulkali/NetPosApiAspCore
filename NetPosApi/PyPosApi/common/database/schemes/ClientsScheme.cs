using System;
namespace PyPosApi.common.database.schemes
{
	public class ClientsScheme:BaseScheme
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string INE { get; set; }
		public string RFC { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Phone { get; set; }
		public int CodePostal { get; set; }
		public bool ListBlack { get; set; }
	}
}

