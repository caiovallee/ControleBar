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
        RepositorioConta repositorioConta =  RepositorioConta.Instancia;
        Tela_Cliente telaCliente = new Tela_Cliente();
        RepositorioCliente repositorioCliente = RepositorioCliente.Instancia;
        Tela_Mesa telaMesa = new Tela_Mesa();
        Repositorio_Mesa repositorioMesa = Repositorio_Mesa.Instancia;
        internal string ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Contas");
            Console.WriteLine();
            Console.WriteLine("Digite 1 para Inserir Conta");
            Console.WriteLine("Digite 2 para Visualizar Contas");
            Console.WriteLine("Digite 3 para Editar Contas");
            Console.WriteLine("Digite 4 para Excluir Conta");
            Console.WriteLine("Digite 5 para Fechar Conta");
            Console.WriteLine("Digite s para sair");

            string opcaoConta = Console.ReadLine();
            return opcaoConta;
        }

        public double valorTotal = 0;
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
            telaCliente.VisualizarClientes(true);
            Console.WriteLine("Digite o id do cliente que a conta pertence: ");
            int idCliente = int.Parse(Console.ReadLine());
            Cliente cliente = repositorioCliente.SelecionarPorId(idCliente);
            telaMesa.VisualizarMesas(true);
            Console.WriteLine("Digite o id da mesa que a conta pertence");
            int IdMesa = int.Parse(Console.ReadLine());
            Mesa mesa = repositorioMesa.SelecionarPorId(IdMesa);
            double consumo = 0;


            Conta Conta = new Conta(numero,status,cliente,mesa,consumo);
            return Conta;
        }
        private void MostrarTabela(ArrayList Contas)
        {
            Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20} | {5,-20}", "id", "numero", "Aberta?", "cliente", "mesa", "consumo");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            foreach (Conta conta in Contas)
            {
                Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20} | {5,-20}", conta.id, conta.numero, conta.status, conta.cliente.nome, conta.mesa.numero, conta.consumo);
            }
            
        }
    
        internal void FecharConta()
        {
            MostrarCabecalho("Cadastro de Contas", "Fechando uma Conta já cadastrada...");

            
            VisualizarContas(true);

            Console.WriteLine();
            Console.WriteLine("Digite o id da Conta: ");
            int id = int.Parse(Console.ReadLine());

            
            Conta conta = repositorioConta.SelecionarPorId(id);

            
            if (conta == null)
            {
                MostrarMensagem("Conta não encontrada", ConsoleColor.DarkYellow);
                return;
            }

            
            if (!conta.status)
            {
                MostrarMensagem("A conta já está fechada", ConsoleColor.DarkYellow);
                return;
            }

            valorTotal += conta.consumo;
            conta.consumo = 0;
            conta.status = false;
            repositorioConta.Editar(conta.id, conta);

            MostrarMensagem("Conta fechada com sucesso", ConsoleColor.Green);
        }
    }
}
