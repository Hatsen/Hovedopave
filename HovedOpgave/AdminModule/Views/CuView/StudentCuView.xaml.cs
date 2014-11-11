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
using AdminModule.ViewModels;
using AdminModule.Webservice;

namespace AdminModule.Views
{
    /// <summary>
    /// Interaction logic for StudentCuView.xaml
    /// </summary>
    public partial class StudentCuView : Window
    {

        private StudentCuViewModel viewModel;

        public StudentCuView(object student = null) // se nok mere teacher som generics objekt
        {
            InitializeComponent();

            if (viewModel == null)
                viewModel = new StudentCuViewModel();


            viewModel.Viewstate = student == null ? Enums.ViewState.Create : Enums.ViewState.Edit;


            if (student != null)
            {
                viewModel.CurrentStudent = (Student)student; // vigtig eftersom jeg ikke får smidt de data som kom fra objektet med ind. Viewstate sættes i starten til create. Er efter linien ovenover blevet sat til edit.
            }
        
            this.DataContext = viewModel;
            InitializeEvents();

        }


        private void InitializeEvents()
        {
            if (viewModel != null)
            {
                viewModel.OnProjectViewClose += viewModel_OnStudentViewClose;

            }
        }


        private void RemoveEvents()
        {

            if (viewModel != null)
            {
                viewModel.OnProjectViewClose -= viewModel_OnStudentViewClose;
            }

        }


        void viewModel_OnStudentViewClose()
        {
            this.Close();
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoveEvents();
        }
    }
}
