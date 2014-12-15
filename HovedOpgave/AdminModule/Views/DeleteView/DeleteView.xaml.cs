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
using AdminModule.ViewModels.DeleteViewModels;
//using AdminModule.Webservice;
using AdminModule.WebServiceDeployed;

namespace AdminModule.Views.DeleteView
{
    /// <summary>
    /// Interaction logic for DeleteView.xaml
    /// </summary>
    public partial class DeleteView : Window
    {
        private DeleteViewModel viewModel;

        public DeleteView(ClassEx selectedClassEx = null, TeacherEx selectedTeacher = null) // tjek om det er teacherex eller class 
        {

            InitializeComponent();

            if (viewModel == null)
            {
                viewModel = new DeleteViewModel();
            }

            if (selectedClassEx != null) // er det teacher eller class der ønskes slettet?
            {
                viewModel.ViewstateObject = Enums.ViewstateObject.Class;
                viewModel.CurrentClass = selectedClassEx;
                datagridClassesEx.Visibility = Visibility.Hidden;
                cbListofTeachers.Visibility = Visibility.Hidden;
               butAssociate.Visibility = Visibility.Hidden;


            }
            else if (selectedTeacher != null)
            {
                viewModel.ViewstateObject = Enums.ViewstateObject.Teacher;
                viewModel.CurrentTeacherEx = selectedTeacher;
                listboxStudents.Visibility = Visibility.Hidden;
                cbListofClasses.Visibility = Visibility.Hidden;

            }

            DataContext = viewModel;
            InitializeEvents();

        }


        private void InitializeEvents()
        {
            if (viewModel != null)
            {
                viewModel.OnDeleteViewClose += OnDeleteViewClose;
            }

        }

        private void OnDeleteViewClose()
        {
            Close();
        }

        private void RemoveEvents()
        {
            if (viewModel != null)
            {
                viewModel.OnDeleteViewClose -= OnDeleteViewClose;
            }
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoveEvents();
        }

    }
}
