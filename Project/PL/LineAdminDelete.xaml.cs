using BLAPI;
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

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour LineAdminDelete.xaml
    /// </summary>
     
    public partial class LineAdminDelete : Window
    {
        
        BL.BO.Line curLineToDelete;
        IBL bl;
        public LineAdminDelete(IBL _bl)
        {
            InitializeComponent();
            DataContext = bl.GetAllLine();
        }

        private void cbLinesToDelete_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //curLineToDelete = (BL.BO.Line)(cbLinesToDelete.SelectedItem );
            bl.DeleteLine(((BL.BO.Line)cbLinesToDelete.SelectedItem).Code);
        }
    }
}
