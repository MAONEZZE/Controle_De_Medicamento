using ControleMedicamentos.Modulo_Medicamento;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Modulo_Requisicao
{
    internal class RepositorioRequisicao
    {
        private ArrayList listaRequisicoes = new ArrayList();

        public void Insere(Aquisicao req)
        {
            listaRequisicoes.Add(req);
        }

        public ArrayList Visualizador()
        {
            return listaRequisicoes;
        }

        public void Editor(Aquisicao requisicao)
        {
            foreach (Aquisicao req in listaRequisicoes)
            {
                if (req.id == requisicao.id)
                {
                    req.Med = requisicao.Med;
                    req.data = requisicao.data;
                    req.quantMedicamento = requisicao.quantMedicamento;
                    break;
                }
            }
        }

        public void Removedor(int id)
        {
            foreach (Aquisicao req in listaRequisicoes)
            {
                if (req.id == id)
                {
                    listaRequisicoes.Remove(req);
                    break;
                }
            }
        }

        public bool VerificadorDeID(int id)
        {
            bool verificador = false;

            foreach (Aquisicao req in listaRequisicoes)
            {
                if (req.id == id)
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

        public string TextoMedicamento(Medicamento med)
        {
            return $"\nID: {med.id}\n\tNome: {med.nome}\n\tDescrição: {med.descricao}\n\tQuantidade: {med.quantidade}\n\tFornecedor: {med.Forn.nome}";
        }
    }
}
