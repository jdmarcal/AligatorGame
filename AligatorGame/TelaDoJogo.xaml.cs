using Controlador;
using Models2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
    /// Lógica interna para TelaDoJogo.xaml
    /// </summary>
    public partial class TelaDoJogo : Window
    {

        private static string IMG_TYPE_TUNEL_VAZIO = "pack://application:,,/tunel_sem_crocodilo.png";
        private static string IMG_TYPE_CROCODILO_LEGAL = "pack://application:,,/tunel_com_crocodilo_legal.png";
        private static string IMG_TYPE_CROCODILO_MALVADO = "pack://application:,,/tunel_com_crocodilo.png";

        System.Timers.Timer timer; // timer para os crocodilos
        System.Timers.Timer timerTick; // timer para o relógio

 

        int casaAnterior = 9;
        bool acabou = false;

        Partida partida;

        public TelaDoJogo()
        {
            InitializeComponent();
            RealizarConfiguracoesInicias();

            partida = new Partida();

            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(onTimerTick);
            timer.Enabled = true;
            timer.Interval = GameConfig.TempoDeTroca;

            timerTick = new System.Timers.Timer();
            timerTick.Elapsed += new ElapsedEventHandler(onTimerTickTimer);
            timerTick.Enabled = true;
            timerTick.Interval = 1000;

        }

        private void onTimerTickTimer(object sender, ElapsedEventArgs e)
        {
            if(GameConfig.Tempo == 0 && !acabou)
            {
                acabou = true;
                timer.Stop();
                timerTick.Stop();
                PartidaController.CadastrarNovaPartida(partida);
                this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)(() =>
                {
                    WinnerScreen winnerScreen = new WinnerScreen();
                    winnerScreen.ShowDialog();
                }));
                this.Dispatcher.Invoke(new Action(() => this.Hide()));
            } else
            {
                if (GameConfig.Tempo < 10)
                    SetTimerLabel("" + GameConfig.Tempo, true);
                else
                    SetTimerLabel("" + GameConfig.Tempo, false);
            }
            if (GameConfig.Tempo != 0) GameConfig.Tempo--;
            else SetTimerLabel("Acabou!");
        }

        private void onTimerTick(object sender, ElapsedEventArgs e)
        {
            Random random = new Random();
            if(casaAnterior!=9) SetImageResource(IMG_TYPE_TUNEL_VAZIO, casaAnterior);
            int casa = random.Next(0, 2);
            switch (casa)
            {
                case 0:
                    SetImageResource(IMG_TYPE_CROCODILO_LEGAL, random.Next(0, 4));
                    break;
                case 1:
                    SetImageResource(IMG_TYPE_CROCODILO_MALVADO, random.Next(0, 4));
                    break;
            }
        }

        private bool RealizarConfiguracoesInicias()
        {
            Button1.Content = "A";
            Button2.Content = "S";
            Button3.Content = "D";
            Button4.Content = "K";
            Button5.Content = "L";
            SetAllImage(IMG_TYPE_TUNEL_VAZIO);
            return true;
        }

        private void SetAllImage(string type)
        {
            for(int i = 0; i <= 4; i++)
            {
                SetImageResource(type, i);
            }
        }

        private bool SetImageResource(string type, int casa)
        {
            SetMensagemLabel("Aguardando batida...");
            Thread.Sleep(100);
            this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)(() =>
            {
                casaAnterior = casa;
                Uri uri;
                if (type.Equals(IMG_TYPE_CROCODILO_LEGAL))
                {
                    uri = new Uri(IMG_TYPE_CROCODILO_LEGAL);
                    Resultado.PodeApertar = false;
                }
                else if (type.Equals(IMG_TYPE_CROCODILO_MALVADO))
                {
                    uri = new Uri(IMG_TYPE_CROCODILO_MALVADO);
                    Resultado.PodeApertar = true;
                }
                else
                {
                    uri = new Uri(IMG_TYPE_TUNEL_VAZIO);
                }

                BitmapImage bitmap = new BitmapImage(uri);

                switch (casa)
                {
                    case 0:
                        Image1.Source = bitmap;
                        Resultado.Key = Key.A;
                        break;
                    case 1:
                        Image2.Source = bitmap;
                        Resultado.Key = Key.S;
                        break;
                    case 2:
                        Image3.Source = bitmap;
                        Resultado.Key = Key.D;
                        break;
                    case 3:
                        Image4.Source = bitmap;
                        Resultado.Key = Key.K;
                        break;
                    case 4:
                        Image5.Source = bitmap;
                        Resultado.Key = Key.L;
                        break;
                    default:
                        break;
                }
            }));
            return true;
        }

        private void SetMensagemLabel(string text, bool error = false)
        {
            TxtMensagem.Dispatcher.Invoke(new Action(() => TxtMensagem.Content = text));
            if(error)
                TxtMensagem.Dispatcher.Invoke(new Action(() => TxtMensagem.Foreground = System.Windows.Media.Brushes.Red));
            else
                TxtMensagem.Dispatcher.Invoke(new Action(() => TxtMensagem.Foreground = System.Windows.Media.Brushes.Black));
        }

        private void SetTimerLabel(string text, bool aviso = false)
        {
            TxtTimer.Dispatcher.Invoke(new Action(() => TxtTimer.Content = text));
            if (aviso)
                TxtTimer.Dispatcher.Invoke(new Action(() => TxtTimer.Foreground = System.Windows.Media.Brushes.Red));
            else
                TxtTimer.Dispatcher.Invoke(new Action(() => TxtTimer.Foreground = System.Windows.Media.Brushes.Black));
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarTeclaCorreta(e.Key);
        }

        private void VerificarTeclaCorreta(Key key)
        {
            if(Resultado.Key == key && Resultado.PodeApertar)
            {
                SetMensagemLabel("Boa garoto!!!");
                partida.Acertos++;
            }
            else
            {
                SetMensagemLabel("Errou e perdeu ponto!", true);
                partida.Erros++;
            }
            TxtPontos.Content = "Pontos: " + PartidaController.GetPartidaScore(partida);
            Resultado.PodeApertar = false;
        }

        public static class Resultado
        {
            public static Key Key { get; set; }
            public static bool PodeApertar { get; set; }
        }

    }


}
