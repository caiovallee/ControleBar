using ControleBar.Compartilhado;
using ControleBar.Modulo_Cliente;
using ControleBar.Modulo_Conta;
using ControleBar.Modulo_Produto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.Modulo_Pedido
{
    internal class TelaPedido:TelaBase
    {
        TelaConta telaConta = new TelaConta();
        RepositorioConta repositorioConta = RepositorioConta.Instancia;
        Tela_Produto telaProduto = new Tela_Produto();
        Repositorio_Produto repositorioProduto = Repositorio_Produto.Instancia;
        RepositorioPedido repositorioPedido = RepositorioPedido.Instancia;
        internal string ApresentarMenu()
        {

            Console.Clear();
            Console.WriteLine("Consultor de Pedidos");
            Console.WriteLine();
            Console.WriteLine("Digite 1 Para realizar um pedido");
            Console.WriteLine("Digite 2 Para Visualizar pedidos feitos");
            Console.WriteLine("Digite 3 Para editar Pedidos");
            Console.WriteLine("Digite 4 Para Excluir pedidos");
            Console.WriteLine("Digite s para sair");

            string opcaoPedido = Console.ReadLine();
            return opcaoPedido;
        }

        internal void inserirNovoPedido()
        {

            MostrarCabecalho("Consultor de Pedidos", "Inserindo um novo Pedido");

            Pedido pedido = ObterPedido();
            repositorioPedido.Inserir(pedido);

            MostrarMensagem("Pedido Realizado com sucesso", ConsoleColor.DarkGreen);
        }

        private Pedido ObterPedido()
        {

            telaConta.VisualizarContas(true);
            Console.WriteLine("Digite o id a que a conta pertence");
            int idConta = int.Parse(Console.ReadLine());
            Conta conta = repositorioConta.SelecionarPorId(idConta);
            Console.WriteLine("Apenas contas Abertas podem fazer pedido");
                
           
            telaProduto.VisualizarProdutos(true);
            Console.WriteLine("Informe o id do produto desejado");
            int idProduto = int.Parse(Console.ReadLine());
            Produto produto = repositorioProduto.SelecionarPorId(idProduto);
            Console.WriteLine($"Informe a quantidade desejada de {produto.nome}");
            int quantidade = int.Parse(Console.ReadLine());
            conta.consumo += produto.valor * quantidade;

            Pedido pedido = new Pedido(conta, produto,quantidade);

            return pedido;
        }


        internal void EditarPedido()
        {
            MostrarCabecalho("Cadostro de Pedidos", "Editando uma Pedido já cadastrado...");
            VisualizarPedidos(false);
            Console.WriteLine();
            Console.WriteLine("Digite o id do Produto: ");
            int id = int.Parse(Console.ReadLine());

            Pedido PedidoAtualizado = ObterPedido();

            repositorioPedido.Editar(id, PedidoAtualizado);


            MostrarMensagem("Pedido editado com sucesso", ConsoleColor.Green);
        }

        public void VisualizarPedidos(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Cadastro de Pedidos", "Visualizando Pedidos já cadastrados...");

            ArrayList pedidos = repositorioPedido.SelecionarTodos();

            MostrarTabela(pedidos);
            Console.ReadLine();

        }

        private void MostrarTabela(ArrayList pedidos)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2,-20} | {3,-20}", "id","Conta","Produto","Quantidade");

            Console.WriteLine("----------------------------------------------------------------------------------------");
            foreach (Pedido pedido in pedidos)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2,-20} | {3,-20}", pedido.id, pedido.conta.numero, pedido.produto.nome, pedido.quantidade);
            }

        }
        internal void ExcluirPedido()
        {
            MostrarCabecalho("Cadostro de Pedidos", "Excluindo um Pedido já cadastrado...");
            VisualizarPedidos(false);
            Console.WriteLine();
            Console.WriteLine("Digite o id do Pedido: ");
            int id = int.Parse(Console.ReadLine());

            repositorioConta.Excluir(id);

            MostrarMensagem("Conta excluido com sucesso", ConsoleColor.Green);
        }

    }
}
