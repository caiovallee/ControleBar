using ControleBar.Modulo_Cliente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ControleBar.Modulo_Cliente
{
    public class RepositorioCliente
    {
        private static RepositorioCliente instance = null;    

            public int contadorCliente = 0;
            public ArrayList listaCliente = new ArrayList();

        private RepositorioCliente()
        {
            
        }
        public static RepositorioCliente Instancia
        {
            get{
                if(instance == null)
                {
                    instance = new RepositorioCliente();
                }
                    return instance;               
               }
        }
        internal void Inserir(Cliente Cliente)
            {
                contadorCliente++;

                Cliente.id = contadorCliente;

                listaCliente.Add(Cliente);
            }

            public ArrayList SelecionarTodos()
            {
                return listaCliente;
            }

            internal void Editar(int id, Cliente ClienteAtualizado)
            {
                Cliente ClienteSelecionada = SelecionarPorId(id);

                ClienteSelecionada.nome = ClienteAtualizado.nome;


            }
            internal void Excluir(int id)
            {
                Cliente ClienteSelecionada = SelecionarPorId(id);

                listaCliente.Remove(ClienteSelecionada);

            }

            internal Cliente SelecionarPorId(int id)
            {
                Cliente ClienteSelecionado = null;
                foreach (Cliente cliente in listaCliente)
                {
                    if (cliente.id == id)
                    {
                        ClienteSelecionado = cliente;

                        break;
                    }
                }

                return ClienteSelecionado;
            }
        }
    }

