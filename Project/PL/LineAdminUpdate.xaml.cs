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
            MessageBox.Show("this method is under construction");
        }

        private void cbAreas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("this method is under construction");
        }

        private void lbListOfStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("this method is under construction");
        }

        private void btnSelectStations_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                    List<Station> myList = new List<Station>();
                    List < Station >myList2= new List<Station>();
                if (cbLines.SelectedItem != null)
                {
                    myList = (bl.GetStationByArea((BL.BO.Enum.Areas)(cbLines.SelectedItem as BL.BO.Line).Area)).ToList();
                    foreach (Station item in myList)
                        if (bl.GetLineStation((cbLines.SelectedItem as BL.BO.Line).Id, item.Code) == null)
                            myList2.Add(item);
                    lbListOfStations.DataContext = myList2;
                }
                   else throw new NotSelectedLineException("You have not selected a line!"); 
            }
            catch (NotSelectedLineException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
           
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

