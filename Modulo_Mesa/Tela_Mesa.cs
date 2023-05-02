using ControleBar.Compartilhado;
using ControleBar.Modulo_Mesa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.Modulo_Mesa
{
    internal class Tela_Mesa : TelaBase
    {

        Repositorio_Mesa repositorioMesa = new Repositorio_Mesa();
        internal string ApresentarMenu()
        {

            Console.Clear();
            Console.WriteLine("Cadostro de Mesas");
            Console.WriteLine();
            Console.WriteLine("Digite 1 para Inserir Mesa");
            Console.WriteLine("Digite 2 para Visualizar Mesas");
            Console.WriteLine("Digite 3 para Editar Mesas");
            Console.WriteLine("Digite 4 para Excluir Mesa");

            Console.WriteLine("Digite s para sair");

            string opcaoMesa = Console.ReadLine();
            return opcaoMesa;
        }

        internal void EditarMesa()
        {
            MostrarCabecalho("Cadostro de Mesas", "Editando uma Mesa já cadastrado...");
            VisualizarMesas(false);
            Console.WriteLine();
            Console.WriteLine("Digite o id do Mesa: ");
            int id = int.Parse(Console.ReadLine());

            Mesa MesaAtualizado = ObterMesa();

            repositorioMesa.Editar(id, MesaAtualizado);


            MostrarMensagem("Mesa editado com sucesso", ConsoleColor.Green);
        }
        public void VisualizarMesas(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Cadostro de Mesas", "Visualizando Mesas já cadastrados...");

            ArrayList Mesas = repositorioMesa.SelecionarTodos();
            if (Mesas.Count == 0)
            {
                MostrarMensagem("nenhuma Mesa cadostrado", ConsoleColor.DarkYellow);

            }
            MostrarTabela(Mesas);
            Console.ReadLine();

        }

        internal void ExcluirMesa()
        {
            MostrarCabecalho("Cadostro de Mesas", "Excluindo uma Mesa já cadastrado...");
            VisualizarMesas(false);
            Console.WriteLine();
            Console.WriteLine("Digite o id do Mesa: ");
            int id = int.Parse(Console.ReadLine());

            repositorioMesa.Excluir(id);

            MostrarMensagem("Mesa excluido com sucesso", ConsoleColor.Green);
        }

        internal void inserirNovoMesa()
        {

            MostrarCabecalho("Cadostro de Mesas", "Inserindo uma novo Mesa");

            Mesa Mesa = ObterMesa();
            repositorioMesa.Inserir(Mesa);

            MostrarMensagem("Mesa Cadastrado com sucesso", ConsoleColor.DarkGreen);
        }

        private Mesa ObterMesa()
        {
            Console.WriteLine("Digite o Numero da Mesa");
            int numero = int.Parse(Console.ReadLine());
            Mesa Mesa = new Mesa(numero);
            return Mesa;
        }
        private void MostrarTabela(ArrayList Mesas)
        {
            Console.WriteLine("{0, -10} | {1, -20}", "id", "numero");

            Console.WriteLine("----------------------------------------------------------------------------------------");
            foreach (Mesa Mesa in Mesas)
            {
                Console.WriteLine("{0, -10} | {1, -20}", Mesa.id, Mesa.numero);
            }
            Console.ReadLine();
        }
    }
}
