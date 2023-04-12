using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PyPosApi.common.database.schemes
{
	public class BoxsCuts:BaseScheme
	{
		public float Amount { get; set; }
		public int TypeCut { get; set; }
		public Guid IdUser { get; set; }

		[ForeignKey("IdUser")]
		public virtual UserScheme? UserScheme { get; set; }
	}
}

