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
    /// Lógica interna para TelaEditarNome.xaml
    /// </summary>
    public partial class TelaEditarNome : Window
    {
        public TelaEditarNome()
        {
            InitializeComponent();
            LblNomeAtual.Content = "Seu nome de jogador atual é: " + JogadorController.jogador.Nome;
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            string nome = TxtNovoNome.Text;
            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Nome inválido");
            } else
            {
                JogadorController.AlterarNomeJogador(JogadorController.jogador, nome);
                this.Close();
            }
        }
    }
}
