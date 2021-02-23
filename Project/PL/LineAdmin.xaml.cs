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

            cbLines.DisplayMemberPath = "Code"; //show only specific Property of object                  // verifier si fo pas enlever car dit deux fois (ds cs et xml) 
            cbLines.SelectedValuePath = "Id";   //selection return only specific Property of object
            cbLines.SelectedIndex = 0;          //index of the object to be selected
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
            // curLine = cbLines.SelectedItem as BL.BO.Line;
            curLine = (BL.BO.Line) cbLines.SelectedItem;
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
            //if (curLine != null)
            //    RefreshAllLinesGrid();
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

        #region  student example 
        //private void btUpdateStudent_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (curStu != null)
        //            bl.UpdateStudentPersonalDetails(curStu);
        //    }
        //    catch (BO.BadStudentIdException ex)
        //    {
        //        MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}

        //private void btDeleteStudent_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBoxResult res = MessageBox.Show("Delete selected student?", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
        //    if (res == MessageBoxResult.No)
        //        return;

        //    try
        //    {
        //        if (curStu != null)
        //        {
        //            bl.DeleteStudent(curStu.ID);

        //            RefreshAllRegisteredCoursesGrid();
        //            RefreshAllNotRegisteredCoursesGrid();
        //            RefreshAllStudentComboBox();
        //        }
        //    }
        //    catch (BO.BadStudentIdCourseIDException ex)
        //    {
        //        MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //    catch (BO.BadStudentIdException ex)
        //    {
        //        MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}

        //private void btUpdateGradeInCourse_Click(object sender, RoutedEventArgs e)
        //{
        //    BO.StudentCourse scBO = ((sender as Button).DataContext as BO.StudentCourse);
        //    GradeWindow win = new GradeWindow(scBO);
        //    win.Closing += WinUpdateGrade_Closing;
        //    win.ShowDialog();
        //}

        //private void WinUpdateGrade_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    BO.StudentCourse scBO = (sender as GradeWindow).curScBO;

        //    MessageBoxResult res = MessageBox.Show("Update grade for selected student?", "Verification", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
        //    if (res == MessageBoxResult.No)
        //    {
        //        (sender as GradeWindow).cbGrade.Text = (sender as GradeWindow).gradeBeforeUpdate.ToString();
        //    }
        //    else if (res == MessageBoxResult.Cancel)
        //    {
        //        (sender as GradeWindow).cbGrade.Text = (sender as GradeWindow).gradeBeforeUpdate.ToString();
        //        e.Cancel = true; //window stayed open. cancel closing event.
        //    }
        //    else
        //    {
        //        try
        //        {
        //            bl.UpdateStudentGradeInCourse(curStu.ID, scBO.ID, (float)scBO.Grade);
        //            RefreshAllRegisteredCoursesGrid();

        //        }
        //        catch (BO.BadStudentIdCourseIDException ex)
        //        {
        //            MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }
        //}
        //private void btUnRegisterCourse_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        BO.StudentCourse scBO = ((sender as Button).DataContext as BO.StudentCourse);
        //        bl.DeleteStudentInCourse(curStu.ID, scBO.ID);
        //        RefreshAllRegisteredCoursesGrid();
        //        RefreshAllNotRegisteredCoursesGrid();
        //    }
        //    catch (BO.BadStudentIdCourseIDException ex)
        //    {
        //        MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
        //private void btRegisterCourse_Click(object sender, RoutedEventArgs e)
        //{
        //    if (curStu == null)
        //    {
        //        MessageBox.Show("You must select a student first", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }
        //    try
        //    {
        //        BO.Course cBO = ((sender as Button).DataContext as BO.Course);
        //        bl.AddStudentInCourse(curStu.ID, cBO.ID);

        //        RefreshAllRegisteredCoursesGrid();
        //        RefreshAllNotRegisteredCoursesGrid();
        //    }
        //    catch (BO.BadStudentIdCourseIDException ex)
        //    {
        //        MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }

        //}

        //    private void btAddStudent_Click(object sender, RoutedEventArgs e)
        //    {
        //        MessageBox.Show("This method is under construction!", "TBD", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        //    }
        //}
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
