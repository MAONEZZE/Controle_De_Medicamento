using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.Compartilhado;

namespace ControleMedicamentos.Modulo_Paciente
{
    internal class Paciente : Pessoa
    {
        public Paciente(string nome, string senha, int cpf) : base(nome, senha, cpf) { }

    }
}
