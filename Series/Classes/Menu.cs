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
                opcaoUsuario = ObterOpcaoUsuario();
            }

            System.Console.WriteLine("Obrigado por utilizar nosso seviço");
            Console.ReadLine();
        }

        private void VisualizarSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornarPorId(indiceSerie);

            System.Console.WriteLine(serie);
        }

        private void ExcluirSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        private void AtualizarSerie()
        {

            System.Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Inserir nova serie");

            foreach(int i in Enum.GetValues(typeof(Genero))){
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            System.Console.Write("Digite o genero entre as opcoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o ano de inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a descricao da serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie serie = new Serie(indiceSerie, (Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);

            repositorio.Atualizar(indiceSerie, serie);
        }

        private void InserirSerie()
        {
            System.Console.WriteLine("Inserir nova serie");

            foreach(int i in Enum.GetValues(typeof(Genero))){
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            System.Console.Write("Digite o genero entre as opcoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o ano de inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a descricao da serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(repositorio.ProximoId(), (Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);

            repositorio.Insere(novaSerie);
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
                var excluido = serie.RetornaExcluido();

                System.Console.WriteLine("#ID {0}: - {1} {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }
    }
}