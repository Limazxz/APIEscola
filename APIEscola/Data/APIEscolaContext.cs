// Codigo do Arquivo 
using APIEscola.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIEscola.Data
{
    public class APIEscolaContext : IdentityDbContext
    {
        //construtor que recebe as opções de configuração do DbContext
        public APIEscolaContext(DbContextOptions<APIEscolaContext> options) : base(options)
        {
        }

        //propriedade Dbset para cada tabela do banco de dados
        public DbSet<Aluno> Alunos { get; set; }//Tabela de Alunos
        public DbSet<Curso> Cusos { get; set; }//Tabela de Cursos
        public DbSet<Turma> Turmas { get; set; }//Tabela de Turmas
        public DbSet<Matricula> Matriculas { get; set; }//Tabela de Matriculas




        //Sobrecarga do método OnModelCreating para configurar o modelo a partir da identityframework
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Custom model configurations can be added here
            modelBuilder.Entity<Aluno>().ToTable("Alunos");//define o nome da tabela no banco de dados

            modelBuilder.Entity<Curso>().ToTable("Cursos");//define o nome da tabela no banco de dados

            modelBuilder.Entity<Turma>().ToTable("Turmas");//define o nome da tabela no banco de dados

            modelBuilder.Entity<Matricula>().ToTable("Matriculas");//define o nome da tabela no banco de dados

        }
    }
}
