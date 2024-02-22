using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Listar();
        T RetornarPorId(int id);
        void Insere(T entidade);
        void Excluir(int id);
        void Atualizar(int id, T entidade);
        int ProximoId();

    }
}