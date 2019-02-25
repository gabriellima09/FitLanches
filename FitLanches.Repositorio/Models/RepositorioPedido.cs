using FitLanches.Comum.Interfaces;
using FitLanches.DAL.Context;
using FitLanches.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLanches.Repositorio.Models
{
    public class RepositorioPedido : ICrud<Pedido>
    {
        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Pedido entidade)
        {
            using (var context = new FitLanchesContext())
            {
                context.Pedidos.Add(entidade);
                context.SaveChanges();
            }
        }

        public Pedido SelecionarPorId(int id)
        {
            using (var context = new FitLanchesContext())
            {
                return context.Pedidos.Include("Itens").Single(x => x.Id == id);
            }
        }

        public IList<Pedido> SelecionarTodos()
        {
            using (var context = new FitLanchesContext())
            {
                return context.Pedidos.Include("Itens").ToList();
            }
        }

        public void Alterar(Pedido entidade)
        {
            using (var context = new FitLanchesContext())
            {
                context.Pedidos.Attach(entidade);
                context.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
