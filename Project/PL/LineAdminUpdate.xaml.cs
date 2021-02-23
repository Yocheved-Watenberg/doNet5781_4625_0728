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
using BL.BO;
using BL;

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour LineAdminUpdate.xaml
    /// </summary>
    public partial class LineAdminUpdate : Window
    {
        IBL bl;
        BL.BO.Line curLine;
        BL.BO.Line selectedLine;
        public LineAdminUpdate(IBL _bl)
        {
            bl = _bl;
            InitializeComponent();
            cbLines.DisplayMemberPath = "Code";//show only specific Property of object                  // verifier si fo pas enlever car dit deux fois (ds cs et xml) 
            cbLines.SelectedValuePath = "Id";//selection return only specific Property of object
            cbLines.SelectedIndex = 0; //index of the object to be selected
            RefreshAllLineComboBox();
        }

        void RefreshAllLineComboBox()
        {
            cbLines.DataContext = bl.GetAllLine();
        }

        //void RefreshAllLinesGrid()
        //{
        //    lbLineStations.DataContext = bl.GetAllLineStationsInLine(curLine);
        //}

        //private void cbLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    curLine = cbLines.SelectedItem as BL.BO.Line;
        //    tbArea.DataContext = curLine;

        //    if (curLine != null)
        //    {
        //        RefreshAllLinesGrid();
        //    }
        //}



        private void cbLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void cbAreas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void lbListOfStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btnAddStations_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                 selectedLine = cbLines.SelectedItem as BL.BO.Line;
                    List<Station> myList = new List<Station>();
                   //liste de ttes les stations qui sont dans line et dans la area de la line
              
                if (selectedLine != null)
                {
                    myList = (bl.GetStationByArea((BL.BO.Enum.Areas)(selectedLine).Area)).ToList();
                    //myList2 = myList;
                    List<Station> myList2 = (bl.GetStationByArea((BL.BO.Enum.Areas)(selectedLine).Area)).ToList();

                    foreach (Station item in myList)
                        foreach (Station st in bl.GetAllStationInLine(selectedLine))
                            if (item.Code == st.Code)
                                myList2.Remove(bl.GetStation(item.Code));
                       // ((bl.GetAllStationInLine(selectedLine)).ToList()).Find(s => s.Code == item.Code);
                       // myList2.Remove(
                                lbListOfAddStations.DataContext = myList2;
                }
                   else throw new NotSelectedLineException("You have not selected a line!"); 
            }
            catch (NotSelectedLineException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }

        }
       

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            selectedLine = cbLines.SelectedItem as BL.BO.Line;
            if (lbListOfAddStations.SelectedItem != null)
            {
                List<LineStation> lineStationsInMyLine = bl.GetLine(selectedLine.Code).ListOfStations.ToList(); // All the stations in the line before modifications
               // First create the new adjacents stations(ie the last station of the stations already existing in my line and the first new selected station)
                AdjacentStations newAdj = new AdjacentStations();
                newAdj.Station1 = lineStationsInMyLine.Last().StationCode;
                newAdj.Station2 = (lbListOfAddStations.SelectedItems[0] as LineStation).StationCode;
                newAdj.Time = new TimeSpan(10);

               // bl.AddAdjacentsStations(newAdj);
                for (int i = 0; i < lbListOfAddStations.SelectedItems.Count; i++)  //put the selected Line Stations into the list of stations of the line
                    new AdjacentStations
                    {
                        Station1 = (lbListOfAddStations.SelectedItems[i] as LineStation).StationCode,
                        Station2 = (lbListOfAddStations.SelectedItems[i + 1] as LineStation).StationCode,
                        Time = new TimeSpan(10),
                    };
               // bl.AddAdjacentsStations();


                List <LineStation> newList = (from Station eachLs in lbListOfAddStations.SelectedItems  //put the selected Line Stations into the list of stations of the line
                                             select new LineStation
                                             {
                                                 LineCode = selectedLine.Code,
                                                 StationCode = eachLs.Code,
                                                 //DistanceFromLastStation=,
                                                 //TimeFromLastStation =,
                                                 StationName = eachLs.Name,
                                             }).ToList();
                 foreach (LineStation  item in newList)             // add all the new linestation to the line
                    lineStationsInMyLine.Add(item);
               
                
                
                
               

            }
        }

        private void btnDeleteStations_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                 selectedLine = cbLines.SelectedItem as BL.BO.Line;
                List<Station> myList = new List<Station>();
                
                if (selectedLine != null)
                {
                    myList = bl.GetAllStationInLine(selectedLine).ToList();

                    lbListOfDeleteStations.DataContext = myList;
                }
                else throw new NotSelectedLineException("You have not selected a line!");
            }
            catch (NotSelectedLineException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }

        }
    }
}

