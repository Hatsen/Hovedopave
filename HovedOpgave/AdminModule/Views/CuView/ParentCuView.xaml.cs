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
    /// Interaction logic for ParentCuView.xaml
    /// </summary>
    public partial class ParentCuView : Window
    {
        private ParentCuViewModel viewModel;

        public ParentCuView(ParentEx parent = null) // se nok mere teacher som generics objekt
        {
            InitializeComponent();

            if (viewModel == null)
                viewModel = new ParentCuViewModel();

            viewModel.Viewstate = parent == null ? Enums.ViewState.Create : Enums.ViewState.Edit;

            

            if (parent!=null)
            {
                viewModel.CurrentParent = parent;
            }

           
            this.DataContext = viewModel;

            InitializeEvents();

        }


        private void InitializeEvents()
        {
            if (viewModel != null)
            {
                viewModel.OnParentViewClose += viewModel_OnParentViewClose;

            }
        }


        private void RemoveEvents()
        {

            if (viewModel != null)
            {
                viewModel.OnParentViewClose -= viewModel_OnParentViewClose;
            }

        }




        void viewModel_OnParentViewClose()
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoveEvents();

        }

     


    }
}
