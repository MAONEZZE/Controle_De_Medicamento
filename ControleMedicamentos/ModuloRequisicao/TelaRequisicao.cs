using ControleMedicamentos.Modulo_Funcionario;
using ControleMedicamentos.Modulo_Medicamento;
using ControleMedicamentos.Modulo_Paciente;
using ControleMedicamentos.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Modulo_Requisicao
{
    internal class TelaRequisicao
    {
        public void RemoverRequisicao()
        {
            Console.Clear();
            RepositorioRequisicao repReq = new RepositorioRequisicao();
            int id;

            Console.WriteLine("Digite o ID da Requisição desejada: ");
            id = Convert.ToInt32(Console.ReadLine());

            repReq.Removedor(id);

            Console.WriteLine("Requisição removida com sucesso!");
        }

        public void VisualizarRequisicao()
        {
            Console.Clear();
            RepositorioRequisicao repReq = new RepositorioRequisicao();
            char opcao;
            int id;

            Console.Write("Deseja ver Todas as Requisições? (S/N)");
            opcao = Convert.ToChar(Console.ReadLine());

            if (opcao == 's' || opcao == 'S')
            {
                Console.WriteLine("Dados dos Requisição");
                foreach (Aquisicao req in repReq.Visualizador())
                {
                    Console.WriteLine($"\tID: {req.id}\n\tMedicamento: \t{repReq.TextoMedicamento(req.Med)}\n\tData: {req.data}");
                    Console.WriteLine();
                }
            }
            else if(opcao == 'n' || opcao == 'N')
            {
                bool verificador = false;

                Console.WriteLine("Digite o ID da Requisição desejada: ");
                id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Dados da requisição");
                foreach (Aquisicao req in repReq.Visualizador())
                {
                    if (req.id == id)
                    {
                        verificador = true;
                        Console.WriteLine($"\tID: {req.id}\n\tMedicamento: \t{repReq.TextoMedicamento(req.Med)}\n\tData: {req.data}");
                        Console.WriteLine();
                        break;
                    }
                }

                if (verificador == false)
                {
                    Console.WriteLine("Paciente não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }
        }

        public void EditarRequisicao(int cpf)
        {
            Console.Clear();
            Estoque estq = new Estoque();
            RepositorioRequisicao repReq = new RepositorioRequisicao();

            DateTime data = DateTime.Now;
            Medicamento medicamento = null;
            Paciente paciente = null;

            int idRequisicao, idMedicamento, quantidadeDisponivel = 0, quantidadeRequisicao;

            Console.Write("Digite o ID da Requisição que será editada: ");
            idRequisicao = Convert.ToInt32(Console.ReadLine());

            if (repReq.VerificadorDeID(idRequisicao))
            {
                Console.Write("Digite o ID do novo medicamento: ");
                idMedicamento = Convert.ToInt32(Console.ReadLine());

                if (estq.VerificadorDeID(idMedicamento)) 
                { 
                    foreach (Medicamento med in estq.Visualizador())
                    {
                        if (med.id == idMedicamento)
                        {
                            quantidadeDisponivel = med.quantidade;
                            medicamento = med;
                            break;
                        }
                    }

                    Console.Write("Digite a quantidade que você precisa: ");
                    quantidadeRequisicao = Convert.ToInt32(Console.ReadLine());

                    while (quantidadeRequisicao > quantidadeDisponivel)
                    {
                        Console.WriteLine("Desculpe, mas a quantidade requisitada é maior do que a quantidade disponivel!");
                        Console.Write($"Digite a quantidade que você precisa, menor do que {quantidadeDisponivel}: ");
                        quantidadeRequisicao = Convert.ToInt32(Console.ReadLine());
                    }

                    foreach (Medicamento med in estq.Visualizador())
                    {
                        if (med.id == idMedicamento)
                        {
                            med.quantidade = med.quantidade - quantidadeRequisicao;
                            break;
                        }
                    }

                    foreach (Paciente pc in Program.repPC.Visualizador())
                    {
                        if (pc.Cpf == cpf)
                        {
                            paciente = pc;
                        }
                    }

                    Aquisicao requisicao = new Aquisicao(medicamento, data, quantidadeRequisicao, paciente);
                    repReq.Editor(requisicao);
                    Console.WriteLine("Requisição editada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Medicamento não encontrado, digite um id válido!");
                }
            }
            else
            {
                Console.WriteLine("Requisição não encontrado, digite um id válido!");
            }
        }

        public void MostrarIDMedicamentos()
        {
            Estoque estq = new Estoque();
            foreach (Medicamento med in estq.Visualizador())
            {
                Console.WriteLine($"{med.id} - {med.nome}");
            }
        }
        
        public void InsereRequisicao(int cpf)
        {
            Console.Clear();
            Estoque estq = new Estoque();
            RepositorioRequisicao repReq = new RepositorioRequisicao();
            Medicamento medicamento = null;
            Paciente paciente = null;
            int idMedicamento, idFuncionario, quantidadeDisponivel = 0;
            DateTime data = DateTime.Now;
            int quantidadeRequisicao;

            MostrarIDMedicamentos();

            if (estq.Visualizador().Count == 0)
            {
                Console.WriteLine("Não há medicamento no estoque!");
            }
            else
            {
                Console.Write("Digite o ID do medicamento: ");
                idMedicamento = Convert.ToInt32(Console.ReadLine());

                if (estq.VerificadorDeID(idMedicamento))
                {
                    foreach (Medicamento med in estq.Visualizador())
                    {
                        if (med.id == idMedicamento)
                        {
                            quantidadeDisponivel = med.quantidade;
                            medicamento = med;
                            break;
                        }
                    }

                    Console.Write("Digite a quantidade que você precisa: ");
                    quantidadeRequisicao = Convert.ToInt32(Console.ReadLine());

                    while (quantidadeRequisicao > quantidadeDisponivel)
                    {
                        Console.WriteLine("Desculpe, mas a quantidade requisitada é maior do que a quantidade disponivel!");
                        Console.Write($"Digite a quantidade que você precisa, menor do que {quantidadeDisponivel}: ");
                        quantidadeRequisicao = Convert.ToInt32(Console.ReadLine());
                    }

                    foreach (Medicamento med in estq.Visualizador())
                    {
                        if (med.id == idMedicamento)
                        {
                            med.quantidade = med.quantidade - quantidadeRequisicao;
                            break;
                        }
                    }

                    foreach (Paciente pc in Program.repPC.Visualizador())
                    {
                        if (pc.Cpf == cpf)
                        {
                            paciente = pc;
                        }
                    }

                    Aquisicao requisicao = new Aquisicao(medicamento, data, quantidadeRequisicao, paciente);
                    repReq.Insere(requisicao);
                    Console.WriteLine("Requisição feita com sucesso!");
                }
                else
                {
                    Console.WriteLine("Medicamento não encontrado!");
                }
            }
        }
    }
}
