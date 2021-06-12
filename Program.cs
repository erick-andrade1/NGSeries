using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
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

        }

        private static void ListarSeries(){
            Console.WriteLine("Lista das séries: ");
            var lista  = repositorio.lista();

            if(lista.Count == 0){
                Console.WriteLine("Lista vazia, nenhuma série cadastradas!");
                return;
            }

            foreach(var serie in lista){
                var disponivel = serie.disponibilidade();
                if(disponivel){
                    Console.WriteLine($"{serie.retornaId()}: - {serie.retornaTitulo()} - Série disponível: {disponivel}");
                }
            }
        }

        private static void InserirSerie(){
            Console.WriteLine("Inserir uma série: ");

            repositorio.insere(MenuInsereAtualiza(repositorio.proximoId()));
        }

        private static void AtualizarSerie(){
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.atualiza(indiceSerie, MenuInsereAtualiza(indiceSerie));
            
        }

        private static void VisualizarSerie(){
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.retornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void ExcluirSerie(){
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.exclui(indiceSerie);
            Console.WriteLine("Série excluída!");
        }

        private static Serie MenuInsereAtualiza(int id){

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de Início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie serie = new Serie(id: id,
                                        (Genero) entradaGenero,
                                        entradaTitulo,
                                        entradaDescricao,
                                        entradaAno);   

            return serie;

        }

        private static string ObterOpcaoUsuario(){

            Console.WriteLine();
            Console.WriteLine("NG Séries ao seu dispor!");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
    }
}
