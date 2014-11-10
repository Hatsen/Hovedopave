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
                // rank mangler for teacher.

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
                // vi mangler rank på teacher.

                teacher.Userrole = 1;

                success = await BusinessLogic.Instance.CreateTeacher(teacher);

                MessageBox.Show(success
                    ? "Underviser er oprettet! Vinduet lukkes."
                    : "Noget gik galt. Underviseren er ikke blevet oprettet. Vinduet lukkes.");

                OnTeacherViewClose();
            }

            else if (Viewstate == Enums.ViewState.Edit) // for next week! 
            {
                // her vil det ikke være nødvendigt at oprette password, id og username.
                BusinessLogic.Instance.UpdateTeacher(CurrentTeacher);

            }


            //tjek med id.findes id allerede på user skal der ikke genereres username eller password.

            Isloading = false;
        }

        public bool IsEnable(Object o)
        {
            // validerer om alle felter er blevet udfyldt.
            bool enable = true;
            if (string.IsNullOrEmpty(Firstname) || string.IsNullOrEmpty(Lastname) || string.IsNullOrEmpty(City) || string.IsNullOrEmpty(Birthdate) || string.IsNullOrEmpty(Address))
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
