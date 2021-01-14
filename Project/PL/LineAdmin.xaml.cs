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

            // DU PROJET 3A 

            //cbLines.ItemsSource =  liste de ttes les lines;
            //ShowBusLine(cbLines.SelectedIndex);


            cbLines.DisplayMemberPath = "Code";//show only specific Property of object
            cbLines.SelectedValuePath = "Id";//selection return only specific Property of object
            cbLines.SelectedIndex = 0; //index of the object to be selected
            RefreshAllLineComboBox();
        }

        void RefreshAllLineComboBox()
        {
            cbLines.DataContext = bl.GetAllLine();
        }

        void RefreshAllStationsGrid()
        {
             lbLineStations.DataContext = bl.GetAllLineStationsInLine(curLine);
        }

        private void cbLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            curLine = cbLines.SelectedItem as BL.BO.Line;
            //gridOneStudent.DataContext = curLine;

            if (curLine != null)
            {
            //    ShowBusLine((DataSource.ListLine).FindLineIndex(((BL.BO.Line)cbLines.SelectedItem).LineKey));

                //list of stations of selected line

                //RefreshAllLinesGrid();
            }
        }

        private void ShowBusLine(int index)
        {
            curLine = DS.DataSource.ListLine[index];
            UpGrid.DataContext = curLine;
            lbLineStations.DataContext = curLine.StationsList;
        }




        //    private void btUpdateStudent_Click(object sender, RoutedEventArgs e)
        //    {
        //        try
        //        {
        //            if (curStu != null)
        //                bl.UpdateStudentPersonalDetails(curStu);
        //        }
        //        catch (BO.BadStudentIdException ex)
        //        {
        //            MessageBox.Show(ex.Message, "Operation Failure",MessageBoxButton.OK,MessageBoxImage.Error);
        //        }
        //    }

        //    private void btDeleteStudent_Click(object sender, RoutedEventArgs e)
        //    {
        //        MessageBoxResult res = MessageBox.Show("Delete selected student?", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
        //        if (res == MessageBoxResult.No)
        //            return;

        //        try
        //        {
        //            if (curStu != null)
        //            {
        //                bl.DeleteStudent(curStu.ID);

        //                RefreshAllRegisteredCoursesGrid();
        //                RefreshAllNotRegisteredCoursesGrid();
        //                RefreshAllStudentComboBox();
        //            }
        //        }
        //        catch(BO.BadStudentIdCourseIDException ex)
        //        {
        //            MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //        catch (BO.BadStudentIdException ex)
        //        {
        //            MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }

        //    private void btUpdateGradeInCourse_Click(object sender, RoutedEventArgs e)
        //    {
        //        BO.StudentCourse scBO = ((sender as Button).DataContext as BO.StudentCourse);
        //        GradeWindow win = new GradeWindow(scBO);
        //        win.Closing += WinUpdateGrade_Closing;
        //        win.ShowDialog();
        //    }

        //    private void WinUpdateGrade_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //    {
        //        BO.StudentCourse scBO = (sender as GradeWindow).curScBO; 

        //        MessageBoxResult res = MessageBox.Show("Update grade for selected student?", "Verification", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
        //        if (res == MessageBoxResult.No)
        //        {
        //            (sender as GradeWindow).cbGrade.Text = (sender as GradeWindow).gradeBeforeUpdate.ToString();
        //        }
        //        else if (res == MessageBoxResult.Cancel)
        //        {
        //            (sender as GradeWindow).cbGrade.Text = (sender as GradeWindow).gradeBeforeUpdate.ToString();
        //            e.Cancel = true; //window stayed open. cancel closing event.
        //        }
        //        else
        //        {
        //            try
        //            {
        //                bl.UpdateStudentGradeInCourse(curStu.ID, scBO.ID, (float)scBO.Grade);
        //                RefreshAllRegisteredCoursesGrid();

        //            }
        //            catch (BO.BadStudentIdCourseIDException ex)
        //            {
        //                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
        //            }
        //        }
        //    }
        //    private void btUnRegisterCourse_Click(object sender, RoutedEventArgs e)
        //    {
        //        try
        //        {
        //            BO.StudentCourse scBO = ((sender as Button).DataContext as BO.StudentCourse);
        //            bl.DeleteStudentInCourse(curStu.ID, scBO.ID);
        //            RefreshAllRegisteredCoursesGrid();
        //            RefreshAllNotRegisteredCoursesGrid();
        //        }
        //        catch(BO.BadStudentIdCourseIDException ex)
        //        {
        //            MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }
        //    private void btRegisterCourse_Click(object sender, RoutedEventArgs e)
        //    {
        //        if (curStu == null)
        //        {
        //            MessageBox.Show("You must select a student first", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
        //            return;
        //        }
        //        try
        //        {
        //            BO.Course cBO = ((sender as Button).DataContext as BO.Course);
        //            bl.AddStudentInCourse(curStu.ID, cBO.ID);

        //            RefreshAllRegisteredCoursesGrid();
        //            RefreshAllNotRegisteredCoursesGrid();
        //        }
        //        catch (BO.BadStudentIdCourseIDException ex)
        //        {
        //            MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }

        //    }

        //    private void btAddStudent_Click(object sender, RoutedEventArgs e)
        //    {
        //        MessageBox.Show("This method is under construction!", "TBD", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        //    }
        //}

    }
}
