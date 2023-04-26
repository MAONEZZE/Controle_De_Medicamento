using ControleMedicamentos.Modulo_Medicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Modulo_Fornecedor
{
    internal class Fornecedor
    {
        public int id;
        public string nome;
        public string endereco;
        public int cnpj;
        private Medicamento med;
        private string senha;

        public Fornecedor(string nome, string endereco, int cnpj, string senha)
        {
            this.id++;
            this.nome = nome;
            this.endereco = endereco;
            this.cnpj = cnpj;
            this.senha = senha;
        }

        public Medicamento Med 
        {
            get
            {
                return med;
            }
            set
            {
                med = value;
            }
        }

        public string Senha
        {
            get
            {
                if (senha.Length < 6)
                {
                    return "Senha muito curta, Digite uma senha com, no mínimo, 6 caracteres";
                }
                else
                {
                    return senha;
                }
            }
            set
            {
                senha = value;
            }
        }

    }
}
