using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PyPosApi.common.database.schemes
{
	public class ArticleSalesScheme:BaseScheme
	{
		public float Price { get; set; }
		public float Amount { get; set; }
		public Guid IdUser { get; set; }
		public Guid IdArticle { get; set; }
		public Guid? IdCliente { get; set; }

		[ForeignKey("IdUser")]
		public virtual UserScheme? UserScheme { get; set; }

        [ForeignKey("IdArticle")]
        public virtual ArticleScheme? ArticleScheme { get; set; }

        [ForeignKey("IdCliente")]
        public virtual ClientsScheme? ClientScheme { get; set; }
    }
}

