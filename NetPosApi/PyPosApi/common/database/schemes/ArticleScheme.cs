using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PyPosApi.common.database.schemes
{
	public class ArticleScheme:BaseScheme
	{
		public string Name { get; set; }
		public float Amount { get; set; }
		public float Price { get; set; }
		public string? Horizontal { get; set; }
		public string? Vertical { get; set; }
		public string? Shelf { get; set; }
		public string CodeBar { get; set; }
		public Guid? IdTypeSale { get; set; }
		public Guid? IdArticleCategory { get; set; }
		public Guid? IdProvider { get; set; }

		[ForeignKey("IdTypeSale")]
		public virtual TypeSalesScheme? TypeSalesScheme { get; set; }

        [ForeignKey("IdArticleCategory")]
        public virtual CategoryArticleScheme? CategoryArticleScheme { get; set; }

        [ForeignKey("IdProvider")]
        public virtual ProvidersScheme? ProvidersScheme { get; set; }
    }
}

