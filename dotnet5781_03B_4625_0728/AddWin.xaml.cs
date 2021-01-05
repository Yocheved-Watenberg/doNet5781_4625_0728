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


namespace dotNet5781_03b_4625_0728
{
    /// <summary>
    /// Logique d'interaction pour AddWin.xaml
    /// </summary>
    public partial class AddWin : Window
    {
        public AddWin()
        {
            InitializeComponent();
            
        }


        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ////DateTime dt = calendar.SelectedDate();
            //string Var1 = textBox.Text;

            //MessageBox.Show(dt.ToShortDateString());

            //MessageBox.Show(dt.ToShortDateString());
            var newBus = new Bus(int.Parse(textBox.Text), (DateTime)date.SelectedDate, DateTime.Now, 1200, 20000, 20000);
            buses.Add(newBus);
            //recuperer la date
            //le input de textbox avec .Text
            //faire tes verifications si erreur envoyer un messagebox
            //sinon, creer un bus et l ajouter a la liste en envoyant une odaa au user
        }
    }
}

