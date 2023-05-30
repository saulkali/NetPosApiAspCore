using Microsoft.EntityFrameworkCore;
using PyPosApi.common.database.schemes;

namespace PyPosApi.common.database.context
{
    public class DatabaseContext:DbContext
    {
        public DbSet<UserScheme> UserSchemes { get; set; }
        public DbSet<UserRolScheme> UserRolSchemes { get; set; }
        public DbSet<ArticlePayments> ArticlePayments { get; set; }
        public DbSet<ArticleSalesScheme> ArticleSales { get; set; }
        public DbSet<ArticleScheme> Articles { get; set; }
        public DbSet<ArticleTrustedScheme> ArticleTrusteds { get; set; }
        public DbSet<BoxsCuts> BoxsCuts { get; set; }
        public DbSet<CategoryArticleScheme> CategoryArticles { get; set; }
        public DbSet<ClientsScheme> Clients { get; set; }
        public DbSet<ProvidersScheme> Providers { get; set; }
        public DbSet<TypeSalesScheme> TypeSales { get; set; }
      
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }
    }
}
