using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using AdminModule.Views;
using AdminModule.Views.DeleteView;
using AdminModule.Webservice;
using Microsoft.Practices.Prism.Commands;

namespace AdminModule.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel()
        {

            ObjectHolder.Instance.PropertyChanged += (sender, args) =>
                {
                    /*if (args.PropertyName == "TeacherList")
                    {
                        TeacherList = ObjectHolder.Instance.TeacherList;
                    }*/
                    OnPropertyChanged(args.PropertyName); // viewmodel lytter på objectholderen.
                };

            CreateTeacherCommand = new DelegateCommand<object>(CreateTeacher);
            EditUserCommand = new DelegateCommand<object>(EditUser, MayiEditPerson);
            UpdateStudentsCommand = new DelegateCommand<object>(UpdateStudents);
            CreateParentCommand = new DelegateCommand<object>(CreateParent);
            CreateStudentCommand = new DelegateCommand<object>(CreateStudent);
            CreateClassCommand = new DelegateCommand<object>(CreateClass);
            GetClassesCommand = new DelegateCommand<object>(GetClasses);
            EditClassCommand = new DelegateCommand<object>(EditClass, MayiEditClass);
            DeleteUserCommand = new DelegateCommand<object>(DeletePerson, MayiEditPerson);
            DeleteClassCommand = new DelegateCommand<object>(DeleteClass, MayiEditClass);
            ResetPasswordCommand = new DelegateCommand<object>(ResetPasswordForSelectedUser, MayiEditPerson);

            List<string> listofpersons = new List<string>();
            listofpersons.Add("Underviser");
            listofpersons.Add("Elev");
            listofpersons.Add("Forældre");
            PersonStringList = listofpersons;

        }

        public event Action<string> OnselectedPersonChanged;

        #region PrivateMembers

        private bool isloading;
        private User selectedUser;
        private List<TeacherEx> teacherList;
        private List<Student> studentList;
        private List<ParentEx> parentList;
        private List<string> personStringList;
        private string selectedStringPerson;
        private List<ClassEx> classList;
        private ClassEx selectedClass;

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

        public User SelectedUser // forskel mellem selecteduser fra comboboksen og datagriddet.
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
                EditUserCommand.RaiseCanExecuteChanged();
                DeleteUserCommand.RaiseCanExecuteChanged();
                ResetPasswordCommand.RaiseCanExecuteChanged();
            }
        }

        public List<TeacherEx> TeacherList
        {
            get { return teacherList; }
            set
            {
                teacherList = value;
                OnPropertyChanged("TeacherList");
            }
        }


        public List<ParentEx> ParentList
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


        public List<ClassEx> ClassList
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


        public ClassEx SelectedClass
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
                DeleteClassCommand.RaiseCanExecuteChanged();
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


        public DelegateCommand<object> ResetPasswordCommand { get; set; }

        public DelegateCommand<object> UpdateStudentsCommand { get; set; }

        public void UpdateStudents(Object o)
        {
            GetStudents();
        }


        public bool MayiEditPerson(Object o)
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
            tview.Closing += tview_Closing; // den kører ikke videre indtil viewet lukker.
            SelectedStringPerson = "Underviser"; // heri bliver der kaldt GetParents();
            // GetTeachers();
        }

        void tview_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }


        public DelegateCommand<object> CreateParentCommand { get; set; }

        public async void CreateParent(Object o)
        {
            bool done = await GetClasses(); // så åbner den først vinduet når kriterierne er opfyldt! smart :)
            ParentCuView pview = new ParentCuView();
            pview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            pview.ShowDialog();
            pview.Closing += pview_Closing;
            // GetParents();
            SelectedStringPerson = "Forældre"; // heri bliver der kaldt GetParents();
        }

        void pview_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }


        public DelegateCommand<object> CreateStudentCommand { get; set; }

        public void CreateStudent(Object o)
        {
            Views.StudentCuView sview = new Views.StudentCuView();
            sview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            sview.ShowDialog();
            sview.Closing += sview_Closing;
            //  GetStudents();
            SelectedStringPerson = "Elev"; // heri bliver der kaldt GetStudent();
        }

        void sview_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }


        public DelegateCommand<object> CreateClassCommand { get; set; }

        public async void CreateClass(Object o)
        {
            bool waiter;
            Views.ClassCuView cview = new Views.ClassCuView();
            cview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            cview.ShowDialog();
            cview.Closing += cview_Closing;
            waiter = await GetClasses();
        }

        void cview_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        public DelegateCommand<object> EditClassCommand { get; set; }

        public async void EditClass(Object o)
        {
            bool waiter;
            ClassCuView cview = new ClassCuView(SelectedClass);
            cview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            cview.ShowDialog();
            cview.Closing += cview_Closing;
            waiter = await GetClasses();
        }

        public bool MayiEditClass(Object o)
        {
            bool boolen = false;

            if (selectedClass != null)
                boolen = true;

            return boolen;
        }



        public DelegateCommand<object> EditUserCommand { get; set; }

        public void EditUser(Object o)
        {
            if (selectedStringPerson != null)
            {
                if (selectedStringPerson == "Underviser")
                {
                    TeacherCuView tview = new TeacherCuView((TeacherEx)SelectedUser);
                    tview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    tview.ShowDialog();
                    tview.Closing += tview_Closing; // den kører ikke videre indtil viewet lukker.

                }

                if (selectedStringPerson == "Elev")
                {
                    StudentCuView sview = new StudentCuView((Student)SelectedUser);
                    sview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    sview.ShowDialog();
                    sview.Closing += sview_Closing;
                }

                if (selectedStringPerson == "Forældre")
                {
                    ParentCuView pview = new ParentCuView((ParentEx)SelectedUser);
                    pview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    pview.ShowDialog();
                    pview.Closing += pview_Closing;
                }

                SelectedStringPerson = selectedStringPerson;
            }

        }


        public DelegateCommand<object> GetClassesCommand { get; set; }

        public void GetClasses(Object o)
        {
            GetClasses();//overloading.

        }



        public DelegateCommand<object> DeleteUserCommand { get; set; }

        public DelegateCommand<object> DeleteClassCommand { get; set; }

        public async void DeleteClass(Object o)
        {
            bool result = false;

            if (SelectedClass.StudentsList.Count != 0)
            {
                var okornot = MessageBox.Show("Du kan ikke slette denne klasse, idet den har elever knyttet til sig." +
                                              "du skal derfor først tilknytte en ny klasse til dine elever i denne klasse.\n" +
                                              "Et nyt view vil åbnes, hvis du trykker ok.", "Sletning",
                    MessageBoxButton.OKCancel);

                if (okornot == MessageBoxResult.OK)
                {
                    DeleteView deleteView = new DeleteView(SelectedClass);
                    deleteView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    deleteView.ShowDialog();
                    deleteView.Closing += deleteView_Closing;
                    GetClasses();
                }
            }

            else if (SelectedClass.StudentsList.Count == 0)
            {
                var messageboxResult = MessageBox.Show("Ønsker du at slette klassen: " + SelectedClass.Name + "?", "Sletning", MessageBoxButton.YesNo);
                if (messageboxResult == MessageBoxResult.Yes)
                {
                    result = await BusinessLogic.Instance.DeleteClass(SelectedClass.Id);
                }
            }

            if (result)
            {
                MessageBox.Show("Klassen blev fjernet!");
                GetClasses();
            }

        }

        void deleteView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }


        private async void DeleteTeacher()
        {
            TeacherEx teacherExss = SelectedUser as TeacherEx; //interresant. Alle personer kan findes ved at typecast fra user.

            //  TeacherEx teacherExss = ObjectHolder.Instance.TeacherList.FirstOrDefault(te => te.Id == selectedUser.Id);

            if (teacherExss.ClassList.Count != 0)
            {
                var okornot = MessageBox.Show("Du kan ikke slette denne underviser, idet den har elever knyttet til sig." +
                                         "du skal derfor først tilknytte en ny klasse til dine elever i denne klasse.\n" +
                                         "Et nyt view vil åbnes, hvis du trykker ok.", "Sletning",
               MessageBoxButton.OKCancel);

                if (okornot == MessageBoxResult.OK)
                {
                    DeleteView deleteView = new DeleteView(null, teacherExss);
                    deleteView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    deleteView.ShowDialog();
                    deleteView.Closing += deleteView_Closing;
                }
            }
            else if (teacherExss.ClassList.Count == 0)
            {
                AreYouSureYouWantToDeleteUser(SelectedUser.Userrole);
            }

            GetTeachers();
            await GetClasses();
        }


        private async void AreYouSureYouWantToDeleteUser(int userRole)
        {
            var result = MessageBox.Show("Er du sikker på at du ønsker at slette: " + SelectedUser.Firstname + " " + SelectedUser.Lastname, "Sletning",
                     MessageBoxButton.YesNo,
                     MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Isloading = true;
                string resultMessage = await BusinessLogic.Instance.DeleteUserById(SelectedUser.Id);
                if (resultMessage == "")
                    MessageBox.Show("Sletning fuldført!");

                else
                    MessageBox.Show(resultMessage);

                Isloading = false;
            }

            if (userRole == (int)Enums.Userrole.Parent)
                GetParents();
            else if (userRole == (int)Enums.Userrole.Student)
            {
                await GetStudents();
                await GetClasses();
            }
        }

        public void DeletePerson(Object o)
        {

            if (SelectedUser.Userrole == (int)Enums.Userrole.Teacher || SelectedUser.Userrole == (int)Enums.Userrole.Principal || SelectedUser.Userrole == (int)Enums.Userrole.Substitute)
                DeleteTeacher();

            else
            {
                AreYouSureYouWantToDeleteUser(SelectedUser.Userrole);
            }
        }


        #endregion

        #region Methods

        private async void GetTeachers() // måske int userrole her. Så kan du hente de ansatte som er relevante
        {
            Isloading = true;
            TeacherList = await ServiceProxy.Instance.GetTeachers();
            ObjectHolder.Instance.TeacherList = TeacherList;
            Isloading = false;
            RaiseOnselectedPersonChanged("Underviser");
        }

        private async Task<bool> GetClasses()
        {
            Isloading = true;
            ClassList = await ServiceProxy.Instance.GetClasses();
            ObjectHolder.Instance.ClassList = ClassList;
            Isloading = false;

            return true;
            // RaiseOnselectedPersonChanged("Underviser");  ikke være nødvendig for klasse.
        }

        private async Task<bool> GetStudents()
        {
            Isloading = true;
            StudentList = await ServiceProxy.Instance.GetStudents();
            ObjectHolder.Instance.StudentList = StudentList;
            Isloading = false;
            RaiseOnselectedPersonChanged("Elev");
            return true;
        }

        private async void GetParents()
        {
            Isloading = true;
            ParentList = await ServiceProxy.Instance.GetParents();
            ObjectHolder.Instance.StudentList = StudentList;
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


        public async void ResetPasswordForSelectedUser(Object o)
        {
            bool result;

            result = await BusinessLogic.Instance.ResetPasswordForSelectedUser(SelectedUser);

            if (result)
            {
                MessageBox.Show("Password for bruger " + SelectedUser.Firstname + " blev ændret til 1234");
            }
        }


        #endregion



    }
}
