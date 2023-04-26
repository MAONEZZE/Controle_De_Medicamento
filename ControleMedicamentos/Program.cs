using ControleMedicamentos.Modulo_Fornecedor;
using ControleMedicamentos.Modulo_Funcionario;
using ControleMedicamentos.Modulo_Paciente;

namespace ControleMedicamentos
{
    internal class Program
    {
        public static RepositorioFuncionario repFunc = new RepositorioFuncionario();
        public static RepositorioFornecedor repForn = new RepositorioFornecedor();
        public static RepositorioPaciente repPC = new RepositorioPaciente();

        static void OpcaoEscolhidaCadastro(char opcao)
        {
            TelaPaciente telaPC = new TelaPaciente();
            TelaFuncionario telaFunc = new TelaFuncionario();
            TelaFornecedor telaForn = new TelaFornecedor();

            switch (opcao)
            {
                case '1':
                    telaPC.MenuCadastro();
                    break;

                case '2':
                    telaFunc.MenuCadastro();
                    break;

                case '3':
                    telaForn.MenuCadastro();
                    break;
            }
        }

        static void FuncaoCadastro()
        {
            char opcao;

            do
            {
                Console.WriteLine("=== CADASTRO ===");
                Console.WriteLine("1 - Paciente");
                Console.WriteLine("2 - Funcionário");
                Console.WriteLine("3 - Fornecedor");
                Console.WriteLine("S - Sair");
                Console.Write("Escolha uma opção: ");
                opcao = Convert.ToChar(Console.ReadLine());

                if (opcao != '1' && opcao != '2' && opcao != '3' && opcao != 'S' && opcao != 's')
                {
                    opcao = VerificadorOpcaoFFP(opcao);
                }

                if (opcao == '1' || opcao == '2')
                {
                    OpcaoEscolhidaCadastro(opcao);
                }

            } while (opcao != 's' && opcao != 'S');

            Console.WriteLine("Voltando para o menu Principal...");
        }

        static void OpcaoEscolhidaLogin(char opcao)
        {
            TelaPaciente telaPC = new TelaPaciente();
            TelaFuncionario telaFunc = new TelaFuncionario();
            TelaFornecedor telaForn = new TelaFornecedor();

            switch (opcao)
            {
                case '1':
                    telaPC.MenuLogin();
                    break;

                case '2':
                    telaFunc.MenuLogin();
                    break;

                case '3':
                    telaForn.MenuLogin();
                    break;
            }
        }

        static void FuncaoLogin()
        {
            char opcao;

            do
            {
                Console.WriteLine("=== LOGIN ===");
                Console.WriteLine("1 - Paciente");
                Console.WriteLine("2 - Funcionário");
                Console.WriteLine("3 - Fornecedor");
                Console.WriteLine("S - Sair");
                Console.Write("Escolha uma opção: ");
                opcao = Convert.ToChar(Console.ReadLine());

                if (opcao != '1' && opcao != '2' && opcao != '3' && opcao != 'S' && opcao != 's')
                {
                    opcao = VerificadorOpcaoFFP(opcao);
                }

                if (opcao == '1' || opcao == '2')
                {
                    OpcaoEscolhidaLogin(opcao);
                }

            } while (opcao != 's' && opcao != 'S');

            Console.WriteLine("Voltando para o menu Principal...");
        }
        static void OpcaoEscolhida(char opcao)
        {
            switch (opcao)
            {
                case '1':
                    FuncaoLogin();
                    break;

                case '2':
                    FuncaoCadastro();
                    break;
            }
        }

        static char VerificadorOpcaoFFP(char opcao)
        {
            while (opcao != '1' && opcao != '2' && opcao != '3' && opcao != 'S' && opcao != 's')
            {
                Console.Write("Escolha uma opção válida: ");
                opcao = Convert.ToChar(Console.ReadLine());
            }

            return opcao;
        }

        static void Main(string[] args)
        {
            char opcao;

            do
            {
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1 - Login");
                Console.WriteLine("2 - Cadastro");
                Console.WriteLine("S - Sair");
                Console.Write("Escolha uma opção: ");
                opcao = Convert.ToChar(Console.ReadLine());

                while (opcao != '1' && opcao != '2' && opcao != 'S' && opcao != 's')
                {
                    Console.Write("Escolha uma opção válida: ");
                    opcao = Convert.ToChar(Console.ReadLine());
                }

                if (opcao == '1' || opcao == '2')
                {
                    OpcaoEscolhida(opcao);
                }

            }while(opcao != 's' && opcao != 'S');

            Console.WriteLine("Encerrando o Gerenciador de Medicamentos...");
            Console.ReadKey();
        }
    }
}