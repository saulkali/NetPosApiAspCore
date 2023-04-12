using System;
namespace PyPosApi.common.entities
{
	public class ArticleEntity
	{
        public Guid Id { get; set; }
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
        
	}

}

