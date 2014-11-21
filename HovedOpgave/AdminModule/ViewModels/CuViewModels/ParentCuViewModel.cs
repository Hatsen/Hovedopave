using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminModule.Webservice;
using Microsoft.Practices.Prism.Commands;
using System.Windows;

namespace AdminModule.ViewModels
{
    public class ParentCuViewModel : ViewModelBase
    {

        public ParentCuViewModel()
        {

            ObjectHolder.Instance.PropertyChanged += (sender, args) =>
            {
                OnPropertyChanged(args.PropertyName); // viewmodel lytter på objectholderen.

            }; // jeg er nødt til at lytte på objectholderen. Hvis jeg ikke gør dette kan jeg ikke få opdateret listen af klasser i comboboksen.


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

        public Action OnParentViewClose;
        public Enums.ViewState Viewstate; // bliver altid sat til Create til at starte med.
        //  public Enums.ViewState ViewstateObject; // bliver altid sat til Create til at starte med.

        #region PrivateMembers

        private string firstname;
        private string lastname;
        private string city;
        private string birthdate = "dd/mm-yyyy";
        private string address;
        private ParentEx currentParent;
        private bool isLoading;
        private int phonenumber;
        private List<Student> currentParentChildrenList; // the current parent children.
        private List<ClassEx> classList; // will be shown in combo
        private ClassEx selectedClass = null; // from combo
        private List<Student> childrenList; // will be shown in combo, but only the students who was selected from the class.
        private Student selectedChild; // from combo

        #endregion

        #region PublicMembers


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

        public ParentEx CurrentParent
        {
            get { return currentParent; }
            set
            {

                currentParent = value;
                Firstname = currentParent.Firstname;
                Lastname = currentParent.Lastname;
                City = currentParent.City;
                Address = currentParent.Address;
                Birthdate = currentParent.Birthdate;
                Phonenumber = currentParent.Phonenumber;
                ChildrenList = currentParent.ChildrenList;


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

        public bool Isloading
        {
            get { return isLoading; }
            set
            {
                isLoading = value;
                OnPropertyChanged("Isloading");
            }
        }


        public List<Student> CurrentParentChildrenList
        {
            get { return currentParentChildrenList; }
            set
            {
                currentParentChildrenList = value;
                OnPropertyChanged("CurrentParentChildrenList");
            }
        }



        public List<ClassEx> ClassList
        {
            get { return ObjectHolder.Instance.ClassList; }

            set
            {
                classList = value;
                OnPropertyChanged("ClassList");
            }
        }


        public List<Student> ChildrenList
        {
            get { return childrenList; }
            set
            {
                childrenList = value;
                OnPropertyChanged("ChildrenList");
            }
        }


        public ClassEx SelectedClass
        {
            get { return selectedClass; }
            set
            {
                if (value != null)
                {
                    selectedClass = value;
                    ChildrenList = value.StudentsList;
                    OnPropertyChanged("SelectedClass");
                }

            }
        }


        public Student SelectedChild
        {
            get { return selectedChild; }
            set
            {
                selectedChild = value;
                OnPropertyChanged("SelectedChild");
            }
        }



        #endregion

        #region Commands
        public DelegateCommand<object> ConfirmCommand { get; set; }

        public DelegateCommand<object> CancelCommand { get; set; }

        #endregion

        #region CommandMethods


        public async void Confirm(Object o)
        {
            bool success = false;

            // vurder ud fra viewstate om der skal oprettes en user deraf dets username password mm. 
            // eller om der skal oprettes en user.

            // her skal der tjekkes på hvad type objektet er. 

            if (Viewstate == Enums.ViewState.Create)
            {
                ParentEx Parent = new ParentEx();
                Parent.Firstname = firstname;
                Parent.Lastname = lastname;
                Parent.City = city;
                Parent.Birthdate = birthdate;
                Parent.Address = address;
                Parent.Userrole = (int)Enums.Userrole.Parent;
                Parent.Phonenumber = phonenumber;

                success = await BusinessLogic.Instance.CreateParent(Parent);

            }

            else if (Viewstate == Enums.ViewState.Edit) // for next week! 
            {
                // her vil det ikke være nødvendigt at oprette password, id og username.
                //  BusinessLogic.Instance.UpdateParent(CurrentParent);

                CurrentParent.Firstname = firstname;
                CurrentParent.Lastname = lastname;
                CurrentParent.City = city;
                CurrentParent.Birthdate = birthdate;
                CurrentParent.Address = address;
                CurrentParent.Phonenumber = phonenumber;
                success = await BusinessLogic.Instance.UpdateParent(CurrentParent);
            }


            Isloading = false;
            MessageBox.Show(success
               ? "Forældre er oprettet/opdateret! Vinduet lukkes."
               : "Noget gik galt. Underviseren er ikke blevet oprettet/opdateret. Vinduet lukkes.");

            OnParentViewClose();
            //tjek med id.findes id allerede på user skal der ikke genereres username eller password.

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


        public void Cancel(Object o)
        {

            RaiseOnParentViewClose();
        }

        #endregion





        #region Methods


        private void RaiseOnParentViewClose()
        {
            if (OnParentViewClose != null)
            {
                OnParentViewClose();
            }

        }



        #endregion




    }
}
