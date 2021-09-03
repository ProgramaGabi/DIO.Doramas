using System;

namespace DIO.Doramas
{
    class Program
    {
        static DoramasRepositorio repositorio = new DoramasRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1" :
                        ListarDoramas();
                        break;
                    case "2" :
                        InserirDorama();
                        break;
                    case "3" :
                        AtualizarDorama();
                        break;
                    case "4" :
                        ExcluirDorama();
                        break;
                    case "5" :
                        VisualizarDorama();
                        break;
                    case "C" :
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ExcluirDorama()
        {
            Console.WriteLine("Digite o id do dorama: ");
            int indiceDorama = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceDorama);
        }

         private static void VisualizarDorama()
        {
            Console.WriteLine("Digite o id do dorama: ");
            int indiceDorama = int.Parse(Console.ReadLine());

            var dorama = repositorio.RetornaPorId(indiceDorama);
                        
            Console.WriteLine(dorama);
        }

         private static void AtualizarDorama()
        {
            Console.WriteLine("Digite o id do dorama: ");
            int indiceDorama = int.Parse(Console.ReadLine());


            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o Título do Dorama: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite o ano de início do Dorama: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da Dorama: ");
            string entradaDescricao = Console.ReadLine();

            Doramas atualizarDorama = new Doramas(id: indiceDorama,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

            repositorio.Atualiza(indiceDorama, atualizarDorama);
        }
        
        private static void ListarDoramas()
        {
            Console.WriteLine("Listar doramas");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Desculpe dorameiros, nenhum dorama cadastrado.");
                return;
            }

            foreach (var dorama in lista)
            {
                var excluido = dorama.retornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1} {2}", dorama.retornaId(), dorama.retornaTitulo(), (excluido ? "*Excluido*" : "" ));
            }
        }

        private static void InserirDorama()
        {
            Console.WriteLine("Inserir novo Dorama");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o título do Dorama: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite o Ano de Início do Dorama: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Dorama: ");
            string entradaDescricao = Console.ReadLine();

            Doramas novoDorama = new Doramas(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

            repositorio.Insere(novoDorama);

        }       


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem-Vindos ao DoramasFlix !!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar doramas");
            Console.WriteLine("2- Inserir novo dorama");
            Console.WriteLine("3- Atualizar dorama");
            Console.WriteLine("4- Excluir dorama");
            Console.WriteLine("5- Visualizar dorama");
            Console.WriteLine("6- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
