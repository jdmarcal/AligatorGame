using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Controller
{
    public class PartidaController
    {

        private static List<Partida> listPartidas = new List<Partida>();

        public static bool CadastrarNovaPartida(Partida partida)
        {
            listPartidas.Add(partida);
            Debug.WriteLine("Nova partida adicionada");
            return true;
        }

        public static Partida ProcurarUltimaPartida()
        {
            return listPartidas[listPartidas.Count];
        }


    }
}
