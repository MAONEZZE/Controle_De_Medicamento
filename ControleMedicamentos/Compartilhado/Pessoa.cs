using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Compartilhado
{
    internal class Pessoa
    {
        public int id;
        public string nome;
        private string senha;
        private int cpf;

        public Pessoa(string nome, string senha, int cpf) 
        {
            this.id++;
            this.nome = nome;
            this.senha = senha;
            this.cpf = cpf;
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

        public int Cpf
        {
            get
            {
                return cpf;
            }
            set
            {
                cpf = value;
            }
        }

    }
}
