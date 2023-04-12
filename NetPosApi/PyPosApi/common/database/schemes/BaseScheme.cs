using System;
using System.ComponentModel.DataAnnotations;

namespace PyPosApi.common.database.schemes
{
	public class BaseScheme
	{
		[Key]
		public Guid Id { get; set; }		
		public DateTime DateCreated { get; set; }
		public bool Status { get; set; }
	}
}

