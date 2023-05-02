using ControleBar.Modulo_Garcom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.Compartilhado
{
     public class TelaBase
    {
        Repositorio_Garcom repositorioGarcom = new Repositorio_Garcom();
       

        public string ApresentarMenu()
            {
                Console.Clear();
                Console.WriteLine("Controle de bar 1.0\n");
                Console.WriteLine();
                Console.WriteLine("Digite [1] garcom ");
                Console.WriteLine("Digite [2] Mesas ");
                Console.WriteLine("Digite [3] Produto");
                Console.WriteLine("Digite [4] Clientes");
                Console.WriteLine("Digite [5] Contas \n");

                Console.WriteLine("Digite s para sair");

                string opcao = Console.ReadLine();
                return opcao;
            }
            public void MostrarCabecalho(string titulo, string subtitulo)
            {
                Console.Clear();
                Console.WriteLine(titulo + "\n");

                Console.WriteLine(subtitulo);
            }
            public void MostrarMensagem(string mensagem, ConsoleColor cor)
            {
                Console.ForegroundColor = cor;

                Console.WriteLine(mensagem);

                Console.ResetColor();
                Console.ReadLine();
            }
        }

    
}
