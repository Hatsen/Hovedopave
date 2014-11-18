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
using AdminModule.Webservice;

namespace AdminModule.Views.DeleteView
{
    /// <summary>
    /// Interaction logic for DeleteView.xaml
    /// </summary>
    public partial class DeleteView : Window
    {
        private DeleteViewModel viewModel;

        public DeleteView(ClassEx selectedClassEx) // tjek om det er teacherex eller class 
        {
            if (viewModel == null)
            {
                viewModel = new DeleteViewModel();
            }

            DataContext = viewModel;
            viewModel.CurrentClass = selectedClassEx;

            InitializeComponent();
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
