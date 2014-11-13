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
    public class ClassCuViewModel : ViewModelBase
    {
        public ClassCuViewModel()
        {

           ObjectHolder.Instance.PropertyChanged += (sender, args) => OnPropertyChanged(args.PropertyName); // viewmodel lytter på objectholderen.

            if (ObjectHolder.Instance.TeacherList!=null)
            {
                TeacherList = ObjectHolder.Instance.TeacherList;
            }
            else
            {
                ObjectHolder.Instance.GetTeachers();
            }
            // hent teacherlist. hvis den allerede er i mainvindue er der ingen grund til 
            // at hente fra servicen. Så bare hent fra objektholder. ellers må du hente.

            ConfirmCommand = new DelegateCommand<object>(Confirm, IsEnable);
            CancelCommand = new DelegateCommand<object>(Cancel);
        }

        public Action OnClassViewClose;
        public Enums.ViewState Viewstate; // bliver altid sat til Create til at starte med.
        //  public Enums.ViewState ViewstateObject; // bliver altid sat til Create til at starte med.

        #region PrivateMembers


        private Class currentClass;
        private bool isLoading;
        private string className;
        private List<Teacher> teacherList;
        private Teacher selectedTeacher;
      
        #endregion

        #region PublicMembers


        public Class CurrentClass
        {
            get { return currentClass; }
            set
            {
                currentClass = value;
                ClassName = currentClass.Name;
                
               // tjek om teacher findes i listen. Listen skulle gerne være loaded fra start...
                if (TeacherList!=null||TeacherList.Count!=0) // den er fyldt
                {
                    SelectedTeacher= TeacherList.FirstOrDefault(fi => fi.Id == currentClass.Fkteacherid);
                }
            }
        }


        public string ClassName
        {
            get { return className; }
            set
            {
                className = value;
                OnPropertyChanged("ClassName"); // lige her er det nødvendigt at sætte da propertien ikke findes i objectholderen.
                ConfirmCommand.RaiseCanExecuteChanged();
            }
        }



        public Teacher SelectedTeacher
        {
            get { return selectedTeacher; }
            set
            {
                selectedTeacher = value;
                OnPropertyChanged("SelectedTeacher");
                ConfirmCommand.RaiseCanExecuteChanged();
            }
        }

        public List<Teacher> TeacherList
        {
            
            get { return ObjectHolder.Instance.TeacherList; }

            set
            {
                teacherList = value;
                OnPropertyChanged("TeacherList");
            }

        }

        public bool Isloading
        {
            get { return ObjectHolder.Instance.Isloading; }
            set
            {
                ObjectHolder.Instance.Isloading = value;
              //  OnPropertyChanged("Isloading"); sættes i objectholder.
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
                Class theClass = new Class();
                /* Parent.Firstname = firstname;
                 Parent.Lastname = lastname;
                 Parent.City = city;
                 Parent.Birthdate = birthdate;
                 Parent.Address = address;
                 Parent.Userrole = (int)Enums.Userrole.Parent;
                 Parent.Phonenumber = phonenumber;*/

                success = await BusinessLogic.Instance.CreateClass(theClass);

            }

            else if (Viewstate == Enums.ViewState.Edit) // for next week! 
            {
                // her vil det ikke være nødvendigt at oprette password, id og username.
                //  BusinessLogic.Instance.UpdateParent(CurrentParent);

               /* CurrentParent.Firstname = firstname;
                CurrentParent.Lastname = lastname;
                CurrentParent.City = city;
                CurrentParent.Birthdate = birthdate;
                CurrentParent.Address = address;
                CurrentParent.Phonenumber = phonenumber;*/
                success = await BusinessLogic.Instance.UpdateClass(currentClass);
            }


            Isloading = false;
            MessageBox.Show(success
               ? "Forældre er oprettet/opdateret! Vinduet lukkes."
               : "Noget gik galt. Underviseren er ikke blevet oprettet/opdateret. Vinduet lukkes.");

            OnClassViewClose();
            //tjek med id.findes id allerede på user skal der ikke genereres username eller password.

        }


       public bool IsEnable(Object o)
        {
            // validerer om alle felter er blevet udfyldt.
            bool enable = true;
            if (SelectedTeacher==null || string.IsNullOrEmpty(ClassName))
            {
                enable = false;
            }
            return enable;
        }
       

        public void Cancel(Object o)
        {

            RaiseOnClassViewClose();
        }

        #endregion



        #region Methods


        private async void GetTeachers()
        {
           /* Isloading = true;
            TeacherList = await ServiceProxy.Instance.GetTeachers();
            Isloading = false;*/

            ObjectHolder.Instance.TeacherList = await ServiceProxy.Instance.GetTeachers();

        }



        private void RaiseOnClassViewClose()
        {
            if (OnClassViewClose != null)
            {
                OnClassViewClose();
            }

        }



        #endregion




    }
}



