using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using AdminModule.Views;
using AdminModule.Webservice;
using Microsoft.Practices.Prism.Commands;

namespace AdminModule.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        // sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
        public MainWindowViewModel()
        {
            //ObjectHolder.Instance.PropertyChanged += (sender, args) => OnPropertyChanged(args.PropertyName); // viewmodel lytter på objectholderen.
            CreateTeacherCommand = new DelegateCommand<object>(CreateTeacher);
            EditUserCommand = new DelegateCommand<object>(EditUser, MayiWrite);
            UpdateStudentsCommand = new DelegateCommand<object>(UpdateStudents);
            CreateParentCommand = new DelegateCommand<object>(CreateParent);
            CreateStudentCommand = new DelegateCommand<object>(CreateStudent);
            CreateClassCommand = new DelegateCommand<object>(CreateClass);
            GetClassesCommand = new DelegateCommand<object>(GetClasses);
            EditClassCommand = new DelegateCommand<object>(EditClass, MayiEditClass);

            List<string> listofpersons = new List<string>();
            listofpersons.Add("Underviser");
            listofpersons.Add("Elev");
            listofpersons.Add("Forældre");
            PersonStringList = listofpersons;

        }

        public event Action<string> OnselectedPersonChanged;

        #region PrivateMembers

        private bool isloading;
        private Object selectedUser;
        private List<Teacher> teacherList;
        private List<Student> studentList;
        private List<Parent> parentList;
        private List<string> personStringList;
        private string selectedStringPerson;
        private List<Class> classList;
        private Class selectedClass;

        #endregion

        #region Proberties

        public bool Isloading
        {
            get { return isloading; }
            set
            {
                isloading = value;
                OnPropertyChanged("Isloading");
            }
        }

        public Object SelectedUser // forskel mellem selecteduser fra comboboksen og datagriddet.
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
                EditUserCommand.RaiseCanExecuteChanged();
            }
        }

        public List<Teacher> TeacherList
        {
            get { return ObjectHolder.Instance.TeacherList; }
            set
            {
                ObjectHolder.Instance.TeacherList = value;
                OnPropertyChanged("TeacherList");
            }
        }


        public List<Parent> ParentList
        {
            get { return parentList; }
            set
            {
                parentList = value;
                OnPropertyChanged("ParentList");
            }
        }


        public List<Student> StudentList
        {
            get
            {
                return studentList;
            }
            set
            {

                studentList = value;
                OnPropertyChanged("StudentList");
            }
        }


        public List<Class> ClassList
        {
            get
            {
                return classList;
            }
            set
            {
                classList = value;
                OnPropertyChanged("ClassList");
            }
        }


        public Class SelectedClass
        {
            get
            {
                return selectedClass;
            }
            set
            {
                selectedClass = value;
                OnPropertyChanged("SelectedClass");
                EditClassCommand.RaiseCanExecuteChanged();
            }
        }



        public List<string> PersonStringList
        {
            get
            {
                return personStringList;
            }
            set
            {
                personStringList = value;
                OnPropertyChanged("PersonStringList");
            }
        }


        public string SelectedStringPerson
        {
            get { return selectedStringPerson; }
            set
            {
                // når den bliver sat skal den hente listen af den selecterede persontype. 
                //Herefter skal der sendes et event ud til view for at ændre på itemsource for datagriddet.

                selectedStringPerson = value;

                if (selectedStringPerson == "Underviser")
                    GetTeachers(); // async metode

                else if (selectedStringPerson == "Elev")
                    GetStudents();

                else if (selectedStringPerson == "Forældre")
                {
                    GetParents();
                }

                //    RaiseOnselectedPersonChanged(selectedStringPerson); må ikke bruges her da der ikke er blevet tilføjet noget til listen endnu.
                OnPropertyChanged("SelectedStringPerson");
            }
        }

        #endregion

        #region Commands


        public DelegateCommand<object> UpdateStudentsCommand { get; set; }

        public void UpdateStudents(Object o)
        {
            GetStudents();
        }


        public bool MayiWrite(Object o)
        {
            bool boolen = false;

            if (selectedUser != null)
                boolen = true;
            return boolen;
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


        public DelegateCommand<object> CreateClassCommand { get; set; }

        public void CreateClass(Object o)
        {
            Views.ClassCuView cview = new Views.ClassCuView();
            cview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            cview.ShowDialog();
        }


        public DelegateCommand<object> EditUserCommand { get; set; }

        public void EditUser(Object o)
        {
            if (selectedStringPerson == "Underviser")
            {
                TeacherCuView tview = new TeacherCuView((Teacher)SelectedUser);
                tview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                tview.ShowDialog();
            }

            if (selectedStringPerson == "Elev")
            {
                StudentCuView sview = new StudentCuView((Student)SelectedUser);
                sview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                sview.ShowDialog();
            }

            if (selectedStringPerson == "Forældre")
            {
                ParentCuView paview = new ParentCuView((Parent)SelectedUser);
                paview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                paview.ShowDialog();
            }
        } 


        public DelegateCommand<object> GetClassesCommand { get; set; }

        public void GetClasses(Object o)
        {
            GetClasses();//overloading.

        }


        public DelegateCommand<object> EditClassCommand { get; set; }

        public void EditClass(Object o)
        {
            ClassCuView cview = new ClassCuView(SelectedClass);
            cview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            cview.ShowDialog();

        }

        public bool MayiEditClass(Object o)
        {
            bool boolen = false;

            if (selectedClass != null)
                boolen = true;
            return boolen;
        }

        #endregion

        #region Methods

        private async void GetTeachers()
        {
            Isloading = true;
            TeacherList = await ServiceProxy.Instance.GetTeachers();
            Isloading = false;
            RaiseOnselectedPersonChanged("Underviser");
        }


        private async void GetClasses()
        {
            Isloading = true;
            ClassList = await ServiceProxy.Instance.GetClasses();
            Isloading = false;
           // RaiseOnselectedPersonChanged("Underviser");  ikke være nødvendig for klasse.
        }

        private async void GetStudents()
        {
            Isloading = true;
            StudentList = await ServiceProxy.Instance.GetStudents();
            Isloading = false;
            RaiseOnselectedPersonChanged("Elev");
        }

        private async void GetParents()
        {
            Isloading = true;
            ParentList = await ServiceProxy.Instance.GetParents();
            Isloading = false;
            RaiseOnselectedPersonChanged("Forældre");
        }




        public void RaiseOnselectedPersonChanged(string theSelectedPersonString)
        {
            if (OnselectedPersonChanged != null) // er der nogle som  lytter på den. Ikke om den er instansieret.
            {
                OnselectedPersonChanged(theSelectedPersonString);
            }

        }


        #endregion



    }
}
