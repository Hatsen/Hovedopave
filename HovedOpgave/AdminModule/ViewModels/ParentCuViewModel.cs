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
            ConfirmCommand = new DelegateCommand<object>(Confirm,IsEnable);
            CancelCommand = new DelegateCommand<object>(Cancel);
        }

        public Action OnParentViewClose;
        public Enums.ViewState Viewstate; // bliver altid sat til Create til at starte med.
        //  public Enums.ViewState ViewstateObject; // bliver altid sat til Create til at starte med.

        #region PrivateMembers

        private string firstname;
        private string lastname;
        private string city;
        private string birthdate;
        private string address;
        private Parent currentParent;
        private bool isLoading;
        private int phonenumber;



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

        public Parent CurrentParent
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
                Parent Parent = new Parent();
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
            
            RaiseOnProjectViewClose();
        }

        #endregion





        #region Methods


        private void RaiseOnProjectViewClose()
        {
            if (OnParentViewClose != null)
            {
                OnParentViewClose();
            }

        }



        #endregion




    }
}
