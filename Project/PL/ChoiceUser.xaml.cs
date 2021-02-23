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
    /// Logique d'interaction pour ChoiceUser.xaml
    /// </summary>
    public partial class ChoiceUser : Window
    {
        IBL bl;
        public ChoiceUser(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            cbStationChoice.DataContext = bl.GetAllStation(); 
        }

        private void buttonGo_Click(object sender, RoutedEventArgs e)
        {
            if (cbStationChoice.SelectedItem == null)
                cbStationChoice.SelectedItem = bl.GetAllStation().First();
            if (tbSimulationSpeed.Text == null)
                tbSimulationSpeed.Text = "50";      
            ChoiceOfUser win = new ChoiceOfUser(bl, bl.GetStation((cbStationChoice.SelectedItem as Station).Code), int.Parse(tbSimulationSpeed.Text)) ;
            win.ShowDialog();
        }
    }
}
