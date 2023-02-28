using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Academy.Models;

public class Contexto : DbContext
{

    public IConfiguration Configuration { get; }
    private readonly IHttpContextAccessor _httpContextAccessor;
    public Contexto(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=DatabaseAcademia;");

    public DbSet<Aluno> Alunos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>().HasData(  //popula a tabela
            new Aluno
            {
                Id = 1,
                Nome = "Monica Chiesa"
            },
            new Aluno
            {
                Id = 2,
                Nome = "Marcio Kussler"
            }
            );

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Aluno>()
        .HasKey(a => a.Id);
    }

}