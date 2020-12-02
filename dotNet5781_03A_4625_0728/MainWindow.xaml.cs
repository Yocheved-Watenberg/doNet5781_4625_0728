using dotNet5781_02_4625_0728;
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
using Line = dotNet5781_02_4625_0728.Line;

namespace dotNet5781_03A_4625_0728
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyList busLines;
        public MainWindow()
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            Station s1 = new Station(1, 1, 1);
            Station s2 = new Station(true);
            Station s3 = new Station(3, 3, 3);
            Station s4 = new Station(4, 4, 4);
            Station s5 = new Station(5, 5, 5);
            Station s6 = new Station(6, 6, 6);
            Station s7 = new Station(true);
            Station s8 = new Station(true);
            Station s9 = new Station(true);
            Station s10 = new Station(true);
            Station s11 = new Station(true);
            Station s12 = new Station(true);
            Station s13 = new Station(true);
            Station s14 = new Station(true);
            Station s15 = new Station(true);
            Station s16 = new Station(true);
            Station s17 = new Station(true);
            Station s18 = new Station(true);
            Station s19 = new Station(true);
            Station s20 = new Station(true);
            Station s21 = new Station(true);
            Station s22 = new Station(true);
            Station s23 = new Station(true);
            Station s24 = new Station(true);
            Station s25 = new Station(true);
            Station s26 = new Station(true);
            Station s27 = new Station(true);
            Station s28 = new Station(true);
            Station s29 = new Station(true);
            Station s30 = new Station(true);
            Station s31 = new Station(true);
            Station s32 = new Station(true);
            Station s33 = new Station(true);
            Station s34 = new Station(true);
            Station s35 = new Station(true);
            Station s36 = new Station(true);
            Station s37 = new Station(true);
            Station s38 = new Station(true);
            Station s39 = new Station(true);
            Station s40 = new Station(true);

            List<BusLineStation> list1 = new List<BusLineStation>() { new BusLineStation(s1, 0, 0), new BusLineStation(s2, true), new BusLineStation(s3, true), new BusLineStation(s4, true), new BusLineStation(s5, true) };
            List<BusLineStation> list2 = new List<BusLineStation>() { new BusLineStation(s1, 0, 0), new BusLineStation(s2, true), new BusLineStation(s3, true), new BusLineStation(s28, true), };
            List<BusLineStation> list3 = new List<BusLineStation>() { new BusLineStation(s11, 0, 0), new BusLineStation(s12, true), new BusLineStation(s13, true), new BusLineStation(s14, true), new BusLineStation(s15, true) };
            List<BusLineStation> list4 = new List<BusLineStation>() { new BusLineStation(s16, 0, 0), new BusLineStation(s17, true), new BusLineStation(s18, true), new BusLineStation(s19, true), new BusLineStation(s20, true) };
            List<BusLineStation> list5 = new List<BusLineStation>() { new BusLineStation(s21, 0, 0), new BusLineStation(s22, true), new BusLineStation(s23, true), new BusLineStation(s24, true), new BusLineStation(s25, true) };
            List<BusLineStation> list6 = new List<BusLineStation>() { new BusLineStation(s26, 0, 0), new BusLineStation(s27, true), new BusLineStation(s28, true), new BusLineStation(s29, true), new BusLineStation(s30, true), };
            List<BusLineStation> list7 = new List<BusLineStation>() { new BusLineStation(s31, 0, 0), new BusLineStation(s32, true), new BusLineStation(s33, true), new BusLineStation(s34, true), new BusLineStation(s35, true), };
            List<BusLineStation> list8 = new List<BusLineStation>() { new BusLineStation(s36, 0, 0), new BusLineStation(s37, true), new BusLineStation(s38, true), new BusLineStation(s39, true), new BusLineStation(s40, true), };
            List<BusLineStation> list9 = new List<BusLineStation>() { new BusLineStation(s6, 0, 0), new BusLineStation(s7, true), new BusLineStation(s8, true), new BusLineStation(s9, true), new BusLineStation(s10, true) };
            List<BusLineStation> list10 = new List<BusLineStation>() { new BusLineStation(s22, 0, 0), new BusLineStation(s1, true), new BusLineStation(s3, true), new BusLineStation(s38, true), };

            Line line1 = new Line(21, list1, rand.Next(0, 4));
            Line line2 = new Line(33, list2, rand.Next(0, 4));
            Line line3 = new Line(rand.Next(1, 1000), list3, rand.Next(0, 4));
            Line line4 = new Line(rand.Next(1, 1000), list4, rand.Next(0, 4));
            Line line5 = new Line(rand.Next(1, 1000), list5, rand.Next(0, 4));
            Line line6 = new Line(rand.Next(1, 1000), list6, rand.Next(0, 4));
            Line line7 = new Line(rand.Next(1, 1000), list7, rand.Next(0, 4));
            Line line8 = new Line(rand.Next(1, 1000), list8, rand.Next(0, 4));
            Line line9 = new Line(rand.Next(1, 1000), list9, rand.Next(0, 4));
            Line line10 = new Line(rand.Next(1, 1000), list10, rand.Next(0, 4));

            busLines = new MyList();
            busLines.AddLine(line1);
            busLines.AddLine(line2);
            busLines.AddLine(line3);
            busLines.AddLine(line4);
            busLines.AddLine(line5);
            busLines.AddLine(line6);
            busLines.AddLine(line7);
            busLines.AddLine(line8);
            busLines.AddLine(line9);
            busLines.AddLine(line10);

           
            InitializeComponent();
            cbBusLines.ItemsSource = busLines;
            cbBusLines.DisplayMemberPath = " BusLineNum ";
            cbBusLines.SelectedIndex = 0;
            ShowBusLine(cbBusLines.SelectedIndex);
        }

        private Line currentDisplayBusLine;

        private void ShowBusLine(int index)
        {
            currentDisplayBusLine = busLines[busLines.FindLineIndex(index)];
            UpGrid.DataContext = currentDisplayBusLine;
            lbBusLineStations.DataContext = currentDisplayBusLine.StationsList;
        }

        private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowBusLine((cbBusLines.SelectedValue as Line).LineKey);
        }
    }
}
