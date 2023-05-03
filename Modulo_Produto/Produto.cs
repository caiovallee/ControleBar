using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.Modulo_Produto
{
    public class Produto
    {
        public int id;
        public string nome;
        public double valor;
        
        public Produto(string nome,double valor)
        {
            this.nome = nome;
            this.valor = valor;
        }
    }
}
