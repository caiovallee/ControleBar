using ControleBar.Modulo_Conta;
using ControleBar.Modulo_Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.Modulo_Pedido
{
    internal class Pedido
    {
        public int id;
        public int quantidade;
        public Produto produto;
        public Conta conta;
        

        public Pedido(Conta conta, Produto produto,int quantidade)
        {
            this.conta = conta;
            this.produto = produto;
            this.quantidade = quantidade;
        }
    }
}
