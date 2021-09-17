using System;

namespace Duck.Flix
{
    class Program
    {
        static DocumentarioRepositorio repositorio = new DocumentarioRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarTitulos();
						break;
					case "2":
						InserirTitulo();
						break;
					case "3":
						AtualizarTitulo();
						break;
					case "4":
						ExcluirTitulo();
						break;
					case "5":
						VisualizarTitulo();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Honk!");
			Console.ReadLine();
        }
		
        private static void ListarTitulos()
		{
			Console.WriteLine("Listar títulos");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum título cadastrado.");
				return;
			}

			foreach (var titulo in lista)
			{
                var excluido = titulo.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", titulo.retornaId(), titulo.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirTitulo()
		{
			Console.WriteLine("Inserir novo título");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Título: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Título: ");
			string entradaDescricao = Console.ReadLine();

			Titulo novoTitulo = new Titulo(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoTitulo);
		}

        private static void AtualizarTitulo()
		{
			Console.Write("Digite o id do Título: ");
			int indiceTitulo = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Título: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Título: ");
			string entradaDescricao = Console.ReadLine();

			Titulo atualizaTitulo = new Titulo(id: indiceTitulo,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceTitulo, atualizaTitulo);
		}

        private static void ExcluirTitulo()
		{
			Console.Write("Digite o id do Título: ");
			int indiceTitulo = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceTitulo);
		}

        private static void VisualizarTitulo()
		{
			Console.Write("Digite o id do Título: ");
			int indiceTitulo = int.Parse(Console.ReadLine());

			var titulo = repositorio.RetornaPorId(indiceTitulo);

			Console.WriteLine(titulo);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Quack!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar títulos");
			Console.WriteLine("2- Inserir novo título");
			Console.WriteLine("3- Atualizar título");
			Console.WriteLine("4- Excluir título");
			Console.WriteLine("5- Visualizar título");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
