using ControleBar.Modulo_Garcom;
using ControleBar.Modulo_Mesa;
using ControleBar.Modulo_Produto;
using ControleBar.Compartilhado;
using ControleBar.Modulo_Cliente;
using System.Security.Cryptography.X509Certificates;
using ControleBar.Modulo_Conta;
using System.Collections;
using ControleBar.Modulo_Pedido;

namespace ControleBar
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Program progam = new Program();
            TelaBase telaBase = new TelaBase();
            RepositorioBase repositorioBase =new RepositorioBase();
            Tela_Garcom telaGarcom = new Tela_Garcom();
            Repositorio_Garcom repositorioGarcom = Repositorio_Garcom.Instancia;
            Tela_Mesa telaMesa = new Tela_Mesa();
            Tela_Produto telaProduto = new Tela_Produto();
            Repositorio_Mesa repositorioMesa = Repositorio_Mesa.Instancia;
            RepositorioCliente repositorioCliente = RepositorioCliente.Instancia;
            Repositorio_Produto repositorioProduto = Repositorio_Produto.Instancia;
            Tela_Cliente telaCliente = new Tela_Cliente();
            TelaConta telaConta = new TelaConta();
            RepositorioConta repositorioConta = RepositorioConta.Instancia;
            TelaPedido telaPedido = new TelaPedido();
            RepositorioPedido repositorioPedido = RepositorioPedido.Instancia;

            void PopularListas()
            {
                Cliente cliente1 = new Cliente("Caio a Preguiça");
                Cliente cliente2 = new Cliente("Davi o Surfista");
                Cliente cliente3 = new Cliente("Fabian o Sumido");
                Garcom garcom1 = new Garcom("gilberto");
                Mesa mesa1 = new Mesa(10);
                Mesa mesa2 = new Mesa(11);
                Mesa mesa3 = new Mesa(12);
                Mesa mesa4 = new Mesa(13);
                Produto produto1 = new Produto("Pitu", 50);
                Produto produto2 = new Produto("Vodka", 25);
                Produto produto3 = new Produto("vinho", 35);
                repositorioProduto.Inserir(produto1);
                repositorioProduto.Inserir(produto2);
                repositorioProduto.Inserir(produto3);
                repositorioMesa.Inserir(mesa1);
                repositorioMesa.Inserir(mesa2);
                repositorioMesa.Inserir(mesa3);
                repositorioMesa.Inserir(mesa4);
                repositorioGarcom.Inserir(garcom1);
                repositorioCliente.Inserir(cliente1);
                repositorioCliente.Inserir(cliente2);
                repositorioCliente.Inserir(cliente3);
            }
            PopularListas();
                   
           
            while (true)
            {
                string opcao = telaBase.ApresentarMenu();
                if (opcao == "s")
                {
                    continue;
                }
                else if (opcao == "1")
                {
                    string opcaoGarcom = telaGarcom.ApresentarMenu();
                    if (opcaoGarcom == "s")
                    {
                        continue;
                    }
                    else if (opcaoGarcom == "1")
                    {
                        telaGarcom.inserirNovoGarcom();
                    }
                    else if (opcaoGarcom == "2")
                    {
                        telaGarcom.VisualizarGarcoms(true);
                    }
                    else if (opcaoGarcom == "3")
                    {
                        telaGarcom.EditarGarcom();
                    }
                    else if (opcaoGarcom == "4")
                    {
                        telaGarcom.ExcluirGarcom();
                    }
                }
                else if (opcao == "2")
                {
                    string opcaoMesa = telaMesa.ApresentarMenu();
                    if (opcaoMesa == "s")
                    {
                        continue;
                    }
                    else if (opcaoMesa == "1")
                    {
                        telaMesa.inserirNovoMesa();
                    }
                    else if (opcaoMesa == "2")
                    {
                        telaMesa.VisualizarMesas(true);
                    }
                    else if (opcaoMesa == "3")
                    {
                        telaMesa.EditarMesa();
                    }
                    else if (opcaoMesa == "4")
                    {
                        telaMesa.ExcluirMesa();
                    }
                }
                else if (opcao == "3")
                {
                    string opcaoProduto = telaProduto.ApresentarMenu();
                    if (opcaoProduto == "s")
                    {
                        continue;
                    }
                    else if (opcaoProduto == "1")
                    {
                        telaProduto.inserirNovoProduto();
                    }
                    else if (opcaoProduto == "2")
                    {
                        telaProduto.VisualizarProdutos(true);
                    }
                    else if (opcaoProduto == "3")
                    {
                        telaProduto.EditarProduto();
                    }
                    else if (opcaoProduto == "4")
                    {
                        telaProduto.ExcluirProduto();
                    }
                }
                else if (opcao == "4")
                {
                    string opcaoCliente = telaCliente.ApresentarMenu();
                    if (opcaoCliente == "s")
                    {
                        continue;
                    }
                    else if (opcaoCliente == "1")
                    {
                        telaCliente.inserirNovoCliente();
                    }
                    else if (opcaoCliente == "2")
                    {
                        telaCliente.VisualizarClientes(true);
                    }
                    else if (opcaoCliente == "3")
                    {
                        telaCliente.EditarCliente();
                    }
                    else if (opcaoCliente == "4")
                    {
                        telaCliente.ExcluirCliente();
                    }
                }
                else if (opcao == "5")

                {
                    string opcaoConta = telaConta.ApresentarMenu();
                    if (opcaoConta == "s")
                    {
                        continue;
                    }
                    else if (opcaoConta == "1")
                    {
                        telaConta.inserirNovoConta();
                    }
                    else if (opcaoConta == "2")
                    {
                        telaConta.VisualizarContas(true);
                    }
                    else if (opcaoConta == "3")
                    {
                        telaConta.EditarConta();
                    }
                    else if (opcaoConta == "4")
                    {
                        telaConta.ExcluirConta();
                    }
                    else if (opcaoConta == "5")
                    {
                        telaConta.FecharConta();
                    }
                }
                else if (opcao == "6")
                {
                    string opcaoPedido = telaPedido.ApresentarMenu();
                    if(opcaoPedido == "s")
                    {
                        continue;
                    }
                    else if (opcaoPedido == "1")
                    {
                        telaPedido.inserirNovoPedido();
                    }
                    else if (opcaoPedido == "2")
                    {
                        telaPedido.VisualizarPedidos(true);
                    }
                    else if (opcaoPedido == "3")
                    {
                        telaPedido.EditarPedido();
                    }
                    else if (opcaoPedido == "4")
                    {
                        telaPedido.ExcluirPedido();
                    }

                }
                else if (opcao == "7")
                {
                    Console.WriteLine($"O valor arrecadado foi de {telaConta.valorTotal}");
                    Console.ReadLine();
                }

            }
        }
        
        }
    }
