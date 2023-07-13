using System;
using PyPosApi.common.database.context;
using PyPosApi.modules.moduleArticles.@enum;
using PyPosApi.common.entities;
using PyPosApi.common.database.schemes;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace PyPosApi.modules.moduleArticles.model
{
	public class ArticlesRepository
	{
		private readonly DatabaseContext _databaseContext;
		private readonly ILogger<ArticlesRepository> _logger;

		public ArticlesRepository(DatabaseContext databaseContext,ILogger<ArticlesRepository> logger)
		{
			_databaseContext = databaseContext;
			_logger = logger;
		}

		/// <summary>
		/// retorna un articulo por su codigo de barras
		/// </summary>
		/// <param name="CodeBar"></param>
		/// <param name="Amount"></param>
		/// <returns></returns>
		public async Task<ResponseEntity> GetArticleByCodeBar(string CodeBar,float Amount)
		{
			ResponseEntity responseEntity = new ResponseEntity();

			ArticleEntity? articleEntity = null;
			responseEntity.Status = (int)ArticlesResponseEnum.Unknow;

			try
			{
				ArticleScheme? article = await _databaseContext.Articles.Where(
					art => art.CodeBar == CodeBar && art.Status == true
				).FirstOrDefaultAsync();
				if (article == null)
                    responseEntity.Status = (int)ArticlesResponseEnum.NoExists;
				else if (article.Amount > Amount)
                    responseEntity.Status = (int)ArticlesResponseEnum.AmountInsufficient;
				else
				{
                    responseEntity.Status = (int)ArticlesResponseEnum.Success;
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
					responseEntity.Data = JsonConvert.SerializeObject(articleEntity);
				}
			}
			catch (Exception ex)
			{

                _logger.LogError(ex, "Ocurred error");
                responseEntity.Message += ex.Message;
			}

			return responseEntity;
		}

		/// <summary>
		/// guarda un articulo en la base de datos
		/// </summary>
		/// <param name="articleEntity"></param>
		/// <returns></returns>
		public async Task<ResponseEntity> Save(ArticleEntity articleEntity)
		{
			ResponseEntity resposeEntity = new ResponseEntity();
			resposeEntity.Message = "Error Unknow: ";
			resposeEntity.Status = (int)ArticlesResponseEnum.Error;

			try
			{
				bool exists = _databaseContext.Articles.Any(article => article.CodeBar == articleEntity.CodeBar);
				if (exists)
                    resposeEntity.Status = (int)ArticlesResponseEnum.Exists;
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
                    resposeEntity.Status = (int)ArticlesResponseEnum.Success;
                }
				
            }
			catch (Exception ex)
			{

                _logger.LogError(ex, "Ocurred error");
                resposeEntity.Message += ex.Message;
			}

			return resposeEntity;
		}
	}
}

