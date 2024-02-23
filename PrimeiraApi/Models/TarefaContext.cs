using Microsoft.EntityFrameworkCore;

namespace PrimeiraApi.Models
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options)
        : base(options)
        {
        }

        public DbSet<Tarefas> Tarefas { get; set; }
    }
}
