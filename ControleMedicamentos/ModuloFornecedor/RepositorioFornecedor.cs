using ControleMedicamentos.Modulo_Medicamento;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Modulo_Fornecedor
{
    internal class RepositorioFornecedor
    {
        private ArrayList listaFornecedor = new ArrayList();

        public void Insere(Fornecedor forn)
        {
            listaFornecedor.Add(forn);
        }

        public ArrayList Visualizador()
        {
            return listaFornecedor;
        }

        public void Removedor(int id)
        {
            foreach (Fornecedor forn in listaFornecedor)
            {
                if (forn.id == id)
                {
                    listaFornecedor.Remove(forn);
                    break;
                }
            }
        }

        public string DadosFornecedor(Medicamento med)
        {
            return $"{med.Forn.nome}\n\t\tID: {med.Forn.id}\n\t\tEndereço: {med.Forn.endereco}\n\t\tCNPJ: {med.Forn.cnpj}";
        }

        public bool VerificadorDeID(int id)
        {
            bool verificador = false;

            foreach (Fornecedor forn in listaFornecedor)
            {
                if (forn.id == id)
                {
                    verificador = true;
                }
            }

            if (verificador == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificadorDeCpfSenha(ref string nome, int cnpj, string senha)
        {
            bool verificador = false;

            foreach (Fornecedor forn in listaFornecedor)
            {
                if (forn.cnpj == cnpj && forn.Senha.Equals(senha))
                {
                    nome = forn.nome;
                    verificador = true;
                    break;
                }
            }

            if (verificador == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
