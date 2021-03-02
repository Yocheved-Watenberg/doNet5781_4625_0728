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
    /// Logique d'interaction pour LineAdmin.xaml
    /// </summary>
    public partial class LineAdmin : Window
    {
        IBL bl;
        BL.BO.Line curLine;
        public LineAdmin(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            RefreshAllLineComboBox();
        }

        void RefreshAllLineComboBox()
        {
            cbLines.DataContext = bl.GetAllLine();
        }

        void RefreshAllLinesGrid()
        {
            lbLineStations.DataContext = bl.GetAllLineStationsInLine(curLine);
        }

        private void cbLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            curLine = (BL.BO.Line)cbLines.SelectedItem;
            tbArea.DataContext = curLine;

            if (curLine != null)
            {
                RefreshAllLinesGrid();
            }
        }

        private void butAdd_Click(object sender, RoutedEventArgs e)
        {
            LineAdminAdd win = new LineAdminAdd(bl);
            win.ShowDialog();
            RefreshAllLineComboBox();
        }
        private void butUpdate_Click(object sender, RoutedEventArgs e)
        {
            LineAdminUpdate win = new LineAdminUpdate(bl);
            win.Show();
        }
        private void butDelete_Click(object sender, RoutedEventArgs e)
        {
            curLine = (BL.BO.Line)cbLines.SelectedItem;
            if (curLine == null)
                MessageBox.Show("You have to select the line that you want to delete");
            else
            {
                MessageBoxResult res = MessageBox.Show("Are you sure to delete this line?", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.No)
                    return;
                bl.DeleteLine(curLine.Code);
                MessageBox.Show($"The line {curLine.Code} is deleted!");
                RefreshAllLineComboBox();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void userPressBack(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                this.Close();
            }
        }
    }

}