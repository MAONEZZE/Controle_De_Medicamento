using ControleMedicamentos.Modulo_Medicamento;
using ControleMedicamentos.Modulo_Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Modulo_Fornecedor
{
    internal class TelaFornecedor
    {
        public void EditarFornecedor()
        {
            int novoCnpj, id;
            string novaSenha, novoNome, novoEndereco;

            Console.Write("Digite o ID do paciente que será alterado: ");
            id = Convert.ToInt32(Console.ReadLine());

            if (Program.repPC.VerificadorDeID(id))
            {
                Console.Write("Novo Nome do Fornecedor: ");
                novoNome = Console.ReadLine();
                Console.Write("Novo Endereço do Fornecedor: ");
                novoEndereco = Console.ReadLine();
                Console.Write("Novo CNPJ do Fornecedor: ");
                novoCnpj = Convert.ToInt32(Console.ReadLine());
                Console.Write("Nova Senha do Fornecedor: ");
                novaSenha = Console.ReadLine();

                Fornecedor forn = new Fornecedor(novoNome, novoEndereco, novoCnpj, novaSenha);

                while (novaSenha.Length < 6)
                {
                    Console.WriteLine();
                    Console.WriteLine(forn.Senha);
                    Console.Write("Digite outra Senha: ");
                    novaSenha = Console.ReadLine();

                    forn.Senha = novaSenha;
                }

                Console.WriteLine("Paciente Cadastrado com Sucesso!");
            }
            else
            {
                Console.WriteLine("Fornecedor não encontrado!");
            }

        }

        public void RemoverFornecedor()
        {
            int id;

            Console.WriteLine("Digite o ID do Fornecedor que deseja remover: ");
            id = Convert.ToInt32(Console.ReadLine());

            if (Program.repForn.VerificadorDeID(id))
            {
                Program.repForn.Removedor(id);
            }
            else
            {
                Console.WriteLine("Fornecedor não encontrado!");
            }

            Console.WriteLine("Fornecedor Removido com Sucesso!");
        }

        public void VisualizarFornecedor()
        {
            char opcao;
            int id;

            Console.Write("Deseja ver Todos Fornecedor? (S/N)");
            opcao = Convert.ToChar(Console.ReadLine());

            if (opcao == 's' || opcao == 'S')
            {
                Console.WriteLine("Dados dos Fornecedor");
                foreach (Fornecedor forn in Program.repForn.Visualizador())
                {
                    Console.WriteLine($"\tID: {forn.id}\n\tNome: {forn.nome}\n\tCNPJ: {forn.cnpj}\n\tEndereço: {forn.endereco}");
                    Console.WriteLine();
                }
            }
            else
            {
                bool verificador = false;

                Console.WriteLine("Digite o ID do Fornecedor desejado: ");
                id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Dados do Fornecedor");
                foreach (Fornecedor forn in Program.repForn.Visualizador())
                {
                    if (forn.id == id)
                    {
                        verificador = true;
                        Console.WriteLine($"\tID: {forn.id}\n\tNome: {forn.nome}\n\tCNPJ: {forn.cnpj}\n\tEndereço: {forn.endereco}");
                        Console.WriteLine();
                        break;
                    }
                }

                if (verificador == false)
                {
                    Console.WriteLine("Paciente não encontrado!");
                }
            }

        }

        //==================================================================================================//

        public void OpcaoEscolhida(char opcao, int cnpj)
        {
            TelaMedicamento telaMed = new TelaMedicamento();

            switch (opcao)
            {
                case '1':
                    telaMed.Inserir(cnpj);
                    break;

                case '2':
                    telaMed.Editar(cnpj);
                    break;

                case '3':
                    telaMed.Visualizar();
                    break;
            }
        }

        public void MenuFornecedor(int cnpj)
        {
            char opcao;

            do
            {
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1 - Inserir Medicamento");
                Console.WriteLine("2 - Editar Medicamento");
                Console.WriteLine("3 - Visualizar Medicamento");
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
                    OpcaoEscolhida(opcao, cnpj);
                }

            } while (opcao != 's' && opcao != 'S');
        }

        //==================================================================================================//

        public void MenuLogin()
        {
            int cnpj;
            string senha, nome = null;
            bool verificador = false;

            Console.WriteLine("===== LOGIN ======");
            Console.WriteLine("=== FORNECEDOR ===");
            Console.Write("Digite o CNPJ: ");
            cnpj = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite a Senha: ");
            senha = Console.ReadLine();

            if (Program.repForn.VerificadorDeCpfSenha(ref nome, cnpj, senha))
            {
                Console.WriteLine($"Olá {nome}, Seja Bem Vindo!");
                MenuFornecedor(cnpj);
            }
            else
            {
                Console.WriteLine("Desculpe, CPF/Senha inválidos");
                Console.ReadKey();
            }
        }

        public void MenuCadastro()
        {
            int cnpj;
            string senha, nome, endereco;

            Console.WriteLine(" === CADASTRO ===");
            Console.WriteLine("=== FORNECEDOR ===");
            Console.Write("Digite seu Nome: ");
            nome = Console.ReadLine();
            Console.Write("Digite seu Endereço: ");
            endereco = Console.ReadLine();
            Console.Write("Digite seu CPF: ");
            cnpj = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite sua Senha: ");
            senha = Console.ReadLine();

            Fornecedor forn = new Fornecedor(nome, endereco, cnpj, senha);

            while (senha.Length < 6)
            {
                Console.WriteLine();
                Console.WriteLine(forn.Senha);
                Console.Write("Digite outra Senha: ");
                senha = Console.ReadLine();

                forn.Senha = senha;
            }

            Program.repForn.Insere(forn);
            Console.WriteLine("Paciente Cadastrado com Sucesso!");
        }
    }
}
