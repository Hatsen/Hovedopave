﻿using System;
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
    /// Interaction logic for TeacherCuView.xaml
    /// </summary>
    public partial class TeacherCuView : Window
    {
        private TeacherCuViewModel viewModel = new TeacherCuViewModel();

        public TeacherCuView(object teacher=null) // se nok mere teacher som generics objekt
        {
            InitializeComponent();

            if (viewModel == null)
                  viewModel = new TeacherCuViewModel();


            viewModel.Viewstate = teacher == null ? Enums.ViewState.Create : Enums.ViewState.Edit;
            
         /*   if (teacher.GetType()==typeof(Teacher))
            {
                teacher = (Teacher) teacher;
            }
            else if (teacher.GetType()==typeof(Student))
            {
                
            }
            else if (teacher.GetType() == typeof(Parent))
            {

            }*/

            // her skal tjekkes hvilken type object der skal sættes ind i viewmodel.

            if (teacher!=null ) // object!=null for at dele samme viewmodel. ELLER vær kold og tjek for objectypen i viewmodel?
            {
                viewModel.CurrentTeacher = (Teacher)teacher; // vigtig eftersom jeg ikke får smidt de data som kom fra objektet med ind. Viewstate sættes i starten til create. Er efter linien ovenover blevet sat til edit.
            }

            
           
            this.DataContext = viewModel;

           /* viewModel.Ranks.Add(1);
            viewModel.Ranks.Add(2);*/

            InitializeEvents();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoveEvents();
        }

        private void InitializeEvents()
        {
            if (viewModel != null)
            {

                viewModel.OnTeacherViewClose += viewModel_OnTeacherViewClose;

            }
        }

     
        private void RemoveEvents()
        {
            if (viewModel != null)
            {
                viewModel.OnTeacherViewClose -= viewModel_OnTeacherViewClose;
            }
        }

        void viewModel_OnTeacherViewClose()
        {
            this.Close();
        }
      

    }
}