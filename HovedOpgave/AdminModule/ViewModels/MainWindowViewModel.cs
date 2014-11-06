using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AdminModule.Views;
using AdminModule.Webservice;
using Microsoft.Practices.Prism.Commands;

namespace AdminModule.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel()
        {

            UpdateCommand = new DelegateCommand<object>(Update);
            CreateTeacherCommand = new DelegateCommand<object>(CreateTeacher);
            EditTeacherCommand = new DelegateCommand<object>(EditTeacher);
            UpdateStudentsCommand = new DelegateCommand<object>(UpdateStudents);
        }

        private string selectedPerson;


        public string ObjectListstring = "ObjectList";
        public string Larsstring = "LarsSource1";

        private List<string> teacherList;

        public List<string> TeacherList
        {
            get { return teacherList; }
            set
            {
               
                teacherList.Add("Teacher");
                teacherList.Add("Student"); // skal self hentes fra service
                teacherList = value;
                OnPropertyChanged("TeacherList");

            }
        }

        public string SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                selectedPerson = value;
                GetTeachers();
            }
        }

        private List<Student> LarsSource;

        public List<Student> LarsSource1
        {
            get { return LarsSource; }
            set
            {
             //   GetStudents();
                
                LarsSource = value;
                OnPropertyChanged("LarsSource1");
            }
        }

        private List<Teacher> objectList;

        public List<Teacher> ObjectList
        {
            get { return objectList; }
            set
            {
              //  GetTeachers();
                objectList = value;
              
                OnPropertyChanged("ObjectList");

            } 

        }


        private async void GetTeachers()
        {

            ObjectList = await ServiceProxy.Instance.GetTeachers();

        }

        private async void GetStudents()
        {

            LarsSource1 = await ServiceProxy.Instance.GetStudents();

        }

        public void Update(Object o)
        {
         GetTeachers();
        }

        public bool MayiWrite(Object o)
        {
            return true;
        }

        public void UpdateStudents(Object o)
        {
            GetStudents();
        }

        public DelegateCommand<object> UpdateStudentsCommand { get; set; }

        public DelegateCommand<object> UpdateCommand { get; set; }

        public DelegateCommand<object> CreateTeacherCommand { get; set; }

        public void CreateTeacher(Object o)
        {
            TeacherCuView tview = new TeacherCuView();
            tview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            tview.ShowDialog();

        }

        public DelegateCommand<object> EditTeacherCommand { get; set; }

        public void EditTeacher(Object o)
        {

            Teacher t = new Teacher();
            t.Firstname = "a";
            t.Lastname = "!";
            t.City = "ss";
            t.Birthdate = "sss";
            t.Address = "sasdsda";
            t.Userrole = 1;

            TeacherCuView tview = new TeacherCuView(t);
            tview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            tview.ShowDialog();

        }








    }
}
