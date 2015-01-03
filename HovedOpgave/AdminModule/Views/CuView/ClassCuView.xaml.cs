using AdminModule.ViewModels;
using AdminModule.Webservice;
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

namespace AdminModule.Views
{
    /// <summary>
    /// Interaction logic for ClassCuView.xaml
    /// </summary>
    public partial class ClassCuView : Window
    {

        private ClassCuViewModel viewModel;

        public ClassCuView(ClassEx classe = null) 
        {
          
            if (viewModel == null)
                viewModel = new ClassCuViewModel();

            viewModel.Viewstate = classe == null ? Enums.ViewState.Create : Enums.ViewState.Edit;

            if (classe!=null)
            {
                viewModel.CurrentClass = classe;
            }

           
            this.DataContext = viewModel;
            InitializeComponent();

            InitializeEvents();

        }


        private void InitializeEvents()
        {
            if (viewModel != null)
            {
                viewModel.OnClassViewClose += viewModel_OnClassViewClose;

            }
        }


        private void RemoveEvents()
        {

            if (viewModel != null)
            {
                viewModel.OnClassViewClose-= viewModel_OnClassViewClose;
            }

        }




        void viewModel_OnClassViewClose()
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoveEvents();

        }

    }
}
