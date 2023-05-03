﻿using ControleBar.Modulo_Cliente;
using ControleBar.Modulo_Mesa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.Modulo_Mesa
{
    public class Repositorio_Mesa
    {
        private static Repositorio_Mesa instance = null;
        private int contadorMesa = 0;
        private ArrayList listaMesa = new ArrayList();
        public Repositorio_Mesa()
        {
            
        }
        public static Repositorio_Mesa Instancia
        {
            get {
                if(instance == null)
                {
                    instance = new Repositorio_Mesa();
                }
                return instance;
            }
        }
        internal void Inserir(Mesa Mesa)
        {
            contadorMesa++;

            Mesa.id = contadorMesa;

            listaMesa.Add(Mesa);
        }

        public ArrayList SelecionarTodos()
        {
            return listaMesa;
        }

        internal void Editar(int id, Mesa MesaAtualizado)
        {
            Mesa MesaSelecionada = SelecionarPorId(id);

            MesaSelecionada.numero = MesaAtualizado.numero;


        }
        internal void Excluir(int id)
        {
            Mesa MesaSelecionada = SelecionarPorId(id);

            listaMesa.Remove(MesaSelecionada);

        }

        internal Mesa SelecionarPorId(int id)
        {
            Mesa MesaSelecionada = null;
            foreach (Mesa mesa in listaMesa)
            {
                if (mesa.id == id)
                {
                    MesaSelecionada = mesa;

                    break;
                }
            }

            return MesaSelecionada;
        }
    }
}
