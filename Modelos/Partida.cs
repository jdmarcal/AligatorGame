using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Partida
    {
        public int Id { get; set; }
        public int IdJogador { get; set; }
        public int Acertos { get; set; }
        public int Erros { get; set; }
    }
}
