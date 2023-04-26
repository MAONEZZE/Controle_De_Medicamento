using ControleMedicamentos.Compartilhado;
using ControleMedicamentos.Modulo_Funcionario;
using ControleMedicamentos.Modulo_Medicamento;
using ControleMedicamentos.Modulo_Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Modulo_Requisicao
{
    internal class Aquisicao : Transacoes
    {
        public Paciente paciente;

        public Aquisicao(Medicamento med, DateTime data, int quantMedicamento, Paciente paciente) : base(med, data, quantMedicamento)
        {
            this.paciente = paciente;
        }

    }
}
