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
using BLAPI;

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour StationAdmin.xaml
    /// </summary>
    public partial class StationAdmin : Window
    {
        //we don't allow to upadate the station code, because it's the id 
        IBL bl;
        BL.BO.Station curStation;
        public StationAdmin(IBL _bl)
        {
            bl = _bl;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource stationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("stationViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // stationViewSource.Source = [source de données générique]
        }

        private void stationDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException(); 
        }

        private void stationCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();

        }

        private void cbStationCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();

        }

        private void lbLineStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();

        }

        private void AdressTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();

        }

        private void btDeleteStation_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();


        }

        private void btAddStation_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();

        }

        private void btUpdateStation_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();

        }
    }
}
