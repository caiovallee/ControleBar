using ControleBar.Compartilhado;
using ControleBar.Modulo_Produto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.Modulo_Produto
{
    internal class Tela_Produto : TelaBase
    {
        Repositorio_Produto repositorioProduto = Repositorio_Produto.Instancia;
        internal string ApresentarMenu()
        {

            Console.Clear();
            Console.WriteLine("Cadostro de Produtos");
            Console.WriteLine();
            Console.WriteLine("Digite 1 para Inserir Produto");
            Console.WriteLine("Digite 2 para Visualizar Produtos");
            Console.WriteLine("Digite 3 para Editar Produtos");
            Console.WriteLine("Digite 4 para Excluir Produto");

            Console.WriteLine("Digite s para sair");

            string opcaoProduto = Console.ReadLine();
            return opcaoProduto;
        }

        internal void EditarProduto()
        {
            MostrarCabecalho("Cadostro de Produtos", "Editando uma Produto já cadastrado...");
            VisualizarProdutos(false);
            Console.WriteLine();
            Console.WriteLine("Digite o id do Produto: ");
            int id = int.Parse(Console.ReadLine());

            Produto ProdutoAtualizado = ObterProduto();

            repositorioProduto.Editar(id, ProdutoAtualizado);


            MostrarMensagem("Produto editado com sucesso", ConsoleColor.Green);
        }
        public void VisualizarProdutos(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Cadostro de Produtos", "Visualizando Produtos já cadastrados...");

            ArrayList Produtos = repositorioProduto.SelecionarTodos();
            if (Produtos.Count == 0)
            {
                MostrarMensagem("nenhuma Produto cadostrado", ConsoleColor.DarkYellow);

            }
            MostrarTabela(Produtos);
           

        }

        internal void ExcluirProduto()
        {
            MostrarCabecalho("Cadostro de Produtos", "Excluindo uma Produto já cadastrado...");
            VisualizarProdutos(false);
            Console.WriteLine();
            Console.WriteLine("Digite o id do Produto: ");
            int id = int.Parse(Console.ReadLine());

            repositorioProduto.Excluir(id);

            MostrarMensagem("Produto excluido com sucesso", ConsoleColor.Green);
        }

        internal void inserirNovoProduto()
        {

            MostrarCabecalho("Cadostro de Produtos", "Inserindo um novo Produto");

            Produto Produto = ObterProduto();
            repositorioProduto.Inserir(Produto);

            MostrarMensagem("Produto Cadastrado com sucesso", ConsoleColor.DarkGreen);
        }

        private Produto ObterProduto()
        {
            Console.WriteLine("Digite o nome do Produto");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o preco do Produto");
            double valor = double.Parse(Console.ReadLine());
            Produto Produto = new Produto(nome,valor);
            return Produto;
        }
        private void MostrarTabela(ArrayList Produtos)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2,-20}", "id","nome","Preco");

            Console.WriteLine("----------------------------------------------------------------------------------------");
            foreach (Produto Produto in Produtos)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2,-20}", Produto.id,Produto.nome,Produto.valor);
            }
            
        }
    }
}
