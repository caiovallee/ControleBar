﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.Modulo_Garcom
{
    public class Repositorio_Garcom
    {
        private int contadorGarcom = 0;
        private ArrayList listaGarcom = new ArrayList();
        internal void Inserir(Garcom garcom)
        {
            contadorGarcom++;

            garcom.id = contadorGarcom;

            listaGarcom.Add(garcom);
        }

        public ArrayList SelecionarTodos()
        {
            return listaGarcom;
        }

        internal void Editar(int id, Garcom GarcomAtualizado)
        {
            Garcom GarcomSelecionada = SelecionarPorId(id);

            GarcomSelecionada.nome = GarcomAtualizado.nome;
            

        }
        internal void Excluir(int id)
        {
            Garcom GarcomSelecionada = SelecionarPorId(id);

            listaGarcom.Remove(GarcomSelecionada);

        }

        internal Garcom SelecionarPorId(int id)
        {
            Garcom GarcomSelecionada = null;
            foreach (Garcom c in listaGarcom)
            {
                if (c.id == id)
                {
                    GarcomSelecionada = c;

                    break;
                }
            }

            return GarcomSelecionada;
        }
    }
}
