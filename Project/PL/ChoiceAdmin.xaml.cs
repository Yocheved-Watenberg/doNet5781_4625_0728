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

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour ChoiceAdmin.xaml
    /// </summary>
    public partial class ChoiceAdmin : Window
    {
        IBL bl = BLFactory.GetBL("1");

        public ChoiceAdmin(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
        }

        private void btnStation_Click(object sender, RoutedEventArgs e)
        {
            StationAdmin win = new StationAdmin(bl);
            win.Show();
        }

        private void btnLine_Click(object sender, RoutedEventArgs e)
        {
            LineAdmin win = new LineAdmin(bl);
            win.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
