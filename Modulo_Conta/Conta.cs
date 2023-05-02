using ControleBar.Modulo_Cliente;
using ControleBar.Modulo_Mesa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.Modulo_Conta
{
    internal class Conta
    {
        public int id;
        public int numero;
        public bool status;
        public Cliente cliente;
        public Mesa mesa;
        public double consumo;

        public Conta(int numero,bool status,Cliente cliente,Mesa mesa,double consumo)
        {
            this.numero = numero;
            this.cliente = cliente;
            this.status = status;
            this.mesa = mesa;
            this.consumo= consumo;
        }


    }
}
