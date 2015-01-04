
/**
* Copyright (c) 2013 Lars Skaaning Jensen
*
* The terms of use for this and related files can be read in
* the fictional LICENSE file, which do not exist!
*/
/**
* Author: Lars Skaaning Jensen
* Location: Erhvervsakademiet Lillebælt, DAT12A
*/



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


            if (selectedUserString == "Elev")
            {
                datagridUser.ItemsSource = viewmodel.StudentList;
            }
            else if (selectedUserString == "Underviser")
            {
       

                datagridUser.ItemsSource = viewmodel.TeacherList;

            }
            else if (selectedUserString == "Forældre")
            {
                datagridUser.ItemsSource = viewmodel.ParentList;
            }
            }

    }
}
