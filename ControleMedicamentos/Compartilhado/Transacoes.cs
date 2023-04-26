using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.Modulo_Medicamento;
using ControleMedicamentos.Modulo_Funcionario;

namespace ControleMedicamentos.Compartilhado
{
    internal class Transacoes
    {
        private Medicamento med;
        public DateTime data; //aaaa - ano, mm - mes, dd - dia; se quiser pode colocar tempo --> aaaa - ano, mm - mes, dd - dia, hh - hora, mm - minuto, ss - segundo
        public int quantMedicamento;
        public int id;

        public Transacoes(Medicamento med, DateTime data, int quantMedicamento)
        {
            this.id++;
            this.med = med;
            this.data = data;
            this.quantMedicamento = quantMedicamento;

        }

        public Medicamento Med { get; set; }

    }
}
