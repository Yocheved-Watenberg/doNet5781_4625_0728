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
using DLAPI.DO;



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
            lbListOfStations.DataContext = bl.GetAllStation();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            int s = lbListOfStations.SelectedItems.Count;
            if  (s< 2)
            {
                throw new LessThanTwoStationsException("you have to select more stations");
            }
            BL.BO.Line newline = new BL.BO.Line();
            newline.Area = (BL.BO.Enum.Areas)cbAreas.SelectedItem;   //cbAreas.SelectedItem as BL.BO.Enum.Areas;
            newline.Code = ;
            newline.Id = Static.LineIdCounterBO++;
            newline.ListOfStations = lbListOfStations.SelectedItems;
            bl.AddLine(newline);
           // MessageBox.Show("This method is under construction!", "TBD", MessageBoxButton.OK, MessageBoxImage.Asterisk);
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
