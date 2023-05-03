using ControleBar.Modulo_Cliente;
using ControleBar.Modulo_Conta;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.Modulo_Pedido
{
    internal class RepositorioPedido
    {
        private static RepositorioPedido instance = null;
        private int contadorPedido = 0;
        private ArrayList listaPedido = new ArrayList();
        public RepositorioPedido()
        {

        }
        public static RepositorioPedido Instancia
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioPedido();
                }
                return instance;
            }
        }

        internal void Inserir(Pedido Pedido)
        {
            contadorPedido++;

            Pedido.id = contadorPedido;

            listaPedido.Add(Pedido);
        }
        public ArrayList SelecionarTodos()
        {
            return listaPedido;
        }
        internal void Editar(int id, Pedido PedidoAtualizado)
        {
            Pedido PedidoSelecionado = SelecionarPorId(id);

            PedidoSelecionado.conta = PedidoAtualizado.conta;
            PedidoSelecionado.quantidade = PedidoAtualizado.quantidade;
            PedidoSelecionado.produto = PedidoAtualizado.produto;
        }
        internal Pedido SelecionarPorId(int id)
        {
            Pedido pedidoSelecionado = null;
            foreach (Pedido pedido in listaPedido)
            {
                if (pedido.id == id)
                {
                    pedidoSelecionado = pedido;

                    break;
                }
            }
            return pedidoSelecionado;
        }


    }
}
