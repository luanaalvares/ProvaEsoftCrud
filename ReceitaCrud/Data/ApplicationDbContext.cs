using Microsoft.EntityFrameworkCore;

namespace ReceitasCrud.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<ReceitaCrud.ReceitasPasta.Receita> Receitas { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=receita.sqlite");

        base.OnConfiguring(optionsBuilder);
    }
}
