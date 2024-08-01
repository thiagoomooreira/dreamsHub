using DreamsHub.Models;
using DreamsHub.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DreamsHub.Context
{
    public class ContextModel : DbContext
    {
        protected readonly IConfiguration Configuration;

       
        public ContextModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Metas> Metas { get; set; }
        public DbSet<MovimentacaoMeta> MovimentacaoMetas { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        
            string? connectionString = configuration.GetConnectionString("banco");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}