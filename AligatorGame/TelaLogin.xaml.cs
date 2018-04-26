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
    /// Lógica interna para TelaLogin.xaml
    /// </summary>
    public partial class TelaLogin : Window
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nome = TxtNomeJogador.Text;
            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Nome inválido.");
            }
            else
            {
                Jogador jogador = new Jogador();
                jogador.Nome = nome;
                JogadorController.CadastrarJogador(jogador);
                this.Close();
            }
        }
    }
}
