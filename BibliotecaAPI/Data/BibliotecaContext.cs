using Microsoft.EntityFrameworkCore;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Genero> Generos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>()
            .HasKey(l => l.ID);
           
            modelBuilder.Entity<Livro>()
                .Property(l => l.ID)
                .ValueGeneratedOnAdd();

            
            modelBuilder.Entity<Livro>()
                .HasOne<Autor>()
                .WithMany()
                .HasForeignKey(l => l.AutorID)
                .OnDelete(DeleteBehavior.Restrict); 

            
            modelBuilder.Entity<Livro>()
                .HasOne<Genero>()
                .WithMany()
                .HasForeignKey(l => l.GeneroID)
                .OnDelete(DeleteBehavior.Restrict); 

            
            modelBuilder.Entity<Autor>()
                .Property(a => a.ID)
                .ValueGeneratedOnAdd();

            
            modelBuilder.Entity<Genero>()
                .Property(g => g.ID)
                .ValueGeneratedOnAdd();
        }
    }
}
