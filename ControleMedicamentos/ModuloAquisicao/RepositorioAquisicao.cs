using ControleMedicamentos.Modulo_Medicamento;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Modulo_Aquisicao
{
    internal class RepositorioAquisicao
    {
        private ArrayList listaAquisicoes = new ArrayList();

        public void Insere(Aquisicao aquisicao)
        {
            listaAquisicoes.Add(aquisicao);
        }

        public ArrayList Visualizador()
        {
            return listaAquisicoes;
        }

        public void Editor(Aquisicao aquisicao)
        {
            foreach (Aquisicao aq in listaAquisicoes)
            {
                if (aq.id == aquisicao.id)
                {
                    aq.Med = aquisicao.Med;
                    aq.data = aquisicao.data;
                    aq.quantMedicamento = aquisicao.quantMedicamento;
                    break;
                }
            }
        }

        public void Removedor(int id)
        {
            foreach (Aquisicao aq in listaAquisicoes)
            {
                if (aq.id == id)
                {
                    listaAquisicoes.Remove(aq);
                    break;
                }
            }
        }

        public bool VerificadorDeID(int id)
        {
            bool verificador = false;

            foreach (Aquisicao aq in listaAquisicoes)
            {
                if (aq.id == id)
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
