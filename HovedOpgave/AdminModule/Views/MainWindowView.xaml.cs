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
            datagridTeacher.Visibility = Visibility.Visible;
            datagridStudent.Visibility = Visibility.Hidden;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            datagridTeacher.Visibility = Visibility.Hidden;
            datagridStudent.Visibility = Visibility.Visible;
        }

    }
}
