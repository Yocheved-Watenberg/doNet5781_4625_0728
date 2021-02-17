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
using BL.BO;
using BLAPI;


//attention on est pas obligé de fr throw exeption, on peut faire juste un try, a linterieur du try on met le truc qui va pas forcement marcher (genre parse) et ensuite catch msgboxshow"error"
namespace PL
{
    /// <summary>
    /// Logique d'interaction pour LineAdminAdd.xaml
    /// </summary>
    public partial class LineAdminAdd : Window
    {
        IBL bl;
        public LineAdminAdd(IBL _bl)
        {
           InitializeComponent();
            bl = _bl;
            cbAreas.ItemsSource = System.Enum.GetValues(typeof(BL.BO.Enum.Areas));
            //this.btnCreate.MouseEnter += btnCreate_MouseEnter;
            //this.btnCreate.MouseLeave += btnCreate_MouseLeave;

        }
//POUR AGRANDIR LE BOUTON QUAND ON SAPPROCHE 
        //private void btnCreate_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    Button b = sender as Button;
        //    if (b != null)
        //    {
        //        b.Height += b.Height;
        //        b.Width += b.Width;
        //    }
        //}
        //private void btnCreate_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    Button b = sender as Button;
        //    if (b != null)
        //    {
        //        b.Height = b.Height / 2;
        //        b.Width = b.Width / 2;
        //    }
        //}


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
          
            int s = lbListOfStations.SelectedItems.Count;  //s=number of stations that user selected for his line 
            try
            {
                if (s < 2)                                 //if there is less than two stations=> error 
                {
                    LessThanTwoStationsException lt2se = new LessThanTwoStationsException("You have to select more stations");
                    throw lt2se;
                }
            }
            catch (LessThanTwoStationsException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            bool isNum = int.TryParse(tbCode.Text, out int theNum);         //checks if the code is composed only of digits 
            try
            {
                if (!isNum)
                {
                    throw new BadCodeException("You have to put only numbers for the code!");       //else =>error 
                }
            }
            catch (BadCodeException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }


            IEnumerable<LineStation> newList = from Station eachLs in lbListOfStations.SelectedItems  //put the selected Line Stations into the list of stations of the line
                                               let ls = new LineStation
                                               {
                                                   LineId = theNum,
                                                   StationCode = eachLs.Code,
            //DistanceFromLastStation=,
            //TimeFromLastStation =,
            StationName = eachLs.Name,
                                                       }
                                                    select ls;
          //  MessageBox.Show("newlist.firststation" + newList.First());//a degager c pr verifier qqch 

            bl.AddLine(theNum, (BL.BO.Enum.Areas)cbAreas.SelectedItem, newList);  //create the line 
            MessageBox.Show("The line has been added succesfully!");
           // MessageBox.Show(bl.GetLine(theNum).ToString());

        }

        private void btnSelectStations_Click(object sender, RoutedEventArgs e)
        {
            lbListOfStations.DataContext = bl.GetStationByArea((BL.BO.Enum.Areas)cbAreas.SelectedItem);
        }

        //private void cbLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    curLine = cbLines.SelectedItem as BL.BO.Line;
        //    tbArea.DataContext = curLine;

        //    if (curLine != null)
        //    {
        //        RefreshAllLinesGrid();
        //    }
        //}

        //    private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //    {

        //        curArea = cbAreas.SelectedItem as BL.BO.Enum.Areas;
        //        tbArea.DataContext = curLine;

        //        if (curLine != null)
        //        {
        //            RefreshAllLinesGrid();
        //        }
        //    }
    }
}
