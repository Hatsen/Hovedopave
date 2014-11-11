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

namespace AdminModule.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        private MainWindowViewModel viewmodel;

        public MainWindowView()
        {
            InitializeComponent();
            if (viewmodel == null)
            {
                viewmodel = new MainWindowViewModel();
            }

            this.DataContext = viewmodel;

            InitializeEvents();
        }

        private void InitializeEvents()
        {
            viewmodel.OnselectedPersonChanged += UpdateDatagrid;
        }

        private void UpdateDatagrid(string selectedUserString)
        {

            datagridUser.ItemsSource = null; // hvis itemssource er null må selecteditem også være null. Dette sørger VS selv for. (smart)

            if (datagridUser.Columns.Count > 8) // grundet rank på teacher. Kommer også til at gælde for elev.
            {
                datagridUser.Columns.RemoveAt(8);
            }

            if (selectedUserString == "Elev")
            {
                datagridUser.ItemsSource = viewmodel.StudentList;
            }
            else if (selectedUserString == "Underviser")
            {
                DataGridTextColumn col = new DataGridTextColumn();
                col.Header = "Rank";
                col.Binding = new Binding("Rank");
                datagridUser.Columns.Add(col);

                datagridUser.ItemsSource = viewmodel.TeacherList;

            }
            else if (selectedUserString == "Forældre")
            {
                datagridUser.ItemsSource = viewmodel.TeacherList;
            }
        }

    }
}
