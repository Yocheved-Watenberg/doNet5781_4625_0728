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
        BL.BO.Line selectedLine;
        public LineAdminUpdate(IBL _bl)
        {
            bl = _bl;
            InitializeComponent();
            cbLines.DataContext = bl.GetAllLine();
        }

        private void cbLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedLine = cbLines.SelectedItem as BL.BO.Line;
            lbListOfDeleteStations.DataContext = bl.GetAllStationInLine(selectedLine);    //remplir grille des stations a deleter
            List<Station> stationsInArea = bl.GetStationByArea(selectedLine.Area).ToList() ; //put in stationsInArea all the stations of the area of the line selected
            foreach (Station item in bl.GetStationByArea(selectedLine.Area).ToList())
            {
                foreach (Station st in bl.GetAllStationInLine(selectedLine))
                    if (item.Code == st.Code)
                    {
                        
                        stationsInArea.Remove(stationsInArea.Find(s => s.Code == item.Code));
                        break;
                    }
            }
                     
                                     //myList2  contains all the stations of the area selected without the stations of the line selected
          lbListOfAddStations.DataContext = stationsInArea;                  //remplir la grille des stations a ajouter potentiellement 
        }

        private void btnAddStations_Click(object sender, RoutedEventArgs e)
        {
            if (lbListOfAddStations.SelectedItem != null)
            {
                Station stationToAdd = lbListOfAddStations.SelectedItem as Station;
                int index = int.Parse(tbIndex.Text);
                bl.AddLineStation(selectedLine.Code, stationToAdd.Code, index); //creates a new line station 
                LineStation newLineStation = bl.GetLineStation(selectedLine.Code, stationToAdd.Code);
                LineStation previous = selectedLine.ListOfStations.ToList()[index - 1];  //find the previous station
                bl.AddStationToLine(newLineStation, previous);
                LineAdmin win= new LineAdmin(bl);
                win.ShowDialog();

                //List<LineStation> lineStationsInMyLine = bl.GetLine(selectedLine.Code).ListOfStations.ToList(); // All the stations in the line before modifications
                //                                                                                                //First create the new adjacents stations(ie the last station of the stations already existing in my line and the first new selected station)
                //AdjacentStations newAdj = new AdjacentStations();
                //newAdj.Station1 = lineStationsInMyLine.Last().StationCode;
                //newAdj.Station2 = (lbListOfAddStations.SelectedItems[0] as LineStation).StationCode;
                //newAdj.Time = new TimeSpan(10);

                //bl.AddAdjacentStations(newAdj);
                //for (int i = 0; i < lbListOfAddStations.SelectedItems.Count; i++)  //put the selected Line Stations into the list of stations of the line
                //    new AdjacentStations
                //    {
                //        Station1 = (lbListOfAddStations.SelectedItems[i] as LineStation).StationCode,
                //        Station2 = (lbListOfAddStations.SelectedItems[i + 1] as LineStation).StationCode,
                //        Time = new TimeSpan(10),
                //    };
                //// bl.AddAdjacentsStations();


                //List<LineStation> newList = (from Station eachLs in lbListOfAddStations.SelectedItems  //put the selected Line Stations into the list of stations of the line
                //                             select new LineStation
                //                             {
                //                                 LineCode = selectedLine.Code,
                //                                 StationCode = eachLs.Code,
                //                                 //DistanceFromLastStation=,
                //                                 //TimeFromLastStation =,
                //                                 StationName = eachLs.Name,
                //                             }).ToList();
                //foreach (LineStation item in newList)             // add all the new linestation to the line
                //    lineStationsInMyLine.Add(item);
            }
            else
            {
                MessageBox.Show("You have to select a station to add", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnDeleteStations_Click(object sender, RoutedEventArgs e)
        {
            if (lbListOfDeleteStations.SelectedItem != null)
            {
                Station stationToDelete = lbListOfDeleteStations.SelectedItem as Station;
                bl.DeleteStationOfLine(stationToDelete.Code, selectedLine.Code);
            }
            else
            {
                MessageBox.Show("You have to select a station to delete", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

