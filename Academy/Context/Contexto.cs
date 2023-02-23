using Microsoft.EntityFrameworkCore;

namespace Academy.Models;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
        : base(options)
    {
    }

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