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
            EditUserCommand = new DelegateCommand<object>(EditUser);
            UpdateStudentsCommand = new DelegateCommand<object>(UpdateStudents);

            CreateParentCommand = new DelegateCommand<object>(CreateParent);

            CreateStudentCommand = new DelegateCommand<object>(CreateStudent);

        }

        #region PrivateMembers

        private string selectedUser;
        private List<Teacher> teacherList;
        private List<Student> studentList;

        #endregion


        #region Proberties
        public List<Teacher> TeacherList
        {
            get { return teacherList; }
            set
            {
               
              /*  teacherList.Add("Teacher");
                teacherList.Add("Student"); // skal self hentes fra service*/
                teacherList = value;
                OnPropertyChanged("TeacherList");

            }
        }

        public string SelectedUser // forskel mellem selecteduser fra comboboksen og datagriddet.
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                GetTeachers();
            }
        }

    

        public List<Student> StudentList
        {
            get { return studentList; }
            set
            {

                studentList = value;
                OnPropertyChanged("StudentList");
            }
        }


        #endregion

        #region Commands


        public DelegateCommand<object> UpdateStudentsCommand { get; set; }

        public void UpdateStudents(Object o)
        {
            GetStudents();
        }

        public DelegateCommand<object> UpdateCommand { get; set; }

        public void Update(Object o)
        {
            GetTeachers();
        }


        public bool MayiWrite(Object o)
        {
            return true;
        }

        public DelegateCommand<object> CreateTeacherCommand { get; set; }

        public void CreateTeacher(Object o)
        {
            TeacherCuView tview = new TeacherCuView();
            tview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            tview.ShowDialog();

        }


        public DelegateCommand<object> CreateParentCommand { get; set; }

        public void CreateParent(Object o)
        {
            ParentCuView pview = new ParentCuView();
            pview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            pview.ShowDialog();

        }


        public DelegateCommand<object> CreateStudentCommand { get; set; }

        public void CreateStudent(Object o)
        {
            Views.StudentCuView sview = new Views.StudentCuView();
            sview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            sview.ShowDialog();

        }






        public DelegateCommand<object> EditUserCommand { get; set; }

        public void EditUser(Object o)
        {
            // hvis teacer er selecteret så ved du det er objekt teacher der skal sendes ind.
            // bare kald den edit og vurder hvilket object der er selecteret.

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

        } // next week



        #endregion


        #region Methods

        private async void GetTeachers()
        {
            StudentList = await ServiceProxy.Instance.GetStudents();
           // TeacherList = await ServiceProxy.Instance.GetTeachers();

        }

        private async void GetStudents()
        {

            StudentList = await ServiceProxy.Instance.GetStudents();

        }

        #endregion



    }
}
