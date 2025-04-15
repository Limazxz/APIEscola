// Codigo do Arquivo 
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

        //Sobrecarga do método OnModelCreating para configurar o modelo a partir da identityframework
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Custom model configurations can be added here
        }
    }
}
