using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using AdminModule.Views;
using AdminModule.Views.DeleteView;
using AdminModule.Webservice;
using Microsoft.Practices.Prism.Commands;
using System.Collections.ObjectModel;

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
            CreateParentCommand = new DelegateCommand<object>(CreateParent);
            CreateStudentCommand = new DelegateCommand<object>(CreateStudent);
            CreateClassCommand = new DelegateCommand<object>(CreateClass);
            GetClassesCommand = new DelegateCommand<object>(GetClasses);
            EditClassCommand = new DelegateCommand<object>(EditClass, MayiEditClass);
            DeleteUserCommand = new DelegateCommand<object>(DeletePerson, MayiEditPerson);
            DeleteClassCommand = new DelegateCommand<object>(DeleteClass, MayiEditClass);
            ResetPasswordCommand = new DelegateCommand<object>(ResetPasswordForSelectedUser, MayiEditPerson);
            SeeAssociationsCommand = new DelegateCommand<object>(SeeAssociations);
            ConfirmEnrollmentCommand = new DelegateCommand<object>(ConfirmEnrollment, MayConfirmEnrollment);

            List<string> listofpersons = new List<string>();
            listofpersons.Add("Underviser");
            listofpersons.Add("Elev");
            listofpersons.Add("Forældre");
            PersonStringList = listofpersons;

            SetTimer();


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
        private List<EnrollmentEx> enrollmentList;
        private EnrollmentEx selectedEnrollment;

        System.Timers.Timer _timer = new System.Timers.Timer();

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
                if (SelectedClass != null)
                {
                    SelectedClass = null;
                }

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
                if (SelectedUser != null)
                {
                    SelectedUser = null;
                }

                selectedClass = value;
                OnPropertyChanged("SelectedClass");
                EditClassCommand.RaiseCanExecuteChanged();
                DeleteClassCommand.RaiseCanExecuteChanged();
                ConfirmEnrollmentCommand.RaiseCanExecuteChanged();
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

                    GetTeacherCalledFromPropery();


                else if (selectedStringPerson == "Elev")
                {
                    RefreshStudentsAndClasses();
                }
                else if (selectedStringPerson == "Forældre")
                {
                    GetParentsCalledFromPropery();
                }

                //    RaiseOnselectedPersonChanged(selectedStringPerson); må ikke bruges her da der ikke er blevet tilføjet noget til listen endnu.
                OnPropertyChanged("SelectedStringPerson");
            }
        }


        public List<EnrollmentEx> EnrollmentList
        {
            get
            {
                return enrollmentList;
            }
            set
            {
                enrollmentList = value;
                OnPropertyChanged("EnrollmentList");
            }
        }


        public EnrollmentEx SelectedEnrollment
        {
            get
            {
                return selectedEnrollment;
            }
            set
            {

                selectedEnrollment = value;
                OnPropertyChanged("SelectedEnrollment");
                if (selectedEnrollment != null)
                    _timer.Stop();
                else
                    _timer.Start();

                ConfirmEnrollmentCommand.RaiseCanExecuteChanged();
            }
        }


        #endregion


        private async void RefreshStudentsAndClasses()
        {
            await GetStudents();
            await GetClasses();

        }

        #region Commands



        public DelegateCommand<object> SeeAssociationsCommand { get; set; }


        public void SeeAssociations(Object o)
        {
            if (SelectedUser != null)
            {
                if (SelectedUser.Userrole == (int)Enums.Userrole.Parent)
                {
                    ParentEx parent = (ParentEx)SelectedUser;
                    MessageBox.Show(BusinessLogic.Instance.GetAssociatedChildren(parent));
                }
                else if (SelectedUser.Userrole == (int)Enums.Userrole.Teacher ||
                         SelectedUser.Userrole == (int)Enums.Userrole.Principal ||
                         SelectedUser.Userrole == (int)Enums.Userrole.Substitute)
                {
                    MessageBox.Show(BusinessLogic.Instance.GetAssociatedClasses(selectedUser));
                }

                else
                {
                    MessageBox.Show("Denne bruger har ikke mulighed for at have tilknyttede børn på sig. Vælg istedet en forældre!");
                }
            }
            else if (SelectedClass != null)
            {
                MessageBox.Show(BusinessLogic.Instance.GetAssociatedChildren(null, SelectedClass));
            }
            else if (SelectedClass == null && SelectedUser == null)
            {
                MessageBox.Show("Du skal først vælge en forældre eller klasse i listen før du kan se tilknytninger.!");
            }
        }

        public DelegateCommand<object> ResetPasswordCommand { get; set; }



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

            Views.ClassCuView cview = new Views.ClassCuView();
            cview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            cview.ShowDialog();
            cview.Closing += cview_Closing;
            await GetTeachers();
            await GetClasses();
        }

        void cview_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        public DelegateCommand<object> EditClassCommand { get; set; }

        public async void EditClass(Object o)
        {
            ClassCuView cview = new ClassCuView(SelectedClass);
            cview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            cview.ShowDialog();
            cview.Closing += cview_Closing;
            await GetTeachers();
            await GetClasses();
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

        public async void GetClasses(Object o)
        {
            await GetTeachers();
            await GetClasses();//overloading.
            SelectedStringPerson = "Underviser";

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
                    await GetClasses();
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
                await GetClasses();
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
                await AreYouSureYouWantToDeleteUser(SelectedUser.Userrole); // vigtigt fordi den ellers g[r ind og lukker forbindelsen for sletningen af underviseren, hvis der ikke er tilknyttet born til ham.
            }

            await GetTeachers();
            await GetClasses();
        }


        private async Task<bool> AreYouSureYouWantToDeleteUser(int userRole)
        {

            var result = MessageBox.Show("Er du sikker på at du ønsker at slette: " + SelectedUser.Firstname + " " + SelectedUser.Lastname, "Sletning",
                     MessageBoxButton.YesNo,
                     MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Isloading = true;
                string resultMessage = await BusinessLogic.Instance.DeleteUserById(SelectedUser.Id); // hvis det er en parent skal du tjekke om han har oprettet indmeldelser. De skal slettes fra systemet forst.
                if (resultMessage == "")
                    MessageBox.Show("Sletning fuldført!");

                else
                    MessageBox.Show(resultMessage);

                Isloading = false;
            }

            if (userRole == (int)Enums.Userrole.Parent)
                await GetParents();
            else if (userRole == (int)Enums.Userrole.Student)
            {
                await GetStudents();
                await GetClasses();
            }

            return true;
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



        public DelegateCommand<object> ConfirmEnrollmentCommand { get; set; }



        public async void ConfirmEnrollment(Object o)
        {
            string[] succesList = new string[SelectedEnrollment.ParentList.Count];
            int i = 0;
            bool success = await BusinessLogic.Instance.CreateStudent(SelectedEnrollment.ChildFirstname, SelectedEnrollment.ChildLastname, SelectedEnrollment.ChildCity, SelectedEnrollment.ChildAddress, SelectedEnrollment.ChildBirthdate, SelectedEnrollment.ChildPhonenumber, "empty", SelectedClass.Id, SelectedEnrollment);

            if (success)
            {
                foreach (ParentEx parent in SelectedEnrollment.ParentList)
                {
                    succesList[i] = BusinessLogic.Instance.SendEmail(parent.Email, "Indmeldelse bekræftiget!", "Hej, " + parent.Firstname + "!/nDit barn " + SelectedEnrollment.ChildFirstname + " " + SelectedEnrollment.ChildLastname + "er blevet oprettet " +
                        "i vores system og er tilføjet klassen " + SelectedClass.Name + " med klasselæren " + SelectedClass.AssociatedTeacher + " vi glæder os til at se dig!/nVenlig hilsen Birkealle.");// egentligt ret kritisk, men da vores losning nok ikke er optimal ser vi bort fra at lave en aktiv/passiv paa enrollment. Hvis email fejler kan vi ikke finde frem til indmeldelsen.

                    if (succesList[i] != "Succes")
                            MessageBox.Show("Noget gik galt under transmission af email til forældren "+parent.Firstname+". Ring venligst til forældren og fortæl af barnet er oprettet i systemet!/nNummeret er:"+parent.Phonenumber);
                  
                    
                    i++;
                }

             
            }
            else
                MessageBox.Show("Kunne ikke oprette indmeldelse! Kontakt support.");

          if(succesList.All(obj=> obj =="Succes"))
                MessageBox.Show("Indmeldelse bekræftiget!");
        

        }

        private bool MayConfirmEnrollment(Object o)
        {
            bool boolen = false;

            if (selectedClass != null && selectedEnrollment != null)
                boolen = true;

            return boolen;
        }



        #endregion

        #region Methods

        private async void GetTeacherCalledFromPropery()
        {
            await GetTeachers();

        }


        private async void GetParentsCalledFromPropery()
        {
            await GetParents();

        }


        private async Task<bool> GetTeachers() // måske int userrole her. Så kan du hente de ansatte som er relevante
        {
            Isloading = true;
            TeacherList = await ServiceProxy.Instance.GetTeachers();
            ObjectHolder.Instance.TeacherList = TeacherList;
            Isloading = false;
            RaiseOnselectedPersonChanged("Underviser");
            return true;
        }

        private async Task<bool> GetClasses()
        {
            Isloading = true;
            ClassList = await ServiceProxy.Instance.GetClasses();
            ObjectHolder.Instance.ClassList = ClassList;
            Isloading = false;

            return true;
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

        private async Task<bool> GetParents()
        {
            Isloading = true;
            ParentList = await ServiceProxy.Instance.GetParents();
            ObjectHolder.Instance.StudentList = StudentList;
            Isloading = false;
            RaiseOnselectedPersonChanged("Forældre");
            return true;
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


        public void SetTimer()
        {
            _timer.Elapsed += _timer_Elapsed;
            _timer.Interval = 10000;
            _timer.Enabled = true;

        }

        async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            EnrollmentList = await ServiceProxy.Instance.GetEnrollments();
        }


        #endregion



    }
}
