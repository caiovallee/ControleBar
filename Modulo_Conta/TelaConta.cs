using ControleBar.Compartilhado;
using ControleBar.Modulo_Cliente;
using ControleBar.Modulo_Conta;
using ControleBar.Modulo_Mesa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.Modulo_Conta
{
    internal class TelaConta:TelaBase
    {
        RepositorioConta repositorioConta = new RepositorioConta();
        Tela_Cliente telaCliente = new Tela_Cliente();
        RepositorioCliente repositorioCliente = new RepositorioCliente();
        Tela_Mesa telaMesa = new Tela_Mesa();
        Repositorio_Mesa repositorioMesa = new Repositorio_Mesa();
        internal string ApresentarMenu()
        {
            

            Console.Clear();
            Console.WriteLine("Cadostro de Contas");
            Console.WriteLine();
            Console.WriteLine("Digite 1 para Inserir Conta");
            Console.WriteLine("Digite 2 para Visualizar Contas");
            Console.WriteLine("Digite 3 para Editar Contas");
            Console.WriteLine("Digite 4 para Excluir Conta");

            Console.WriteLine("Digite s para sair");

            string opcaoConta = Console.ReadLine();
            return opcaoConta;
        }

        internal void EditarConta()
        {
            MostrarCabecalho("Cadostro de Contas", "Editando uma Conta já cadastrado...");
            VisualizarContas(false);
            Console.WriteLine();
            Console.WriteLine("Digite o id da Conta: ");
            int id = int.Parse(Console.ReadLine());
            Conta ContaAtualizado = ObterConta();

            repositorioConta.Editar(id, ContaAtualizado);


            MostrarMensagem("Conta editado com sucesso", ConsoleColor.Green);
        }
        public void VisualizarContas(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Cadostro de Contas", "Visualizando Contas já cadastrados...");

            ArrayList Contas = repositorioConta.SelecionarTodos();
            if (Contas.Count == 0)
            {
                MostrarMensagem("nenhuma Conta cadostrado", ConsoleColor.DarkYellow);

            }
            MostrarTabela(Contas);
            Console.ReadLine();

        }

        internal void ExcluirConta()
        {
            MostrarCabecalho("Cadostro de Contas", "Excluindo uma Conta já cadastrado...");
            VisualizarContas(false);
            Console.WriteLine();
            Console.WriteLine("Digite o id do Conta: ");
            int id = int.Parse(Console.ReadLine());

            repositorioConta.Excluir(id);

            MostrarMensagem("Conta excluido com sucesso", ConsoleColor.Green);
        }

        internal void inserirNovoConta()
        {

            MostrarCabecalho("Cadostro de Contas", "Inserindo um novo Conta");

            Conta Conta = ObterConta();
            repositorioConta.Inserir(Conta);

            MostrarMensagem("Conta Cadastrado com sucesso", ConsoleColor.DarkGreen);
        }

        private Conta ObterConta()
        {
            Console.WriteLine("Digite o numero da Conta");
            int numero = int.Parse(Console.ReadLine());
            bool status = true;
            Console.WriteLine("Digite o id do cliente que a conta pertence");
            telaCliente.VisualizarClientes(true);
            int idCliente = int.Parse(Console.ReadLine());
            Cliente cliente = repositorioCliente.SelecionarPorId(idCliente);
            Console.WriteLine("Digite o id da mesa que a conta pertence");
            telaMesa.VisualizarMesas(true);
            int IdMesa = int.Parse(Console.ReadLine());
            Mesa mesa = repositorioMesa.SelecionarPorId(IdMesa);
            double consumo = 0;


            Conta Conta = new Conta(numero,status,cliente,mesa,consumo);
            return Conta;
        }
        private void MostrarTabela(ArrayList Contas)
        {
            Console.WriteLine("{0, -10} | {1, -20}| {2, -20}| {3, -20}| {4, -20}| {5, -20}", "id", "numero","status","cliente","mesa","consumo");

            Console.WriteLine("----------------------------------------------------------------------------------------");
            foreach (Conta conta in Contas)
            {
                Console.WriteLine("{0, -10} | {1, -20} | { 2, -20}| { 3, -20}| { 4, -20}| { 5, -20}", conta.id, conta.numero,conta.status,conta.cliente,conta.mesa,conta.consumo);
            }
            Console.ReadLine();
        }
    }
}
