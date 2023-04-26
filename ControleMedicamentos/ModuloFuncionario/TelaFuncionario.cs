using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.Modulo_Fornecedor;
using ControleMedicamentos.Modulo_Paciente;
using ControleMedicamentos.Modulo_Requisicao;
using ControleMedicamentos.Modulo_Aquisicao;
using ControleMedicamentos.ModuloMedicamento;
using System.Collections;
using ControleMedicamentos.Modulo_Medicamento;

namespace ControleMedicamentos.Modulo_Funcionario
{
    internal class TelaFuncionario
    {
        public void OpcaoEscolhidaCrudFornecedor(char opcao)
        {
            TelaFornecedor telaForn = new TelaFornecedor();

            switch (opcao)
            {
                case '1':
                    telaForn.VisualizarFornecedor();
                    break;

                case '2':
                    telaForn.RemoverFornecedor();
                    break;

                case '3':
                    telaForn.EditarFornecedor();
                    break;
            }
        }
        public void FuncaoCrudFornecedor()
        {
            Console.Clear();
            char opcao;

            do
            {

                Console.WriteLine("=== MENU FUNCIONÁRIO ===");
                Console.WriteLine("===   (FORNECEDOR)   ===");
                Console.WriteLine("1 - Visualizar Fornecedor");
                Console.WriteLine("2 - Editar Fornecedor");
                Console.WriteLine("3 - Remover Fornecedor");
                Console.WriteLine("S - Sair");
                Console.Write("Escolha uma opção: ");
                opcao = Convert.ToChar(Console.ReadLine());

                while (opcao != '1' && opcao != '2' && opcao != '3' && opcao != 'S' && opcao != 's')
                {
                    Console.Write("Escolha uma opção válida: ");
                    opcao = Convert.ToChar(Console.ReadLine());
                }

                if (opcao == '1' || opcao == '2')
                {
                    OpcaoEscolhidaCrudFornecedor(opcao);
                }

            } while (opcao != 's' && opcao != 'S');

            Console.WriteLine("Voltando...");
        }

        //==================================================================================================//

        public void MostrarMedEmFalta()
        {
            Estoque estq = new Estoque();


            foreach (Medicamento med in estq.MedicamentoEmFalta())
            {
                Console.WriteLine($"\tID: {med.id}\n" +
                $"\tNome: {med.nome}\n" +
                $"\tDescrição: {med.descricao}\n" +
                $"\tQuantidade: {med.quantidade}\n" +
                $"\tFornecedor: {Program.repForn.DadosFornecedor(med)}");
                Console.WriteLine();
                
            }
        }

        public void OpcaoEscolhidaEstoque(char opcao)
        {
            Estoque estq = new Estoque();
            TelaRequisicao tlR = new TelaRequisicao();
            TelaAquisicao tlA = new TelaAquisicao();

            switch (opcao)
            {
                case '1':
                    tlA.VisualizarAquisicao();
                    break;

                case '2':
                    tlR.VisualizarRequisicao();
                    break;

                case '3':
                    tlA.InsereAquisicao();
                    break;

                case '4':
                    MostrarMedEmFalta();
                    break;
            }
        }

        public void FuncaoAnaliseEstoque()
        {
            Console.Clear();
            char opcao;

            do
            {
                Console.WriteLine("=== MENU FUNCIONÁRIO ===");
                Console.WriteLine("===    (ESTOQUE)    ====");
                Console.WriteLine("1 - Historico de aquisições");
                Console.WriteLine("2 - Historico de requisições");
                Console.WriteLine("3 - Aquisição de Medicamento");
                Console.WriteLine("4 - Medicamentos com Baixa quantidade");
                Console.WriteLine("S - Sair");
                Console.Write("Escolha uma opção: ");
                opcao = Convert.ToChar(Console.ReadLine());

                while (opcao != '1' && opcao != '2' && opcao != '3' && opcao != '4' &&  opcao != 'S' && opcao != 's')
                {
                    Console.Write("Escolha uma opção válida: ");
                    opcao = Convert.ToChar(Console.ReadLine());
                }

                if (opcao == '1' || opcao == '2')
                {
                    OpcaoEscolhidaEstoque(opcao);
                }

            } while (opcao != 's' && opcao != 'S');

            Console.WriteLine("Voltando...");
        }

        //==================================================================================================//

        public void OpcaoEscolhidaCrudPaciente(char opcao)
        {
            TelaPaciente telaPc = new TelaPaciente();

            switch (opcao)
            {
                case '1':
                    telaPc.VisualizarPaciente();
                    break;

                case '2':
                    telaPc.RemoverPaciente();
                    break;

                case '3':
                    telaPc.EditarPaciente();
                    break;
            }
        }

        public void FuncaoCrudPaciente()
        {
            Console.Clear();
            char opcao;

            do
            { 
                Console.WriteLine("=== MENU FUNCIONÁRIO ===");
                Console.WriteLine("===    (PACIENTE)    ===");
                Console.WriteLine("1 - Visualizar Pacientes");
                Console.WriteLine("2 - Editar Pacientes");
                Console.WriteLine("3 - Remover Pacientes");
                Console.WriteLine("S - Sair");
                Console.Write("Escolha uma opção: ");
                opcao = Convert.ToChar(Console.ReadLine());

                while (opcao != '1' && opcao != '2' && opcao != '3' && opcao != 'S' && opcao != 's')
                {
                    Console.Write("Escolha uma opção válida: ");
                    opcao = Convert.ToChar(Console.ReadLine());
                }

                if (opcao == '1' || opcao == '2')
                {
                    OpcaoEscolhidaCrudPaciente(opcao);
                }

            } while (opcao != 's' && opcao != 'S');

            Console.WriteLine("Voltando...");
        }

        //==================================================================================================//

        public void OpcaoEscolhida(char opcao)
        {
            switch (opcao)
            {
                case '1':
                    FuncaoCrudPaciente();
                    break;

                case '2':
                    FuncaoAnaliseEstoque();
                    break;

                case '3':
                    FuncaoCrudFornecedor();
                    break;
            }
        }

        public void MenuFuncionario()
        {
            Console.Clear();
            char opcao;

            do
            {

                Console.WriteLine("=== MENU FUNCIONÁRIO ===");
                Console.WriteLine("1 - CRUD Pacientes");
                Console.WriteLine("2 - Análise do Estoque");
                Console.WriteLine("3 - CRUD Fornecedores");
                Console.WriteLine("S - Sair");
                Console.Write("Escolha uma opção: ");
                opcao = Convert.ToChar(Console.ReadLine());

                while (opcao != '1' && opcao != '2' && opcao != '3' && opcao != 'S' && opcao != 's')
                {
                    Console.Write("Escolha uma opção válida: ");
                    opcao = Convert.ToChar(Console.ReadLine());
                }

                if (opcao == '1' || opcao == '2' || opcao == '3')
                {
                    OpcaoEscolhida(opcao);
                }

            } while (opcao != 's' && opcao != 'S');

            Console.WriteLine("Voltando...");
        }

        //==================================================================================================//

        public void MenuLogin()
        {
            Console.Clear();
            int cpf;
            string senha, nome = null;
            bool verificador = false;

            Console.WriteLine("====== LOGIN ======");
            Console.WriteLine("=== FUNCIONARIO ===");
            Console.Write("Digite o CPF: ");
            cpf = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite a Senha: ");
            senha = Console.ReadLine();

            if (Program.repFunc.VerificadorDeCpfSenha(ref nome, cpf, senha))
            {
                Console.WriteLine($"Olá {nome}, Seja Bem Vindo!");
                Console.ReadKey();
                MenuFuncionario();
            }
            else
            {
                Console.WriteLine("Desculpe, CPF/Senha inválidos");
            }
        }

        public void MenuCadastro()
        {
            Console.Clear();
            int cpf;
            string senha, nome;

            Console.WriteLine("==== CADASTRO =====");
            Console.WriteLine("=== FUNCIONARIO ===");
            Console.Write("Digite seu Nome: ");
            nome = Console.ReadLine();
            Console.Write("Digite seu CPF: ");
            cpf = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite sua Senha: ");
            senha = Console.ReadLine();

            Funcionario func = new Funcionario(nome, senha, cpf);

            while (senha.Length < 6)
            {
                Console.WriteLine();
                Console.WriteLine(func.Senha);
                Console.Write("Digite outra Senha: ");
                senha = Console.ReadLine();

                func.Senha = senha;
            }

            Program.repFunc.Insere(func);
            Console.WriteLine("Funcionário Cadastrado com Sucesso!");
        }
    }
}
