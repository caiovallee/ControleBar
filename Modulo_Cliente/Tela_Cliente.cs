using ControleBar.Compartilhado;
using ControleBar.Modulo_Cliente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.Modulo_Cliente
{
    internal class Tela_Cliente : TelaBase
    {
        RepositorioCliente repositorioCliente = new RepositorioCliente();
        internal string ApresentarMenu()
        {

            Console.Clear();
            Console.WriteLine("Cadostro de Clientes");
            Console.WriteLine();
            Console.WriteLine("Digite 1 para Inserir Cliente");
            Console.WriteLine("Digite 2 para Visualizar Clientes");
            Console.WriteLine("Digite 3 para Editar Clientes");
            Console.WriteLine("Digite 4 para Excluir Cliente");

            Console.WriteLine("Digite s para sair");

            string opcaoCliente = Console.ReadLine();
            return opcaoCliente;
        }

        internal void EditarCliente()
        {
            MostrarCabecalho("Cadostro de Clientes", "Editando uma Cliente já cadastrado...");
            VisualizarClientes(false);
            Console.WriteLine();
            Console.WriteLine("Digite o id do Cliente: ");
            int id = int.Parse(Console.ReadLine());

            Cliente ClienteAtualizado = ObterCliente();

            repositorioCliente.Editar(id, ClienteAtualizado);


            MostrarMensagem("Cliente editado com sucesso", ConsoleColor.Green);
        }
        public void VisualizarClientes(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Cadostro de Clientes", "Visualizando Clientes já cadastrados...");

            ArrayList Clientes = repositorioCliente.SelecionarTodos();
            if (Clientes.Count == 0)
            {
                MostrarMensagem("nenhuma Cliente cadostrado", ConsoleColor.DarkYellow);

            }
            MostrarTabela(Clientes);
            Console.ReadLine();

        }

        internal void ExcluirCliente()
        {
            MostrarCabecalho("Cadostro de Clientes", "Excluindo uma Cliente já cadastrado...");
            VisualizarClientes(false);
            Console.WriteLine();
            Console.WriteLine("Digite o id do Cliente: ");
            int id = int.Parse(Console.ReadLine());

            repositorioCliente.Excluir(id);

            MostrarMensagem("Cliente excluido com sucesso", ConsoleColor.Green);
        }

        internal void inserirNovoCliente()
        {

            MostrarCabecalho("Cadostro de Clientes", "Inserindo um novo Cliente");

            Cliente Cliente = ObterCliente();
            repositorioCliente.Inserir(Cliente);

            MostrarMensagem("Cliente Cadastrado com sucesso", ConsoleColor.DarkGreen);
        }

        private Cliente ObterCliente()
        {
            Console.WriteLine("Digite o nome do Cliente");
            string nome = Console.ReadLine();
            Cliente Cliente = new Cliente(nome);
            return Cliente;
        }
        private void MostrarTabela(ArrayList Clientes)
        {
            Console.WriteLine("{0, -10} | {1, -20}", "id", "nome");

            Console.WriteLine("----------------------------------------------------------------------------------------");
            foreach (Cliente Cliente in Clientes)
            {
                Console.WriteLine("{0, -10} | {1, -20}", Cliente.id, Cliente.nome);
            }
            Console.ReadLine();
        }
    }
}
