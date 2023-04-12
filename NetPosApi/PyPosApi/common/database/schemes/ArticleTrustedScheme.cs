using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PyPosApi.common.database.schemes
{
	public class ArticleTrustedScheme:BaseScheme
	{
		public float Price { get; set; }
		public float Amount { get; set; }
		public Guid IdClient { get; set; }
		public Guid IdArticle { get; set; }

		[ForeignKey("IdClient")]
		public virtual ClientsScheme? ClientsScheme { get; set; }

        [ForeignKey("IdClient")]
        public virtual ArticleScheme? ArticleScheme { get; set; }



    }
}

