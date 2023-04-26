using ControleMedicamentos.Modulo_Fornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Modulo_Medicamento
{
    internal class Medicamento
    {
        public int id;
        public string nome;
        public string descricao;
        public int quantidade;
        private Fornecedor forn;

        public Medicamento(string nome, string descricao, int quantidade, Fornecedor forn)
        {
            this.id++;
            this.nome = nome;
            this.descricao = descricao;
            this.quantidade = quantidade;
            this.forn = forn;
        }

        public Fornecedor Forn 
        {
            get
            {
                return forn;
            }
            set
            {
                forn = value;
            }
        }
    }
}
