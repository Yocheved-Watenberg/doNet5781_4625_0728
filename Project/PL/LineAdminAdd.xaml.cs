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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            int s = lbListOfStations.SelectedItems.Count;
            try
            {
                if (s < 2)
                {
                    LessThanTwoStationsException lt2se = new LessThanTwoStationsException("You have to select more stations");
                    throw lt2se;
                }
            }
            catch (LessThanTwoStationsException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }            
            BL.BO.Line newline = new BL.BO.Line();
            newline.Area = (BL.BO.Enum.Areas)cbAreas.SelectedItem;   //cbAreas.Selec tedItem as BL.BO.Enum.Areas;
            bool isNum = int.TryParse(tbCode.Text, out int theNum);
            if (isNum)
            {
               
                try
                {
                    //  newline.Code = int.Parse(tbCode.Text);
                    if (bl.GetLine(theNum) == null)            //there is no such line 
                    {
                        newline.Code = theNum;
                    }
                    
                }
                catch 
                {
                    throw new ExistingLineCodeException("This code is already used for an existing line");
                }
              
            }
            else
            {
                throw new BadCodeException("You have to put only numbers for the code!");
            }
            newline.Id = Static.GetLineIdCounterDO();
            //creer d abord les lines stations et les mettre ds le sade listOfStations
            // for(int i=0; i< (lbListOfStations.SelectedItems).Count; i++)
            //IEnumerable<Line> lineInStation = from ls in dl.GetAllLineStationBy(ls => ls.StationCode == s.Code)
            //                                      //searches all the LineStations which have the same code than the station sent 
            //                                  let line = dl.GetLine(ls.LineId)
            //                                  //creates a line from the Id of the LineStation
            //                                  select LineDoBoAdapter(line);
            //return lineInStation;
            
            
            
            
            //IEnumerable<LineStation> newLineStation;
            //from allLs in lbListOfStations.SelectedItems
            //let ls = new LineStation
            //{
            //    LineId =allLs.LineId,
            //    StationCode = allLs.StationCode,
            //    //DistanceFromLastStation=       ,
            //    //TimeFromLastStation =          ,
            //    StationName = allLs.StationName, 
            //    //PrevStation = ,
            //    //NextStation = ,
            //}
            //     select 

            
            ////  newline.ListOfStations = lbListOfStations.SelectedItems;
            
            bl.AddLine(newline);
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
