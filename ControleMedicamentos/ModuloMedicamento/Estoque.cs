using ControleMedicamentos.Modulo_Fornecedor;
using ControleMedicamentos.Modulo_Medicamento;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ModuloMedicamento
{
    internal class Estoque
    {
        private ArrayList listaMed = new ArrayList();

        public void Insere(Medicamento med)
        {
            listaMed.Add(med);
        }

        public ArrayList Visualizador()
        {
            return listaMed;
        }

        public void Editar(Medicamento medica, int id)
        {
            foreach(Medicamento med in listaMed)
            {
                if(med.id == id)
                {
                    med.descricao = medica.descricao;
                    med.nome = medica.nome;
                    med.quantidade = medica.quantidade;
                    med.Forn = medica.Forn;
                    break;
                }
            }
        }

        public void Remover(int id)
        {
            foreach (Medicamento med in listaMed)
            {
                if (med.id == id)
                {
                    listaMed.Remove(med);
                    break;
                }
            }
        }

        public bool VerificadorDeID(int id)
        {
            bool verificador = false;

            foreach (Medicamento med in listaMed)
            {
                if (med.id == id)
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

        public ArrayList MedicamentoEmFalta()
        {
            ArrayList listaEmFalta = new ArrayList();
            bool verificador = false;

            Console.WriteLine("Medicamentos em falta");
            foreach(Medicamento med in listaMed)
            {
                if(med.quantidade == 0)
                {
                    verificador = true;
                    listaEmFalta.Add(med);
                }
            }

            if(verificador == true)
            {
                return listaEmFalta;
            }
            else
            {
                return null;
            }
        }

    }
}
