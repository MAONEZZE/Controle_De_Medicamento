using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.Compartilhado;

namespace ControleMedicamentos.Modulo_Funcionario
{
    internal class Funcionario : Pessoa
    {
        public Funcionario(string nome, string senha, int cpf) : base(nome, senha, cpf){ }
    }
}
