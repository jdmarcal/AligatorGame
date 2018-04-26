using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AligatorGame
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer timer;

        public MainWindow()
        {
            InitializeComponent();

            LoadProgressBar.Value = 0;
            LoadProgressBar.Maximum = 100;

            timer = new Timer();
            timer.Interval = 100;
            timer.Elapsed += new ElapsedEventHandler(onTimerTick);
            timer.Enabled = true;

        }

        private void EsconderBarraDeProgresso()
        {
            LoadProgressBar.Visibility = Visibility.Hidden;
        }

        private void AbrirTelaPrincipal()
        {
            TelaInicial tela = new TelaInicial();
            tela.Show();
            this.Hide();
        }

        private void onTimerTick(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)(() =>
            {
                if (LoadProgressBar.Value < 100)
                {
                    LoadProgressBar.Value += 1;
                }
                else
                {
                    timer.Stop();
                    EsconderBarraDeProgresso();
                    TelaLogin telaLogin = new TelaLogin();
                    telaLogin.ShowDialog();
                    AbrirTelaPrincipal();

                }

                if(LoadProgressBar.Value == 10)
                {
                    TxtDicas.Content = "Cuidado! Não bata no crocodilo bonitinho...";
                } else if(LoadProgressBar.Value == 30)
                {
                    TxtDicas.Content = "Você pode utilizar atalhos do teclado para bater =)";
                } else if(LoadProgressBar.Value == 50)
                {
                    TxtDicas.Content = "A cada batida correta você acumula pontos!";
                } else if(LoadProgressBar.Value == 70)
                {
                    TxtDicas.Content = "Chame seus amiguinhos para jogar!";
                }

            }));
        }
    }
}
