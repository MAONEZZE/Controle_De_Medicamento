using ControleMedicamentos.Compartilhado;
using ControleMedicamentos.Modulo_Fornecedor;
using ControleMedicamentos.Modulo_Funcionario;
using ControleMedicamentos.Modulo_Medicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Modulo_Aquisicao
{
    internal class Aquisicao : Transacoes
    {
        public Fornecedor forn;

        public Aquisicao(Medicamento med, DateTime data, int quantMedicamento, Fornecedor forn) : base(med, data, quantMedicamento) 
        {
            this.forn = forn;
        }
    }
}
