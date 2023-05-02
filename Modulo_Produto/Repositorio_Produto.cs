using ControleBar.Modulo_Produto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.Modulo_Produto
{
    internal class Repositorio_Produto
    {
        private int contadorProduto = 0;
        private ArrayList listaProduto = new ArrayList();
        internal void Inserir(Produto Produto)
        {
            contadorProduto++;

            Produto.id = contadorProduto;

            listaProduto.Add(Produto);
        }

        public ArrayList SelecionarTodos()
        {
            return listaProduto;
        }

        internal void Editar(int id, Produto ProdutoAtualizado)
        {
            Produto ProdutoSelecionada = SelecionarPorId(id);

            ProdutoSelecionada.valor = ProdutoAtualizado.valor;


        }
        internal void Excluir(int id)
        {
            Produto ProdutoSelecionada = SelecionarPorId(id);

            listaProduto.Remove(ProdutoSelecionada);

        }

        internal Produto SelecionarPorId(int id)
        {
            Produto ProdutoSelecionada = null;
            foreach (Produto c in listaProduto)
            {
                if (c.id == id)
                {
                    ProdutoSelecionada = c;

                    break;
                }
            }

            return ProdutoSelecionada;
        }
    }
}
