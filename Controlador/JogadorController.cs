using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Models2.DAL;
using Models2;

namespace Controlador
{
    public class JogadorController
    {

        public static Jogador jogador { get; set; } // Referente a qual jogador está jogando agora.

        public static void AlterarNomeJogador(Jogador jj, string nome)
        {
            Jogador j = ProcurarJogadorPorId(jj.Id);
            j.Nome = nome;
            jj.Nome = nome;

            Contexto contexto = new Contexto();
            contexto.Entry(j).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();

        }

        public static void CadastrarJogador(Jogador jogador2)
        { 
            if(ProcurarJogadorPeloNome(jogador2.Nome) == null)
            {
                Contexto contexto = new Contexto();
                jogador = contexto.Jogadores.Add(jogador2);
                contexto.SaveChanges();
            }
            jogador = ProcurarJogadorPeloNome(jogador2.Nome);
        }

        public static Jogador ProcurarJogadorPeloNome(string nome)
        {
            Contexto contexto = new Contexto();
            var j = (from p in contexto.Jogadores where p.Nome.Equals(nome) select p).FirstOrDefault();
            return j;
        }

        public static Jogador ProcurarJogadorPorId(int id)
        {
            Contexto contexto = new Contexto();
            var j = (from p in contexto.Jogadores where p.Id == id select p).FirstOrDefault();
            return j;
        }

    }
}
