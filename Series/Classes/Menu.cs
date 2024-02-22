using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Series.Interfaces;

namespace Series.Classes
{
    public class Menu
    {
        SerieRepositorio repositorio = new SerieRepositorio();

        private string ObterOpcaoUsuario(){
            System.Console.WriteLine();
            System.Console.WriteLine("DIO Series a seu dispor!!!");
            System.Console.WriteLine("Informe a opcao desejada:");

            System.Console.WriteLine("1- Listar series");
            System.Console.WriteLine("2- Inserir nova serie");
            System.Console.WriteLine("3- Atualizar serie");
            System.Console.WriteLine("4- Excluir serie");
            System.Console.WriteLine("5- Visualizar serie");
            System.Console.WriteLine("C- Limpar tela");
            System.Console.WriteLine("X- Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();

            return opcaoUsuario;
        }

        public void AbrirMenu(){
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario){
                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        AtualizarSerie();
                        break;

                    case "4":
                        ExcluirSerie();
                        break;

                    case "5":
                        VisualizarSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void ListarSeries()
        {
            System.Console.WriteLine("Listar Series");

            var lista = repositorio.Listar();

            if(lista.Count == 0){
                System.Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            
            foreach(var serie in lista){
                System.Console.WriteLine("#ID {0}: - {1}", serie.RetornaId, serie.RetornaTitulo);
            }


        }
    }
}