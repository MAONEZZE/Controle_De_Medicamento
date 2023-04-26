using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.Modulo_Fornecedor;
using ControleMedicamentos.ModuloMedicamento;

namespace ControleMedicamentos.Modulo_Medicamento
{
    internal class TelaMedicamento
    {
        public void CriarObjetoMed(string nome, string descricao, int quantidade, int cnpj, int funcao, int id)
        {
            foreach (Fornecedor forn in Program.repForn.Visualizador())
            {
                if (forn.cnpj == cnpj)
                {
                    Medicamento med = new Medicamento(nome, descricao, quantidade, forn);
                    Estoque estq = new Estoque();

                    switch (funcao)
                    {
                        case '1':
                            estq.Insere(med);
                            break;

                        case '2':
                            estq.Editar(med, id);
                            break;

                    }
                    break;
                }
            }
        }

        public void Visualizar()
        {
            Estoque estq = new Estoque();
            char opcao;
            int id;

            Console.Write("Deseja ver Todos Medicamentos? (S/N)");
            opcao = Convert.ToChar(Console.ReadLine());

            if (opcao == 's' || opcao == 'S')
            {
                Console.WriteLine("Dados dos Medicamentos");
                foreach (Medicamento med in estq.Visualizador())
                {
                    Console.WriteLine($"\tID: {med.id}\n" +
                        $"\tNome: {med.nome}\n" +
                        $"\tDescrição: {med.descricao}\n" +
                        $"\tQuantidade: {med.quantidade}\n" +
                        $"\tFornecedor: {Program.repForn.DadosFornecedor(med)}");
                    Console.WriteLine();
                }
            }
            else
            {
                bool verificador = false;

                Console.WriteLine("Digite o ID do Medicamento desejado: ");
                id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Dados do Medicamento");
                foreach (Medicamento med in estq.Visualizador())
                {
                    if (med.id == id)
                    {
                        verificador = true;
                        Console.WriteLine($"\tID: {med.id}\n" +
                        $"\tNome: {med.nome}\n" +
                        $"\tDescrição: {med.descricao}\n" +
                        $"\tQuantidade: {med.quantidade}\n" +
                        $"\tFornecedor: {Program.repForn.DadosFornecedor(med)}");
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

        public void Remover()
        {
            int id;
            int funcao = 3;

            Console.Write("ID do Medicamento que será Removido: ");
            id = Convert.ToInt32(Console.ReadLine());

            Estoque estq = new Estoque();
            estq.Remover(id);
        }

        public void Editar(int cnpj)
        {
            Estoque estq = new Estoque();
            int id;
            int funcao = 2;

            Console.Write("ID do Medicamento que será alterado: ");
            id = Convert.ToInt32(Console.ReadLine());

            if (estq.VerificadorDeID(id))
            {
                string nome, descricao;
                int quantidade;
                Fornecedor fornecedor;

                Console.WriteLine("Digite os novos dados do Medicamento");
                Console.Write("Nome: ");
                nome = Console.ReadLine();
                Console.Write("Descrição: ");
                descricao = Console.ReadLine();
                Console.Write("Quantidade: ");
                quantidade = Convert.ToInt32(Console.ReadLine());

                CriarObjetoMed(nome, descricao, quantidade, cnpj, funcao, id);

                Console.WriteLine("Medicamento Editado no Estoque!");
            }
            else {
                Console.WriteLine("Medicamento Não foi encontrado!");
            }
        }
        public void Inserir(int cnpj)
        {
            Estoque estq = new Estoque();
            string nome, descricao;
            int quantidade;
            Fornecedor fornecedor;
            int funcao = 1;

            Console.WriteLine("Digite os dados do Medicamento");
            Console.WriteLine("Nome: ");
            nome = Console.ReadLine();
            Console.WriteLine("Descrição: ");
            descricao = Console.ReadLine();
            Console.WriteLine("Quantidade: ");
            quantidade = Convert.ToInt32(Console.ReadLine());

            CriarObjetoMed(nome, descricao, quantidade, cnpj, funcao, 0);

            Console.WriteLine("Medicamento Inserido no Estoque!");
        }
    }
}
