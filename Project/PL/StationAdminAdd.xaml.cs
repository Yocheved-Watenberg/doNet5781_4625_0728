using BL.BO;
using BLAPI;
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

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour StationAdminAdd.xaml
    /// </summary>
    public partial class StationAdminAdd : Window
    {
        IBL bl;
        public StationAdminAdd(IBL _bl)
        {
            InitializeComponent();
            bl = _bl; 
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Station newStation = new Station();
            try            
            {
                newStation.Code = int.Parse(tbCode.Text);             //verifier que le code n'existe pas deja      ATTENTIONNNNNN  
                newStation.Name = tbName.Text;
                newStation.Adress = tbAdress.Text;
                newStation.Longitude = double.Parse(tbLongitude.Text);
                newStation.Latitude = double.Parse(tbLatitude.Text);
            }
            catch
            {
                MessageBox.Show("You have to put valid fields!");
            }
            bl.AddStation(newStation);
            MessageBox.Show("The station has been added successfully");
            this.Close(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void userPressBack(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                this.Close();
            }
        }
    }
}
