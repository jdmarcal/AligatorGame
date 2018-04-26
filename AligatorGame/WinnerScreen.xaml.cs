using Controlador;
using Models2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AligatorGame
{
    /// <summary>
    /// Lógica interna para WinnerScreen.xaml
    /// </summary>
    public partial class WinnerScreen : Window
    {

        Partida partida;

        public WinnerScreen()
        {
            InitializeComponent();

            partida = PartidaController.ProcurarUltimaPartida();
            if(partida != null)
            {

                Partida partida = PartidaController.ProcurarUltimaPartida();

                TxtScore.Content = "" + PartidaController.GetPartidaScore(partida);
                TxtAcertos.Content = "Total de acertos: " + partida.Acertos;
                TxtErros.Content = "Total de erros: " + partida.Erros;
            }
            
        }
    }
}
