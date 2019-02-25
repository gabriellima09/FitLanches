using FitLanches.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLanches.DAL.Context
{
    public class FitLanchesContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItensPedido> Itens { get; set; }

        public FitLanchesContext() : base (@"Data Source = (localDb)\MSSQLLocalDb; Initial Catalog = FitLanches; Integrated Security = true")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer<FitLanchesContext>(new CreateDatabaseIfNotExists<FitLanchesContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItensPedido>()
                .HasRequired(p => p.Pedido)
                .WithMany(i => i.Itens)
                .HasForeignKey(fk => fk.PedidoId)
                .WillCascadeOnDelete(true);
        }
    }
}
