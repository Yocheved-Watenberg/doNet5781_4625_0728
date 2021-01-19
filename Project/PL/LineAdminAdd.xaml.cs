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
                throw new LessThanTwoStationsException("You have to select more stations");
            }
            BL.BO.Line newline = new BL.BO.Line();
            newline.Area = (BL.BO.Enum.Areas)cbAreas.SelectedItem;   //cbAreas.SelectedItem as BL.BO.Enum.Areas;
            bool isNum = int.TryParse(tbCode.Text, out int theNum);
            if (isNum)
            {
                //  newline.Code = int.Parse(tbCode.Text);
                newline.Code = theNum; 
            }
            else
            {
                throw new BadCodeException("You have to put only numbers for the code!");
            }
            newline.Id = Static.GetCounterDO();
            newline.ListOfStations = (IEnumerable<LineStation>)lbListOfStations.SelectedItems;
            bl.AddLine(newline);
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
