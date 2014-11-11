using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminModule.Views;
using AdminModule.Webservice;
using Microsoft.Practices.Prism.Commands;

namespace AdminModule.ViewModels
{
    public class StudentCuViewModel : ViewModelBase
    {
        public StudentCuViewModel()
        {
            ConfirmCommand = new DelegateCommand<object>(Confirm, IsEnable);
            CancelCommand = new DelegateCommand<object>(Cancel);

        }

        public Action OnProjectViewClose;
        public Enums.ViewState Viewstate; // bliver altid sat til Create til at starte med.
        //  public Enums.ViewState ViewstateObject; // bliver altid sat til Create til at starte med.

        #region PrivateMembers

        private string firstname;
        private string lastname;
        private string city;
        private string birthdate;
        private string address;
        private string fkClassId;
        private Student currentStudent;
    //    private List<Class> classes;


        #endregion

        #region PublicMembers


        public Student CurrentStudent
        {
            get { return currentStudent; }
            set
            {
                // currentStudent = value ?? new Student(); // hvis value er null bliver den sat til en ny. Burde ikke blive ramt hvis der ikke allerede er en currentStudent.

                currentStudent = value;

                Firstname = currentStudent.Firstname;
                Lastname = currentStudent.Lastname;
                City = currentStudent.City;
                Address = currentStudent.Address;
                Birthdate = currentStudent.Birthdate;
               // FkClassId = currentStudent.FkClassid.ToString(); // hardcoded
                FkClassId = "-1";

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


        public string FkClassId
        {
            get { return fkClassId; }
            set
            {
                fkClassId = value;
                OnPropertyChanged("FkClassId");
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
            RaiseOnProjectViewClose();

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
                student.FkClassid = 3;

                success = await BusinessLogic.Instance.CreateStudent(student);

                if (success)
                {
                    // kast et event og sig han blev oprettet.
                }
            }

            else if (Viewstate == Enums.ViewState.Edit) // for next week! 
            {
                // her vil det ikke være nødvendigt at oprette password, id og username.
                //  BusinessLogic.Instance.UpdateStudent(CurrentStudent);

            }





            //tjek med id.findes id allerede på user skal der ikke genereres username eller password.

        }


        public bool IsEnable(Object o)
        {
            // validerer om alle felter er blevet udfyldt.
            bool enable = true;
            if (string.IsNullOrEmpty(Firstname) || string.IsNullOrEmpty(Lastname) || string.IsNullOrEmpty(City) || string.IsNullOrEmpty(Birthdate) || string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(FkClassId))
            {
                enable = false;
            }



            return enable;
        }

        #endregion





        #region Methods



        private void RaiseOnProjectViewClose()
        {
            if (OnProjectViewClose != null)
            {
                OnProjectViewClose();
            }

        }

        #endregion









    }
}
