using System;
using Microsoft.AspNetCore.Mvc;
using PyPosApi.modules.moduleArticles.model;
using PyPosApi.common.entities;
using PyPosApi.modules.moduleArticles.@enum;

namespace PyPosApi.modules.moduleArticles.controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticlesController: ControllerBase
	{
		private readonly ArticlesRepository _repository;
		public ArticlesController(ArticlesRepository repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// guarda un nuevo registro en la base de datos
		/// </summary>
		/// <param name="articleEntity"></param>
		/// <returns></returns>
		[HttpPost("save-article")]
		public async Task<ActionResult> SaveArticle([FromForm] ArticleEntity articleEntity)
		{
			ResponseEntity responseEntity = await _repository.Save(articleEntity);
            return Ok(responseEntity);
		}

		/// <summary>
		/// busca un articulo por su codigo de barras
		/// </summary>
		/// <param name="CodeBar"></param>
		/// <param name="Amount"></param>
		/// <returns></returns>
		[HttpGet("get-article-code-bar/{CodeBar}/{Amount}")]
		public async Task<ActionResult> GetArticleByBarCode(string CodeBar,float Amount)
		{
			ResponseEntity responseEntity = await _repository.GetArticleByCodeBar(CodeBar,Amount);
			return Ok(responseEntity);
		}
	}
}

