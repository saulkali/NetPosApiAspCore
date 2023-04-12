using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PyPosApi.common.database.schemes
{
	public class ArticlePayments:BaseScheme
	{
		public float Amount { get; set; }
		public Guid IdArticleTrusted { get; set; }

		[ForeignKey("IdArticleTrusted")]
		public virtual ArticleTrustedScheme? ArticleTrustedScheme { get; set; }
	}
}

