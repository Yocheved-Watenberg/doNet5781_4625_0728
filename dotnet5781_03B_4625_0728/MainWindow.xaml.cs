using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace dotNet5781_03b_4625_0728
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {public ObservableCollection<Bus> buses { get; set; } = new ObservableCollection<Bus>();
        public MainWindow()
        {
            InitializeComponent();

          Bus bus01 = new Bus();
            Bus bus02 = new Bus();
            Bus bus03 = new Bus();
            Bus bus04 = new Bus();
            Bus bus05 = new Bus();
            Bus bus06 = new Bus();
            Bus bus07 = new Bus();
            Bus bus08 = new Bus();
            Bus bus09 = new Bus();
            Bus bus10 = new Bus();
            buses.Add(bus01);
            buses.Add(bus02);
            buses.Add(bus03);
            buses.Add(bus04);
            buses.Add(bus05);
            buses.Add(bus06);
            buses.Add(bus07);
            buses.Add(bus08);
            buses.Add(bus09);
            buses.Add(bus10);
            Random rand = new Random(DateTime.Now.Millisecond);
            foreach (Bus item in buses)
            {
                item.BusNumber = rand.Next(1000000, 99999999);
                item.Gasoline = rand.Next(0, 1200);
                item.Mileage = rand.Next(0, 20000);
                item.TotalMileage = rand.Next() + item.Mileage;
                item.BusState = 0;
                int myYear, myMonth, myDay = 1;
                myMonth = rand.Next(1, 12);
                if (item.BusNumber < 10000000)
                    myYear = rand.Next(2000, 2017);
                else
                    myYear = rand.Next(2018, 2021);
                if (myMonth == 2)
                    myDay = rand.Next(1, 28);
                if (myMonth == 1 || myMonth == 3 || myMonth == 5 || myMonth == 7 || myMonth == 8 || myMonth == 10 || myMonth == 12)
                    myDay = rand.Next(1, 31);
                if (myMonth == 4 || myMonth == 6 || myMonth == 9 || myMonth == 11)
                    myDay = rand.Next(1, 30);
                item.FirstActivity = new DateTime(myYear, myMonth, myDay);

                DateTime myLastOverhaulDate = new DateTime(rand.Next(2000, 2020), rand.Next(1, 12), rand.Next(1, 28));
                while (myLastOverhaulDate < item.FirstActivity || myLastOverhaulDate > DateTime.Now)
                    myLastOverhaulDate = new DateTime(rand.Next(2000, 2020), rand.Next(1, 12), rand.Next(1, 28));
                item.LastOverhaul = myLastOverhaulDate;
            }

            bus01.BusNumber = 1234567;
            bus01.FirstActivity = new DateTime(2017, 01, 01);
            bus01.LastOverhaul = new DateTime(2018, 01, 01);

            bus02.Mileage = 19999;

            bus03.Gasoline = 1;

            //for (int i = 0; i < 10; ++i)
            //{
            //    listboxitem newitem = new listboxitem();
            //    newitem.content = "bus" + busnumber;
            //    listbox.items.add(newitem);
            //}
            //  listBox.DataContext = buses;
            //foreach (Bus item in buses)
            //    listBox.Items.Add(item);

            listBox.ItemsSource = buses;
            listBox.DataContext = buses;
            listBox.SelectedIndex = 0;

        }
        //private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    foreach (var SelectedItem in listBox.SelectedItems) { }
        //}

        private void ShowBusLine(object p)
        {
            throw new NotImplementedException();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//noa
            AddWin addWin = new AddWin();
            addWin.ShowDialog(); //la fenetre s occupe de gerer les inputr du user
            addWin.Close();

            //MessageBox.Show("Which line do you want to add?");
            //    string myBusNumber = Console.ReadLine();

            //Bus newBus = new Bus(myBusNumber, DateTime.Now, DateTime.Now, 1200, 0, 0);
            //buses.Add(newBus);
        }

        private void listBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            foreach (var SelectedItem in listBox.SelectedItems) { }
        }
    }
}
         