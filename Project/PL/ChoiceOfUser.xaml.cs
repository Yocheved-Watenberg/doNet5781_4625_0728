using BL.BO;
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
    /// Logique d'interaction pour ChoiceOfUser.xaml
    /// </summary>
    public partial class ChoiceOfUser : Window
    {
        IBL bl = BLFactory.GetBL("1");
        static PL pl = new PL();
        private Stopwatch stopWatch;
        BackgroundWorker timerworker;

        Station station;
        IEnumerable<IGrouping<TimeSpan, LineTiming>> listTest;
        TimeSpan startHour;

    
        public ChoiceOfUser(IBL _bl)
        {
            InitializeComponent();  
            bl = _bl;
            stopWatch = new Stopwatch(); 
            timerworker = new BackgroundWorker();
            timerworker.DoWork += Worker_DoWork;
            timerworker.ProgressChanged += Worker_ProgressChanged;
            timerworker.RunWorkerCompleted += Timing_RunWorkerCompleted;
            timerworker.WorkerReportsProgress = true;
            timerworker.WorkerSupportsCancellation = true;
            stopWatch.Restart();
            timerworker.RunWorkerAsync(station); //copié de tirtsa 

        }

        private void Timing_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string timerText = stopWatch.Elapsed.ToString();  //tirtsa : string timerText = (startHour + TimeSpan.FromTicks(stopwatch.Elapsed.Ticks * 60)).ToString();
            timerText = timerText.Substring(0, 8);
            this.timerTextBlock.Text = timerText;
            LineTripDataGrid.ItemsSource = listTest;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)//revoir, g recopie de tirtsa 
        {
            station = e.Argument as Station;
            try
            {
                startHour = DateTime.Now.TimeOfDay;
                while (timerworker.CancellationPending == false)
                {
                    TimeSpan simulatedHourNow = startHour + TimeSpan.FromTicks(stopWatch.Elapsed.Ticks * 60);
                    listTest = pl.BoPoLineTimingAdapter(bl.StationTiming(station, simulatedHourNow), simulatedHourNow);
                    timerworker.ReportProgress(1);
                    Thread.Sleep(1);
                }
                e.Result = 1;
            }
            catch (BadLineTripException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // bool isTimerRun = false; 
        //private void startTimerButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (!isTimerRun)
        //    {
        //        stopWatch.Restart();
        //        isTimerRun = true;
        //        timerworker.RunWorkerAsync();
        //    }
        //}
        //private void stopTimerButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (isTimerRun)
        //    {
        //        stopWatch.Stop();
        //        isTimerRun = false;
        //    }
        //}
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            timerworker.CancelAsync();
            this.Close();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            timerworker.CancelAsync();
        }
       

        //bool isNum = int.TryParse(tbSimulationSpeed.Text, out int theNum);         //checks if the meirout simulation is composed only of digits 
        //if (!isNum) throw new BadCodeException("You have to put a valid num");      
    }

}

