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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLAPI;
//using BL;

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       IBL bl = BLFactory.GetBL("1");
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnGO_Click(object sender, RoutedEventArgs e)
        {
            if (rbAdmin.IsChecked == true)
            {
                ChoiceAdmin win = new ChoiceAdmin(bl);  
                win.ShowDialog();
            }
            else if (rbUser.IsChecked == true)
            {
                ChoiceOfUser win = new ChoiceOfUser(bl);
                win.ShowDialog();
            }
        }

    }
}







       
      
    
