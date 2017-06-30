using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Noticias.Models;

namespace Noticias.Data
{
    public class DBNoticias : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Categoria> Categorias { get; set; }
            
        
        public DBNoticias(DbContextOptions<DBNoticias> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
