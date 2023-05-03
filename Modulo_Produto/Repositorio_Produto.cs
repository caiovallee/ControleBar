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
        private static Repositorio_Produto instance = null;
        private int contadorProduto = 0;
        private ArrayList listaProduto = new ArrayList();
        public Repositorio_Produto()
        {
            
        }
        public static Repositorio_Produto Instancia
        {
            get
            {
                if(instance == null)
                {
                    instance = new Repositorio_Produto();
                }
                return instance;
            }
        }
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
