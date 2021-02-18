using BLAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour ChoiceUser.xaml
    /// </summary>
    public partial class ChoiceUser : Window
    {
        IBL bl = BLFactory.GetBL("1");
        private Stopwatch stopWatch;
        private bool isTimerRun;
        BackgroundWorker timerworker;

        public ChoiceUser(IBL _bl)
        {
            bl = _bl;
            InitializeComponent();

            stopWatch = new Stopwatch();
            timerworker = new BackgroundWorker();
            timerworker.DoWork += Worker_DoWork;
            timerworker.ProgressChanged += Worker_ProgressChanged;
            timerworker.WorkerReportsProgress = true;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string timerText = stopWatch.Elapsed.ToString();
            timerText = timerText.Substring(0, 8);
            this.timerTextBlock.Text = timerText;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (isTimerRun)
            {
                timerworker.ReportProgress(55);
                Thread.Sleep(1000);
            }
        }
        private void startTimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isTimerRun)
            {
                stopWatch.Restart();
                isTimerRun = true;
                timerworker.RunWorkerAsync();
            }
        }
        private void stopTimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (isTimerRun)
            {
                stopWatch.Stop();
                isTimerRun = false;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        //bool isNum = int.TryParse(tbSimulationSpeed.Text, out int theNum);         //checks if the meirout simulation is composed only of digits 
        //if (!isNum) throw new BadCodeException("You have to put a valid num");      
    }

}

