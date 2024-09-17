using Microsoft.EntityFrameworkCore;
using ReceitaCrud.Receitas;

namespace ReceitaCrud.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Receita> Receitas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=receita.sqlite");

        base.OnConfiguring(optionsBuilder);
    }
}
