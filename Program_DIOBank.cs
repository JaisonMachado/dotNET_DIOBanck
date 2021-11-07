using System;
using System.Collections.Generic;
using DIOBanck.Classes;
using DIOBanck.Enums;

namespace DIOBanck
{
	class Program_DIOBank
	{

		static RepositoriodeContas repositoriodeContas = new RepositoriodeContas();

		static void Main(string[] args)
		{
			Console.WriteLine("Olá, seja bem vindo ao DIOBanck!");

			string opcaousuario = ObterOpcao();
			Console.WriteLine();
			while (opcaousuario != "X")
			{

				switch (opcaousuario)
				{
					case "1":
						Insere();
						break;
					case "2":
						ListarContas();
						break;
					case "3":
						Console.WriteLine("Você deseja:");
						Console.WriteLine("1 - Ver Saldo, 2 - Fazer uma Transferência");
						Console.WriteLine("3 - Sacar,  Ou, 4 - Efetuar um depósito");
						var opcaoUsuario = Console.ReadLine().ToUpper();
						if (opcaoUsuario != "1" && opcaoUsuario != "2" && opcaoUsuario != "3" && opcaoUsuario != "4")

						{
							opcaoUsuario = "Opção inválida!";
						}
						else
						{
							if (opcaoUsuario == "1")
							{
								Console.WriteLine("-- Opção Ver Saldo --");
								AcessarConta();

							}
							else if (opcaoUsuario == "2")
							{
								Console.WriteLine("-- Opção Transferência -- ");
								Console.WriteLine("Digite o numero da sua conta: ");
								int origem = int.Parse(Console.ReadLine());
								Console.WriteLine("Digite o numero da conta de destino: ");
								int destino = int.Parse(Console.ReadLine());
								Transferencia(origem, destino);
							}
							else if (opcaoUsuario == "3")
							{
								Console.WriteLine("-- Opção Saque --");
								Console.WriteLine("Digite o número da sua conta:");
								int contadestino = int.Parse(Console.ReadLine());
								Console.WriteLine("Digite o valor do saque: ");
								double saque = double.Parse(Console.ReadLine());
								Sacar(saque, contadestino);
							}
							else //opcaoUsuario  == "4"
							{
								Console.WriteLine("-- Opção Depósito -- ");
								Console.WriteLine("Digite o valor para depósito: ");
								double deposito = double.Parse(Console.ReadLine());
								Console.WriteLine("Digite a conta de destino");
								int contadestino = int.Parse(Console.ReadLine());
								Depositar(deposito, contadestino);
							}

							
						}
						break;

					case "X":
						break;
					default:
						throw new ArgumentOutOfRangeException();

				}// fim switch

				opcaousuario = ObterOpcao();
			}// fim while
		}// fim Main

		static void Sacar (double val, int destino)
		{

			var conta = repositoriodeContas.RetornaporNumeroConta(destino);
			if (conta.Sacar(val))
			{
				Console.WriteLine("Operação bem sucedida!");
			}
		}
		static void Depositar(double val, int destino)
        {
			
			var conta = repositoriodeContas.RetornaporNumeroConta(destino);
			if (conta.Depositar(val))
			{
				Console.WriteLine("Operação bem sucedida!");
			}
        }
		static void Transferencia(int contaorigem, int contadestino)
        {
			Console.WriteLine("Digite o valor: ");
			
			double valor = double.Parse(Console.ReadLine());
			
			var conta = repositoriodeContas.RetornaporNumeroConta(contaorigem);
			if (conta.Sacar(valor))

            {
				Console.WriteLine("Um momento, estamos efetuando a transferência.");
				var destino = repositoriodeContas.RetornaporNumeroConta(contadestino);
				if (destino.Depositar(valor))
                {
					Console.Write("Transaçao efetuada com sucesso!");
					Console.Write("Tecle enter para continuar.");
					Console.ReadKey();
				}
			}
			else
			{ Console.WriteLine("Desculpe, não foi possível finalizar a transferência!"); }

		}
		static string ObterOpcao()
		{
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada (entre 1 a 3 ou X:)");
			Console.WriteLine("1- Nova conta.");
			Console.WriteLine("2- Listar Contas.");
			Console.WriteLine("3- Acessar conta.");
			Console.WriteLine("X- Sair.");
			Console.WriteLine();
			var opcaoUsuario = Console.ReadLine().ToUpper();
			if (opcaoUsuario != "1" && opcaoUsuario != "2" && opcaoUsuario != "3" && opcaoUsuario != "X")

			{
				opcaoUsuario = "Opção inválida!";
				return opcaoUsuario;
			}
			else
			{
				return opcaoUsuario;
			}

		}
		private static void ListarContas()
		{

			var listaConta = repositoriodeContas.ListaContas();

			if (listaConta.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			foreach (var conta in listaConta)
			{

				Console.WriteLine("Conta Número {0}: - Cliente: {1} ", conta.retornaContaNumero(),
									conta.retornaCliente() + Environment.NewLine);
				Console.WriteLine("Saldo: {0} - Limite: {1} ", conta.retornaSaldo(), conta.retornaLimite());
				Console.WriteLine("Ultimos Lançamentos: ");
				Console.WriteLine(conta.retornaLancamentos());
			}




		}
		private static void AcessarConta()
		{
			Console.Write("Digite o numero da conta: ");
			int numConta = int.Parse(Console.ReadLine());

			var conta = repositoriodeContas.RetornaporNumeroConta(numConta);

			Console.WriteLine(conta);
		}

		public static void Insere()
		{
			Console.WriteLine("... Vamos cadastrar sua conta ...");
			foreach (int i in Enum.GetValues(typeof(ContaTipo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(ContaTipo), i));
			}
			Console.Write("Escolha entre os tipos listados acima: ");
			int contatipo = int.Parse(Console.ReadLine());

			int numconta = repositoriodeContas.ProximoId();

			Console.WriteLine("Digite o seu nome completo:\n");
			string nome = Console.ReadLine();
			string lancamentoAtual = " Abertura da conta ";


			Conta novaConta = new Conta(contanumero: numconta, nomecliente: nome,
										contaTipo: (ContaTipo)contatipo,
										saldoConta: 0.00, limite: 200.00,
										lancamentos: lancamentoAtual);

			repositoriodeContas.Insere(novaConta);

		}

	}
}

