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
        IBL bl;
        BL.BO.Line curLineToDelete;
        public LineAdminDelete(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            DataContext = bl.GetAllLine();
        }

        private void lbLineToDelete_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            curLineToDelete = lbLineToDelete.SelectedItem as BL.BO.Line;
            bl.DeleteLine(curLineToDelete.Code);   
        }
    }
}
