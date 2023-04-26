using ControleMedicamentos.Modulo_Fornecedor;
using ControleMedicamentos.Modulo_Paciente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Modulo_Funcionario
{
    internal class RepositorioFuncionario
    {
        private ArrayList listaFuncionario = new ArrayList();

        public void Insere(Funcionario func)
        {
            listaFuncionario.Add(func);
        }

        public ArrayList Visualizador()
        {
            return listaFuncionario;
        }

        public bool VerificadorDeCpfSenha(ref string nome, int cpf, string senha)
        {
            bool verificador = false;

            foreach (Funcionario func in listaFuncionario)
            {
                if (func.Cpf == cpf && func.Senha.Equals(senha))
                {
                    nome = func.nome;
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

        public bool VerificadorDeID(int id)
        {
            bool verificador = false;

            foreach (Funcionario func in listaFuncionario)
            {
                if (func.id == id)
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
    }
}
