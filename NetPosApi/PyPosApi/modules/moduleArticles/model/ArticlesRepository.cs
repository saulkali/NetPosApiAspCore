using System;
using PyPosApi.common.database.context;
using PyPosApi.modules.moduleArticles.@enum;
using PyPosApi.common.entities;
using PyPosApi.common.database.schemes;
using Microsoft.EntityFrameworkCore;

namespace PyPosApi.modules.moduleArticles.model
{
	public class ArticlesRepository
	{
		private readonly DatabaseContext _databaseContext;

		public ArticlesRepository(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		/// <summary>
		/// retorna un articulo por su codigo de barras
		/// </summary>
		/// <param name="CodeBar"></param>
		/// <param name="Amount"></param>
		/// <returns></returns>
		public async Task<(ArticleEntity?,ArticlesResponseEnum)> GetArticleByCodeBar(string CodeBar,float Amount)
		{
			ArticleEntity? articleEntity = null;
			ArticlesResponseEnum response = ArticlesResponseEnum.Unknow;
			try
			{
				ArticleScheme? article = await _databaseContext.Articles.Where(
					art => art.CodeBar == CodeBar && art.Status == true
				).FirstOrDefaultAsync();
				if (article == null)
					response = ArticlesResponseEnum.NoExists;
				else if (article.Amount > Amount)
					response = ArticlesResponseEnum.AmountInsufficient;
				else
				{
					response = ArticlesResponseEnum.Success;
					articleEntity = new ArticleEntity()
					{

                        Id = article.Id,
						Name = article.Name,
						Amount = article.Amount,
						Price =article.Price,
						Horizontal = article.Horizontal,
						Vertical = article.Vertical,
						Shelf = article.Shelf,
						CodeBar = article.CodeBar,
						IdTypeSale = article.IdTypeSale,
						IdArticleCategory = article.IdArticleCategory,
						IdProvider  = article.IdProvider

					};
				}
			}
			catch (Exception ex)
			{

			}
			return (articleEntity,response);
		}

		/// <summary>
		/// guarda un articulo en la base de datos
		/// </summary>
		/// <param name="articleEntity"></param>
		/// <returns></returns>
		public async Task<ArticlesResponseEnum> Save(ArticleEntity articleEntity)
		{
			ArticlesResponseEnum response = ArticlesResponseEnum.Error;
			try
			{
				bool exists = _databaseContext.Articles.Any(article => article.CodeBar == articleEntity.CodeBar);
				if (exists)
					response = ArticlesResponseEnum.Exists;
				else {
                    ArticleScheme articleScheme = new ArticleScheme()
                    {
                        Name = articleEntity.Name,
                        Amount = articleEntity.Amount,
                        Price = articleEntity.Price,
                        Horizontal = articleEntity.Horizontal,
                        Vertical = articleEntity.Vertical,
                        Shelf = articleEntity.Shelf,
                        CodeBar = articleEntity.CodeBar,
                        IdTypeSale = articleEntity.IdTypeSale,
                        IdArticleCategory = articleEntity.IdArticleCategory,
                        IdProvider = articleEntity.IdProvider
                    };
                    await _databaseContext.AddAsync(articleScheme);
                    await _databaseContext.SaveChangesAsync();
                    response = ArticlesResponseEnum.Success;
                }
				
            }
			catch (Exception ex)
			{

			}
			return response;
		}
	}
}

