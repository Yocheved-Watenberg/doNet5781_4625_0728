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
            //this.btnLine.MouseEnter += btnLine_MouseEnter;
            //this.btnStation.MouseEnter += btnStation_MouseEnter; 
            //this.btnLine.MouseLeave += btnLine_MouseLeave;
            //this.btnStation.MouseLeave += btnStation_MouseLeave; 
        }

        //private void btnStation_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    Button b = sender as Button;
        //    if (b != null)
        //    {
        //        b.Height += b.Height;
        //        b.Width += b.Width;
        //    }
        //}

        //private void btnLine_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    Button b = sender as Button;
        //    if (b != null)
        //    {
        //        b.Height += b.Height;
        //        b.Width += b.Width;
        //    }
        //}

        //private void btnStation_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    Button b = sender as Button;
        //    if (b != null)
        //    {
        //        b.Height = b.Height / 2;
        //        b.Width = b.Width / 2;
        //    }
        //}

        //private void btnLine_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    Button b = sender as Button;
        //    if (b != null)
        //    {
        //        b.Height = b.Height / 2;
        //        b.Width = b.Width / 2;
        //    }
        //}


        private void btnStation_Click(object sender, RoutedEventArgs e)
        {
            StationAdmin win = new StationAdmin(bl);
            win.ShowDialog();
        }

        private void btnLine_Click(object sender, RoutedEventArgs e)
        {
            LineAdmin win = new LineAdmin(bl);
            win.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }


    }
}
