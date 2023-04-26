using ControleMedicamentos.Modulo_Fornecedor;
using ControleMedicamentos.Modulo_Medicamento;
using ControleMedicamentos.Modulo_Paciente;
using ControleMedicamentos.Modulo_Requisicao;
using ControleMedicamentos.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Modulo_Aquisicao
{
    internal class TelaAquisicao
    {
        public void RemoverAquisicao()
        {
            Console.Clear();
            RepositorioAquisicao repAq = new RepositorioAquisicao();
            int id;

            Console.WriteLine("Digite o ID da Aquisição desejada: ");
            id = Convert.ToInt32(Console.ReadLine());

            repAq.Removedor(id);

            Console.WriteLine("Aquisição removida com sucesso!");
        }

        public void VisualizarAquisicao()
        {
            Console.Clear();
            RepositorioAquisicao repAq = new RepositorioAquisicao();
            char opcao;
            int id;

            Console.Write("Deseja ver Todas as Aquisição? (S/N)");
            opcao = Convert.ToChar(Console.ReadLine());

            if (opcao == 's' || opcao == 'S')
            {
                Console.WriteLine("Dados dos Aquisição");
                foreach (Aquisicao aq in repAq.Visualizador())
                {
                    Console.WriteLine($"\tID: {aq.id}\n\tMedicamento: \t{repAq.TextoMedicamento(aq.Med)}\n\tData: {aq.data}");
                    Console.WriteLine();
                }
            }
            else if (opcao == 'n' || opcao == 'N')
            {
                bool verificador = false;

                Console.WriteLine("Digite o ID da Aquisição desejada: ");
                id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Dados da Aquisição");
                foreach (Aquisicao aq in repAq.Visualizador())
                {
                    if (aq.id == id)
                    {
                        verificador = true;
                        Console.WriteLine($"\tID: {aq.id} \n\tMedicamento: \t {repAq.TextoMedicamento(aq.Med)} \n\tData:  {aq.data}");
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

        public void EditarAquisicao(int cpf)
        {
            Console.Clear();
            Estoque estq = new Estoque();
            RepositorioAquisicao repAq = new RepositorioAquisicao();

            DateTime data = DateTime.Now;
            Medicamento medicamento = null;
            Fornecedor fornecedor = null;

            int idRequisicao, idMedicamento, quantidadeDisponivel = 0, quantidadeRequisicao;

            Console.Write("Digite o ID da Requisição que será editada: ");
            idRequisicao = Convert.ToInt32(Console.ReadLine());

            if (repAq.VerificadorDeID(idRequisicao))
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

                    Console.Write("Digite o ID do fornecedor: ");
                    int idforn = Convert.ToInt32(Console.ReadLine());

                    foreach (Fornecedor forn in Program.repForn.Visualizador())
                    {
                        if (forn.id == idforn)
                        {
                            fornecedor = forn;
                        }
                    }

                    Aquisicao aquisicao = new Aquisicao(medicamento, data, quantidadeRequisicao, fornecedor);
                    repAq.Editor(aquisicao);
                    Console.WriteLine("Aquisição editada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Medicamento não encontrado, digite um id válido!");
                }
            }
            else
            {
                Console.WriteLine("Aquisição não encontrado, digite um id válido!");
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

        public void InsereAquisicao()
        {
            Console.Clear();
            Estoque estq = new Estoque();
            RepositorioAquisicao repAq = new RepositorioAquisicao();
            Medicamento medicamento = null;
            Fornecedor fornecedor = null;
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

                    Console.Write("Digite o ID do fornecedor: ");
                    int idforn = Convert.ToInt32(Console.ReadLine());

                    foreach (Fornecedor forn in Program.repForn.Visualizador())
                    {
                        if (forn.id == idforn)
                        {
                            fornecedor = forn;
                        }
                    }

                    Aquisicao aquisicao = new Aquisicao(medicamento, data, quantidadeRequisicao, fornecedor);
                    repAq.Insere(aquisicao);
                    Console.WriteLine("Aquisição feita com sucesso!");
                }
                else
                {
                    Console.WriteLine("Medicamento não encontrado!");
                }
            }
        }
    }
}
