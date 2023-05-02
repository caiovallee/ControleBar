using ControleBar.Modulo_Conta;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.Modulo_Conta
{
    internal class RepositorioConta
    {
        private int contadorConta = 0;
        private ArrayList listaConta = new ArrayList();
        internal void Inserir(Conta Conta)
        {
            contadorConta++;

            Conta.id = contadorConta;

            listaConta.Add(Conta);
        }

        public ArrayList SelecionarTodos()
        {
            return listaConta;
        }

        internal void Editar(int id, Conta ContaAtualizado)
        {
            Conta ContaSelecionada = SelecionarPorId(id);

            ContaSelecionada.numero = ContaAtualizado.numero;
            ContaSelecionada.status = ContaAtualizado.status;
            ContaSelecionada.cliente = ContaAtualizado.cliente;
            ContaSelecionada.mesa = ContaAtualizado.mesa;


        }
        internal void Excluir(int id)
        {
            Conta ContaSelecionada = SelecionarPorId(id);

            listaConta.Remove(ContaSelecionada);

        }

        internal Conta SelecionarPorId(int id)
        {
            Conta ContaSelecionada = null;
            foreach (Conta conta in listaConta)
            {
                if (conta.id == id)
                {
                    ContaSelecionada = conta;

                    break;
                }
            }

            return ContaSelecionada;
        }
    }
}
