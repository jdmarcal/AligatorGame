using System.Data.Entity;

namespace Models2.DAL
{
    public class Contexto : DbContext    
    {
        public Contexto() : base("stringConn")
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<Contexto>()
                );
        }   
        
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Partida> Partidas { get; set; }
    }
}
