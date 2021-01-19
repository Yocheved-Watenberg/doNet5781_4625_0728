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
            if (int.TryParse(tbCode.Text, out int theCode))
            {
                newStation.Code = theCode;
            }
            else
            {
                throw new BadFormatException("You have to put only numbers for the code!");
            }
            //verifier que le code n'existe pas deja 

            newStation.Name = tbName.Text;
            newStation.Adress = tbAdress.Text;

            if (double.TryParse(tbLongitude.Text, out double theLongitude))
            {
                newStation.Longitude = theLongitude;
            }
            else
            {
                throw new BadFormatException("You have to put a valid num for the longitude!");
            }


            if (double.TryParse(tbLatitude.Text, out double theLatitude))
            {
                newStation.Latitude = theLatitude;
            }
            else
            {
                throw new BadFormatException("You have to put a valid num for the latitude!");
            }

            bl.AddStation(newStation);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
