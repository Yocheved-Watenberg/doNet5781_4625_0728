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
       // static PLClass pl = new PLClass(); 
        private Stopwatch stopWatch;
        BackgroundWorker timerworker;
       
        Station station;
        IEnumerable<IGrouping<TimeSpan, LineTiming>> nextBusesInStation;
        TimeSpan startHour;
        int simulatedSpeed; 

        public ChoiceOfUser(IBL _bl, Station _station, int _simulatedSpeed)
        {
            InitializeComponent();  
            bl = _bl;
            station = _station;
            simulatedSpeed = _simulatedSpeed;
            stopWatch = new Stopwatch(); 
            timerworker = new BackgroundWorker();
            timerworker.DoWork += Worker_DoWork;
            timerworker.ProgressChanged += Worker_ProgressChanged;
            timerworker.RunWorkerCompleted += Timing_RunWorkerCompleted;
            timerworker.WorkerReportsProgress = true;
            timerworker.WorkerSupportsCancellation = true;
            stopWatch.Restart();
            timerworker.RunWorkerAsync();
         
        }

        private void Timing_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        public void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string timerText = (startHour + TimeSpan.FromTicks(stopWatch.Elapsed.Ticks * simulatedSpeed)).ToString();
            timerTextBlock.Text = timerText.Substring(0, 8);
            LineTripDataGrid.ItemsSource = nextBusesInStation;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)//revoir, g recopie de tirtsa 
        {
          // station = e.Argument as Station;
          // station = bl.GetStation((int)cbStationChoice.SelectedItem);
           station = bl.GetAllStation().First();
            try
            {
                startHour = DateTime.Now.TimeOfDay;
                while (timerworker.CancellationPending == false)
                {
                    TimeSpan simulatedHourNow = startHour + TimeSpan.FromTicks(stopWatch.Elapsed.Ticks * simulatedSpeed);
                    nextBusesInStation = bl.StationTiming(station, simulatedHourNow);   
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

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            timerworker.CancelAsync();
        }

        private void cbStationChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            station = cbStationChoice.SelectedItem as BL.BO.Station;
            timerworker.CancelAsync();
            timerworker.RunWorkerAsync();
        }
        //bool isNum = int.TryParse(tbSimulationSpeed.Text, out int theNum);         //checks if the meirout simulation is composed only of digits 
        //if (!isNum) throw new BadCodeException("You have to put a valid num");        
    
    }

}

