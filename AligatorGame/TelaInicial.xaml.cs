using Controlador;
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
    /// Lógica interna para TelaInicial.xaml
    /// </summary>
    public partial class TelaInicial : Window
    {
        public TelaInicial()
        {
            InitializeComponent();

            TxtNomeJogador.Content = "Você está jogando como: " + JogadorController.jogador.Nome;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GameConfig.Tempo = 60;
            GameConfig.TempoDeTroca = 2000;
            TelaDoJogo telaDoJogo = new TelaDoJogo();
            telaDoJogo.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GameConfig.Tempo = 60;
            GameConfig.TempoDeTroca = 1000;
            TelaDoJogo telaDoJogo = new TelaDoJogo();
            telaDoJogo.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GameConfig.Tempo = 60;
            GameConfig.TempoDeTroca = 700;
            TelaDoJogo telaDoJogo = new TelaDoJogo();
            telaDoJogo.ShowDialog();
        }

        private void LblEditarNome(object sender, RoutedEventArgs e)
        {
            GameConfig.Tempo = 60;
            GameConfig.TempoDeTroca = 700;
            TelaDoJogo telaDoJogo = new TelaDoJogo();
            telaDoJogo.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TelaEditarNome telaEditarNome = new TelaEditarNome();
            telaEditarNome.ShowDialog();
            TxtNomeJogador.Content = "Você está jogando como: " + JogadorController.jogador.Nome;
        }
    }
}
