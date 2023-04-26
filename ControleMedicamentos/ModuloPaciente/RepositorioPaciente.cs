using ControleMedicamentos.Modulo_Fornecedor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Modulo_Paciente
{
    internal class RepositorioPaciente
    {
        private ArrayList listaPaciente = new ArrayList();

        public void Insere(Paciente pc)
        {
            listaPaciente.Add(pc);
        }

        public ArrayList Visualizador()
        {
            return listaPaciente;
        }

        public void Editor(Paciente paciente)
        {
            foreach(Paciente pc in listaPaciente)
            {
                if(pc.id == paciente.id)
                {
                    pc.nome = paciente.nome;
                    pc.Cpf = paciente.Cpf;
                    pc.Senha = paciente.Senha;
                    break;
                }
            }
        }

        public void Removedor(int id)
        {
            foreach(Paciente pc in listaPaciente)
            {
                if(pc.id == id)
                {
                    listaPaciente.Remove(pc);
                    break;
                }
            }
        }

        public bool VerificadorDeID(int id)
        {
            bool verificador = false;

            foreach(Paciente pc in listaPaciente)
            {
                if(pc.id == id)
                {
                    verificador = true;
                }
            }

            if(verificador == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificadorDeCpfSenha(ref string nome, int cpf, string senha)
        {
            bool verificador = false;

            foreach (Paciente pc in listaPaciente)
            {
                if (pc.Cpf == cpf && pc.Senha.Equals(senha))
                {
                    nome = pc.nome;
                    verificador = true;
                    break;
                }
            }

            if(verificador == true)
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
