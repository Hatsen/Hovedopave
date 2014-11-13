using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using AdminModule.Webservice;
using Microsoft.Practices.Prism.Commands;

namespace AdminModule.ViewModels
{
    public class TeacherCuViewModel : ViewModelBase
    {
        public TeacherCuViewModel()
        {
            ConfirmCommand = new DelegateCommand<object>(Confirm, IsEnable);
            CancelCommand = new DelegateCommand<object>(Cancel);

            if (ranks == null)
            {
                Ranks = new List<string>();
                Ranks.Add("Skoleleder"); Ranks.Add("Underviser"); Ranks.Add("Vikar");
            }
        }

        public Action OnTeacherViewClose;
        
        public Enums.ViewState Viewstate; // bliver altid sat til Create til at starte med.
        //  public Enums.ViewState ViewstateObject; // bliver altid sat til Create til at starte med.

        #region PrivateMembers

        private string firstname;
        private string lastname;
        private string city;
        private string birthdate;
        private string address;
        private List<string> ranks;
        private Teacher currentTeacher;
        private string selectedRank;

        private bool isLoading;
        private int phonenumber;


        #endregion

        #region PublicMembers


        public Teacher CurrentTeacher
        {
            get { return currentTeacher; }
            set
            {
                // currentTeacher = value ?? new Teacher(); // hvis value er null bliver den sat til en ny. Burde ikke blive ramt hvis der ikke allerede er en currentTeacher.

                currentTeacher = value;

                Firstname = currentTeacher.Firstname;
                Lastname = currentTeacher.Lastname;
                City = currentTeacher.City;
                Address = currentTeacher.Address;
                Birthdate = currentTeacher.Birthdate;
                Phonenumber = currentTeacher.Phonenumber;

                if (currentTeacher.Rank == (int)Enums.Rank.Principal) // lige her skal jeg kende til værdierne for enums
                {
                    SelectedRank = "Skoleleder";
                }
                else if (currentTeacher.Rank == (int)Enums.Rank.Teacher)
                {
                    SelectedRank = "Underviser";
                }
                else if (currentTeacher.Rank == (int)Enums.Rank.Substitute)
                {
                    SelectedRank = "Vikar";
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
                ConfirmCommand.RaiseCanExecuteChanged();
            }
        }

        public string Lastname
        {
            get { return lastname; }
            set
            {
                lastname = value;
                OnPropertyChanged("Lastname");
                ConfirmCommand.RaiseCanExecuteChanged();
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged("City");
                ConfirmCommand.RaiseCanExecuteChanged();
            }
        }

        public string Birthdate
        {
            get { return birthdate; }
            set
            {
                birthdate = value;
                OnPropertyChanged("Birthdate");
                ConfirmCommand.RaiseCanExecuteChanged();
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
                ConfirmCommand.RaiseCanExecuteChanged();
            }
        }

        public List<string> Ranks
        {
            get { return ranks; }
            set
            {
                ranks = value;
                // Ranks.Add(1); Ranks.Add(2);
                OnPropertyChanged("Ranks");

            }
        }

        public string SelectedRank
        {
            get { return selectedRank; }
            set
            {
                selectedRank = value;
                OnPropertyChanged("SelectedRank");
                ConfirmCommand.RaiseCanExecuteChanged();
            }
        }



        public bool Isloading
        {
            get { return isLoading; }
            set
            {
                isLoading = value;
                OnPropertyChanged("Isloading");
            }
        }

        public int Phonenumber
        {
            get { return phonenumber; }
            set
            {
                phonenumber = value;
                OnPropertyChanged("Phonenumber");
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
            Isloading = true;

            bool success = false;

            if (Viewstate == Enums.ViewState.Create)
            {
                Teacher teacher = new Teacher();
                teacher.Firstname = firstname;
                teacher.Lastname = lastname;
                teacher.City = city;
                teacher.Birthdate = birthdate;
                teacher.Address = address;
                if (selectedRank == "Underviser")
                    teacher.Rank = (int)Enums.Rank.Teacher;

                else if (selectedRank == "Vikar")
                    teacher.Rank = (int)Enums.Rank.Substitute;

                else if (selectedRank == "Skoleleder")
                    teacher.Rank = (int)Enums.Rank.Principal;

                teacher.Userrole = (int)Enums.Userrole.Teacher; // it's in the view of teacher meaning the userrole will be 1.
                teacher.Phonenumber = phonenumber;

                success = await BusinessLogic.Instance.CreateTeacher(teacher);
            }

            else if (Viewstate == Enums.ViewState.Edit) // for next week! 
            {
                // her vil det ikke være nødvendigt at oprette password, id og username.
                // der skal tjekkes på om værdierne i tekstboksene er blevet ændret.

                // sørg for at currentteacher kan være en ny instans. Så sparer du dette redudante udtryk.. saml attributterne der bliver sat til objektet.
                CurrentTeacher.Firstname = firstname;
                CurrentTeacher.Lastname = lastname;
                CurrentTeacher.City = city;
                CurrentTeacher.Birthdate = birthdate;
                CurrentTeacher.Address = address;
                if (selectedRank == "Underviser")
                    CurrentTeacher.Rank = (int)Enums.Rank.Teacher;

                else if (selectedRank == "Vikar")
                    CurrentTeacher.Rank = (int)Enums.Rank.Substitute;

                else if (selectedRank == "Skoleleder")
                    CurrentTeacher.Rank = (int)Enums.Rank.Principal;

                CurrentTeacher.Phonenumber = phonenumber;

                success = await BusinessLogic.Instance.UpdateTeacher(CurrentTeacher);

            }

            Isloading = false;
            MessageBox.Show(success
               ? "Underviser er oprettet/opdateret! Vinduet lukkes."
               : "Noget gik galt. Underviseren er ikke blevet oprettet/opdateret. Vinduet lukkes.");

            OnTeacherViewClose();
        }

        public bool IsEnable(Object o)
        {
            // validerer om alle felter er blevet udfyldt.
            bool enable = true;
            if (string.IsNullOrEmpty(Firstname) || string.IsNullOrEmpty(Lastname) || string.IsNullOrEmpty(City) || string.IsNullOrEmpty(Birthdate) || string.IsNullOrEmpty(Address)||string.IsNullOrEmpty(selectedRank))
            {
                enable = false;
            }


            return enable;
        }

        #endregion





        #region Methods

        private void RaiseOnProjectViewClose()
        {
            if (OnTeacherViewClose != null)
            {
                OnTeacherViewClose();
            }

        }


        #endregion



    }
}
