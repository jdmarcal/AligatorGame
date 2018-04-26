using Models2;
using Models2.DAL;
using System.Diagnostics;
using System.Linq;

namespace Controlador
{
    public class PartidaController
    {

        //private static List<Partida> listPartidas = new List<Partida>();

        public static void CadastrarNovaPartida(Partida partida)
        {
            //listPartidas.Add(partida);
            //Debug.WriteLine("Nova partida adicionada");
            //return true;
            partida.IdJogador = JogadorController.jogador.Id;
            Contexto ctx = new Contexto();
            ctx.Partidas.Add(partida);
            ctx.SaveChanges();

        }

        public static Partida ProcurarUltimaPartida()
        {
            //return listPartidas[listPartidas.Count - 1];
            Contexto ctx = new Contexto();

            var c = (from x in ctx.Partidas select x).OrderByDescending(x => x.Id).FirstOrDefault();
            Debug.WriteLine(c.Id + " partida jogada");

            return c;
        }

        public static int GetPartidaScore(Partida partida)
        {
            return partida.Acertos - partida.Erros;
        }

    }
}
