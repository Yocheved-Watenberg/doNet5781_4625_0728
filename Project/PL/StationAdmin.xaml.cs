﻿using System;
using System.Collections.Generic;
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
using System.Linq;


namespace PL
{
    /// <summary>
    /// Logique d'interaction pour StationAdmin.xaml
    /// </summary>
    public partial class StationAdmin : Window
    {
        static IBL bl;
        BL.BO.Station curStation;
        public StationAdmin(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;

            cbStationCode.DisplayMemberPath = "Name";//show only specific Property of object
            cbStationCode.SelectedValuePath = "Code";//selection return only specific Property of object
            cbStationCode.SelectedIndex = 0; //index of the object to be selected
            RefreshAllStationComboBox();

            curStation = cbStationCode.SelectedItem as BL.BO.Station;
        }

        void RefreshAllStationComboBox()
        {
            cbStationCode.DataContext = bl.GetAllStation();
        }

        private void cbStationCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            curStation = cbStationCode.SelectedItem as BL.BO.Station;
            gridOneStation.DataContext = curStation;

            if (curStation != null)
            {
                lbLineStations.DataContext = bl.GetAllLineInStation(curStation);
            }
        }
   
        private void btDeleteStation_Click(object sender, RoutedEventArgs e)
        {
            curStation = cbStationCode.SelectedItem as BL.BO.Station;
            if (curStation == null)
                MessageBox.Show("You have to select the station that you want to delete");
            else
            {
                MessageBoxResult res = MessageBox.Show("Are you sure to delete this station?", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.No)
                    return;
                bl.DeleteStation(curStation.Code);
                MessageBox.Show($"The station {curStation.Code} is deleted!");
                RefreshAllStationComboBox();
            }       
        }
        private void btAddStation_Click(object sender, RoutedEventArgs e)
        {
            StationAdminAdd win = new StationAdminAdd(bl);
            win.ShowDialog();
            RefreshAllStationComboBox();
        }
        private void btUpdateStation_Click(object sender, RoutedEventArgs e)
        {     
            try
            {
                if (curStation != null)
                    bl.UpdateStation(curStation);
                MessageBox.Show("The station has been changed!");
                RefreshAllStationComboBox();

            }
            catch (BL.BO.BadStationIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
