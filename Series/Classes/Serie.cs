using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }        
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano){
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";

            retorno += $"Genero: {Genero}\n" +
            $"Titulo: {Titulo}\n" +
            $"Descricao: {Descricao}\n" +
            $"Ano: {Ano}\n" +
            $"Excluido: {Excluido}";

            return retorno;
        }

        public string RetornaTitulo(){
            return Titulo;
        }

        public bool RetornaExcluido(){
            return Excluido;
        }

        public int RetornaId(){
            return Id;
        }

        public void Exluir(){
            Excluido = true;
        }

    }
}