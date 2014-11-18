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
    public class StudentCuViewModel : ViewModelBase
    {
        public StudentCuViewModel()
        {


            ObjectHolder.Instance.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "CurrentStudent") // bliver ramt når den er ændret i teacherlist på objetholder. er nødt til at gøre dette da properien currentclass ikke vil blive ramt i setteren.
                {
                    SetTheClassInCombobox();
                }
                OnPropertyChanged(args.PropertyName); // viewmodel lytter på objectholderen.

            };


            if (ObjectHolder.Instance.ClassList != null)
            {
                ClassList = ObjectHolder.Instance.ClassList;
            }
            else
            {
                ObjectHolder.Instance.GetClasses();
            }


            ConfirmCommand = new DelegateCommand<object>(Confirm, IsEnable);
            CancelCommand = new DelegateCommand<object>(Cancel);

        }

        public Action OnStudentViewClose;
        public Enums.ViewState Viewstate; // bliver altid sat til Create til at starte med.
        //  public Enums.ViewState ViewstateObject; // bliver altid sat til Create til at starte med.

        #region PrivateMembers

        private string firstname;
        private string lastname;
        private string city;
        private string birthdate;
        private string address;
        private int fkClassId;
        private Student currentStudent;
        //    private List<Class> classes;
        private int phonenumber;
        private Class selectedClass;
        private List<ClassEx> classList;


        #endregion

        #region PublicMembers


        public Student CurrentStudent
        {
            get { return currentStudent; }
            set
            {
                // currentStudent = value ?? new Student(); // hvis value er null bliver den sat til en ny. Burde ikke blive ramt hvis der ikke allerede er en currentStudent.

                currentStudent = value;

                if (currentStudent != null)
                {
                    Firstname = currentStudent.Firstname;
                    Lastname = currentStudent.Lastname;
                    City = currentStudent.City;
                    Address = currentStudent.Address;
                    Birthdate = currentStudent.Birthdate;
                    Phonenumber = currentStudent.Phonenumber;
                    // FkClassId = currentStudent.FkClassid.ToString(); // hardcoded
                    FkClassId = currentStudent.FkClassid;
                }

            }
        }


        public string Firstname
        {
            get { return firstname; }
            set
            {
                firstname = value;
                OnPropertyChanged("Firstname");
            }
        }

        public string Lastname
        {
            get { return lastname; }
            set
            {
                lastname = value;
                OnPropertyChanged("Lastname");
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }

        public string Birthdate
        {
            get { return birthdate; }
            set
            {
                birthdate = value;
                OnPropertyChanged("Birthdate");
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }


        public int FkClassId
        {
            get { return fkClassId; }
            set
            {
                fkClassId = value;
                OnPropertyChanged("FkClassId");
            }
        }


        public int Phonenumber
        {
            get { return phonenumber; }
            set
            {
                phonenumber = value;
                OnPropertyChanged("Phonenumber");
                ConfirmCommand.RaiseCanExecuteChanged();
            }
        }

        public List<ClassEx> ClassList
        {
            get { return ObjectHolder.Instance.ClassList; }
            set
            {
                ObjectHolder.Instance.ClassList = value;
                OnPropertyChanged("ClassList");
               // ConfirmCommand.RaiseCanExecuteChanged(); den giver et null problem hvis du trykker opret elev og derefter trykker annuller og så igen opret elev??
            }
        }

        public Class SelectedClass
        {
            get { return selectedClass; }
            set
            {
                selectedClass = value;
                OnPropertyChanged("SelectedClass");
                ConfirmCommand.RaiseCanExecuteChanged();
            }
        }



        #endregion

        #region Commands
        public DelegateCommand<object> ConfirmCommand { get; set; }
        public DelegateCommand<object> CancelCommand { get; set; }

        #endregion

        #region CommandMethods

        public void Cancel(Object o)
        {
            RaiseOnStudentViewClose();

        }

        public async void Confirm(Object o)
        {
            bool success;

            // vurder ud fra viewstate om der skal oprettes en user deraf dets username password mm. 
            // eller om der skal oprettes en user.

            // her skal der tjekkes på hvad type objektet er. 

            if (Viewstate == Enums.ViewState.Create)
            {
                Student student = new Student();
                student.Firstname = firstname;
                student.Lastname = lastname;
                student.City = city;
                student.Birthdate = birthdate;
                student.Address = address;
                student.Userrole = (int)Enums.Userrole.Student;
                student.Phonenumber = phonenumber;
                student.FkClassid = SelectedClass.Id;

                // eleven skal knyttes til nogle forældre.

                success = await BusinessLogic.Instance.CreateStudent(student);

                MessageBox.Show(success
                             ? "Elev er oprettet/opdateret! Vinduet lukkes."
                             : "Noget gik galt. Eleven er ikke blevet oprettet/opdateret. Vinduet lukkes.");

                OnStudentViewClose();
            }

            else if (Viewstate == Enums.ViewState.Edit) // for next week! 
            {
                // her vil det ikke være nødvendigt at oprette password, id og username.
                 BusinessLogic.Instance.UpdateStudent(CurrentStudent);

            }





            //tjek med id.findes id allerede på user skal der ikke genereres username eller password.

        }


        public bool IsEnable(Object o)
        {
            // validerer om alle felter er blevet udfyldt.
            bool enable = true;
            if (string.IsNullOrEmpty(Firstname) || string.IsNullOrEmpty(Lastname) || string.IsNullOrEmpty(City) || string.IsNullOrEmpty(Birthdate) || string.IsNullOrEmpty(Address) || SelectedClass ==null)
            {
                enable = false;
            }



            return enable;
        }

        #endregion





        #region Methods



        private void RaiseOnStudentViewClose()
        {
            if (OnStudentViewClose != null)
            {
                OnStudentViewClose();
            }

        }


        private void SetTheClassInCombobox()
        {
            if (ObjectHolder.Instance.ClassList != null&&currentStudent!=null)
            {
                SelectedClass = ClassList.FirstOrDefault(theclass => theclass.Id == currentStudent.FkClassid);
            }
        }

        #endregion









    }
}
