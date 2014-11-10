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



            combo.Items.Add("1");
            combo.Items.Add("2");
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            /*   datagridet.ItemsSource = null;
               datagridet.ItemsSource = viewmodel.Larsstring;
               datagridet.Items.Refresh();*/



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //datagridet.Visibility = Visibility.Visible;
            //  datagridet.ItemsSource = viewmodel.ObjectListstring;
            datagridTeacheren.Visibility = Visibility.Visible;
            
            //datagridStudent.Visibility = Visibility.Hidden;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            /*datagridTeacheren.Visibility = Visibility.Hidden;
            datagridStudent.Visibility = Visibility.Visible;*/
        }

      


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // husk at tryk på button ud for comboboks først.

            DataGrid gridInTemplate = (DataGrid)FindName("datagridTeacheren");

            string a = gridInTemplate.ItemsSource.ToString();

        
            gridInTemplate.DataContext = null;

            gridInTemplate.ItemsSource = viewmodel.StudentList;

          

           // gridInTemplate.ItemsSource = b;

         /*   gridInTemplate2.ItemsSource = "StudentList";

            string b = gridInTemplate2.ItemsSource.ToString();*/


           /* string a = datagridTeacheren.ItemsSource.ToString();

            string b = "System.Collections.Generic.List`1[AdminModule.Webservice.Student]";
            
            datagridTeacheren.ItemsSource = b;*/
        }


    }
}
