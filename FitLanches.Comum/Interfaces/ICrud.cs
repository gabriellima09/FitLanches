using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLanches.Comum.Interfaces
{
    public interface ICrud<T> where T : class
    {
        void Inserir(T entidade);
        void Alterar(T entidade);
        void Excluir(int id);
        IList<T> SelecionarTodos();
        T SelecionarPorId(int id);
    }
}
