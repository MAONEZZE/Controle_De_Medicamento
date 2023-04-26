using ControleMedicamentos.Modulo_Funcionario;
using ControleMedicamentos.Modulo_Medicamento;
using ControleMedicamentos.Modulo_Requisicao;
using ControleMedicamentos.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Modulo_Paciente
{
    internal class TelaPaciente
    {
        public void EditarPaciente()
        {
            Console.Clear();
            int novoCpf, id;
            string novaSenha, novoNome;

            Console.Write("Digite o ID do paciente que será alterado: ");
            id = Convert.ToInt32(Console.ReadLine());

            if (Program.repPC.VerificadorDeID(id))
            {
                Console.WriteLine("=== CADASTRO ===");
                Console.Write("Digite o novo Nome do Paciente: ");
                novoNome = Console.ReadLine();
                Console.Write("Digite o novo CPF do Paciente: ");
                novoCpf = Convert.ToInt32(Console.ReadLine());
                Console.Write("Digite o nova Senha do Paciente: ");
                novaSenha = Console.ReadLine();

                Paciente pc = new Paciente(novoNome, novaSenha, novoCpf);

                while (novaSenha.Length < 6)
                {
                    Console.WriteLine();
                    Console.WriteLine(pc.Senha);
                    Console.Write("Digite outra Senha: ");
                    novaSenha = Console.ReadLine();

                    pc.Senha = novaSenha;
                }

                Program.repPC.Editor(pc);
                Console.WriteLine("Paciente Editado com Sucesso!");
            }
            else
            {
                Console.WriteLine("Paciente não encontrado!");
            }
            
        }

        public void RemoverPaciente()
        {
            Console.Clear();
            int id;

            Console.WriteLine("Digite o ID do Paciente que deseja remover: ");
            id = Convert.ToInt32(Console.ReadLine());

            if (Program.repPC.VerificadorDeID(id))
            {
                Program.repPC.Removedor(id);
            }
            else
            {
                Console.WriteLine("Paciente não encontrado!");
            }

            Console.WriteLine("Paciente Removido com Sucesso!");
        }

        public void VisualizarPaciente()
        {
            Console.Clear();
            char opcao;
            int id;

            Console.Write("Deseja ver Todos Paciente? (S/N)");
            opcao = Convert.ToChar(Console.ReadLine());

            if(opcao == 's' || opcao == 'S')
            {
                Console.WriteLine("Dados dos Pacientes");
                foreach (Paciente pc in Program.repPC.Visualizador())
                {
                    Console.WriteLine($"\tID: {pc.id}\n\tNome: {pc.nome}\n\tCPF: {pc.Cpf}");
                    Console.WriteLine();
                }
            }
            else if (opcao == 'n' || opcao == 'N')
            {
                bool verificador = false;

                Console.WriteLine("Digite o ID do Paciente desejado: ");
                id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Dados do Paciente");
                foreach (Paciente pc in Program.repPC.Visualizador())
                {
                    if(pc.id == id)
                    {
                        verificador = true;
                        Console.WriteLine($"\tID: {pc.id}\n\tNome: {pc.nome}\n\tCPF: {pc.Cpf}");
                        Console.WriteLine();
                        break;
                    }
                }

                if(verificador == false)
                {
                    Console.WriteLine("Paciente não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }

        }

        //==================================================================================================//

        public void OpcaoEscolhidaRequisicao(char opcao, int cpf)
        {
            TelaRequisicao telaR = new TelaRequisicao();

            switch (opcao)
            {
                case '1':
                    telaR.InsereRequisicao(cpf);
                    break;

                case '2':
                    telaR.EditarRequisicao(cpf);
                    break;

                case '3':
                    telaR.VisualizarRequisicao();
                    break;

                case '4':
                    telaR.RemoverRequisicao();
                    break;
            }
        }

        public void MenuPaciente(string nome, int cpf)
        {
            Console.Clear();
            Estoque estq = new Estoque();
            int opcaoMedicamento;
            char opcao;

            do { 
                Console.WriteLine("====== MENU ======");
                Console.WriteLine($"=== REQUISIÇÃO ===     {nome} - {cpf}");
                Console.WriteLine("1 - Fazer Requisição");
                Console.WriteLine("2 - Editar Requisiição");
                Console.WriteLine("3 - Remover Requisiição");
                Console.WriteLine("4 - Visualizar Requisiição");
                Console.WriteLine("S - Sair");
                Console.Write("Escolha uma opção: ");
                opcao = Convert.ToChar(Console.ReadLine());

                while (opcao != '1' && opcao != '2' && opcao != '3' && opcao != '4' && opcao != 'S' && opcao != 's')
                {
                    Console.Write("Escolha uma opção válida: ");
                    opcao = Convert.ToChar(Console.ReadLine());
                }

                if (opcao == '1' || opcao == '2')
                {
                    OpcaoEscolhidaRequisicao(opcao, cpf);
                }

            } while (opcao != 's' && opcao != 'S');

        }

        //==================================================================================================//

        public void MenuLogin()
        {
            Console.Clear();
            int cpf;
            string senha, nome = null;
            bool verificador = false;

            Console.WriteLine("==== LOGIN =====");
            Console.WriteLine("=== PACIENTE ===");
            Console.Write("Digite o CPF: ");
            cpf = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite a Senha: ");
            senha = Console.ReadLine();

            if (Program.repPC.VerificadorDeCpfSenha(ref nome, cpf, senha))
            {
                Console.WriteLine($"Olá {nome}, Seja Bem Vindo!");
                MenuPaciente(nome, cpf);
            }
            else
            {
                Console.WriteLine("Desculpe, CPF/Senha inválidos");
                Console.ReadKey();
            }
        }

        public void MenuCadastro()//Insere
        {
            Console.Clear();
            int cpf;
            string senha, nome;

            Console.WriteLine("=== CADASTRO ===");
            Console.WriteLine("=== PACIENTE ===");
            Console.Write("Digite seu Nome: ");
            nome = Console.ReadLine();
            Console.Write("Digite seu CPF: ");
            cpf = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite sua Senha: ");
            senha = Console.ReadLine();

            Paciente pc = new Paciente(nome, senha, cpf);

            while (senha.Length < 6)
            {
                Console.WriteLine();
                Console.WriteLine(pc.Senha);
                Console.Write("Digite outra Senha: ");
                senha = Console.ReadLine();

                pc.Senha = senha;
            }

            Program.repPC.Insere(pc);
            Console.WriteLine("Paciente Cadastrado com Sucesso!");
        }
    }
}
