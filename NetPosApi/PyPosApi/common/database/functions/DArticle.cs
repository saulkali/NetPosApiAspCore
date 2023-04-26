using System;
using PyPosApi.common.database.context;
using PyPosApi.common.database.schemes;

namespace PyPosApi.common.database.functions
{
	public class DArticle
	{
		private readonly DatabaseContext _databaseContext;

		public DArticle(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		public async Task<bool> Delete(Guid idArticle)
		{
			bool isDeleted = false;
			try
			{
				ArticleScheme? article = _databaseContext.Articles.Where(art => art.Id == idArticle).FirstOrDefault();
				if (article == null)
					throw new Exception("article not exists");
				_databaseContext.Articles.Remove(article);
				await _databaseContext.SaveChangesAsync();
			}
			catch (Exception ex)
			{

			}
			return isDeleted;
		}

		public async Task<bool> Create(ArticleScheme article)
		{
			bool isCreated = false;
			try
			{
				if (article == null)
					throw new ArgumentNullException($"null {nameof(article)}");

                bool existIdArticle = _databaseContext.Articles.Any(art => art.Id == article.Id);
                if (existIdArticle)
                    throw new Exception("id exist in articles");

                bool existCodeBarArticle = _databaseContext.Articles.Any(art => art.CodeBar == article.CodeBar);
				if (existCodeBarArticle)
					throw new Exception("codebar exist in articles");

				await _databaseContext.Articles.AddAsync(article);
				await _databaseContext.SaveChangesAsync();
			}
			catch (Exception ex)
			{

			}
			return isCreated;
		}
	}
}

