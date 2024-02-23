using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Series.Interfaces;

namespace Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public void Atualizar(int id, Serie entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Excluir(int id)
        {
            listaSerie[id].Exluir();
        }

        public void Insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Listar()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornarPorId(int id)
        {
            Serie serie = null;

            try{
                serie = listaSerie[id];
                return serie;
            }
            catch(ArgumentOutOfRangeException ex){
            }

            return serie;
        }
    }
}