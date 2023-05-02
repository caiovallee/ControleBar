using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleBar.Compartilhado;

namespace ControleBar.Modulo_Garcom
{
    public class Tela_Garcom : TelaBase
    {
        Repositorio_Garcom repositorioGarcom = new Repositorio_Garcom();

        internal string ApresentarMenu()
        {

            Console.Clear();
            Console.WriteLine("Cadostro de Garcoms");
            Console.WriteLine();
            Console.WriteLine("Digite 1 para Inserir Garcom");
            Console.WriteLine("Digite 2 para Visualizar Garcoms");
            Console.WriteLine("Digite 3 para Editar Garcoms");
            Console.WriteLine("Digite 4 para Excluir Garcom");

            Console.WriteLine("Digite s para sair");

            string opcaoGarcom = Console.ReadLine();
            return opcaoGarcom;
        }

        internal void EditarGarcom()
        {
            MostrarCabecalho("Cadostro de Garcoms", "Editando uma Garcom já cadastrado...");
            VisualizarGarcoms(false);
            Console.WriteLine();
            Console.WriteLine("Digite o id do Garcom: ");
            int id = int.Parse(Console.ReadLine());

            Garcom GarcomAtualizado = ObterGarcom();

            repositorioGarcom.Editar(id, GarcomAtualizado);


            MostrarMensagem("Garcom editado com sucesso", ConsoleColor.Green);
        }
        public void VisualizarGarcoms(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Cadostro de Garcoms", "Visualizando Garcoms já cadastrados...");

            ArrayList Garcoms = repositorioGarcom.SelecionarTodos();
            if (Garcoms.Count == 0)
            {
                MostrarMensagem("nenhuma Garcom cadostrado", ConsoleColor.DarkYellow);

            }
            MostrarTabela(Garcoms);
            Console.ReadLine();

        }

        internal void ExcluirGarcom()
        {
            MostrarCabecalho("Cadostro de Garcoms", "Excluindo uma Garcom já cadastrado...");
            VisualizarGarcoms(false);
            Console.WriteLine();
            Console.WriteLine("Digite o id do Garcom: ");
            int id = int.Parse(Console.ReadLine());

            repositorioGarcom.Excluir(id);

            MostrarMensagem("Garcom excluido com sucesso", ConsoleColor.Green);
        }

        internal void inserirNovoGarcom()
        {

            MostrarCabecalho("Cadostro de Garcoms", "Inserindo um novo Garcom");

            Garcom Garcom = ObterGarcom();
            repositorioGarcom.Inserir(Garcom);

            MostrarMensagem("Garcom Cadastrado com sucesso", ConsoleColor.DarkGreen);
        }

        private Garcom ObterGarcom()
        {
            Console.WriteLine("Digite o nome do garcom");
            string nome = Console.ReadLine();
            Garcom Garcom = new Garcom(nome);
            return Garcom;
        }
        private void MostrarTabela(ArrayList Garcoms)
        {
            Console.WriteLine("{0, -10} | {1, -20}","id", "nome");

            Console.WriteLine("----------------------------------------------------------------------------------------");
            foreach (Garcom Garcom in Garcoms)
            {
                Console.WriteLine("{0, -10} | {1, -20}", Garcom.id, Garcom.nome);
            }
            Console.ReadLine();
        }

    }
}
