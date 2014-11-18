using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AdminModule.Webservice;
using Microsoft.Practices.Prism.Commands;

namespace AdminModule.ViewModels.DeleteViewModels
{
    public class DeleteViewModel : ViewModelBase
    {


        public DeleteViewModel()
        {

            ConfirmCommand = new DelegateCommand<object>(Confirm, IsEnable);


        }


        public Action OnDeleteViewClose;
        //  public Enums.ViewState Viewstate; // bliver altid sat til Create til at starte med.
        //  public Enums.ViewState ViewstateObject; // bliver altid sat til Create til at starte med.

        #region PrivateMembers

        private List<ClassEx> listofClassExs = new List<ClassEx>();
        private ClassEx currentClass;
        private ClassEx selectedClassEx;
        private bool isLoading;

        #endregion

        #region PublicMembers


        public List<ClassEx> ListofClassEx // den selecterede klasse fra mainview. (den man ønsker at slette)
        {
            get { return listofClassExs; }
            set
            {

                listofClassExs = value;
                OnPropertyChanged("ListofClassEx");
            }
        }


        public ClassEx CurrentClass // den selecterede klasse fra mainview. (den man ønsker at slette)
        {
            get { return currentClass; }
            set
            {
                currentClass = value;
                ListofClassEx = ObjectHolder.Instance.ClassList;
                ListofClassEx.Remove(CurrentClass);// fordi du er igang med at slette den selecterede klasse.

            }
        }

        public ClassEx SelectedClassEx // den selecterede klasse fra mainview. (den man ønsker at slette)
        {
            get { return selectedClassEx; }
            set
            {
                selectedClassEx = value;
                OnPropertyChanged("SelectedClassEx");
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



            Isloading = false;
            MessageBox.Show(success
                ? "Sletning er fuldført! Vinduet lukkes."
                : "Noget gik galt. Sletningen kunne ikke fuldføres.");

            OnDeleteViewClose();
            //tjek med id.findes id allerede på user skal der ikke genereres username eller password.

        }


        public bool IsEnable(Object o)
        {
            // validerer om alle felter er blevet udfyldt.
            /*   bool enable = true;
               if (string.IsNullOrEmpty(Firstname) || string.IsNullOrEmpty(Lastname) || string.IsNullOrEmpty(City) ||
                   string.IsNullOrEmpty(Birthdate) || string.IsNullOrEmpty(Address))
               {
                   enable = false;
               }


               */

            bool mayConfirm = false;

            if (CurrentClass.StudentsList.Count == 0 || CurrentClass.StudentsList == null)
            {
                mayConfirm = true;
            }

            return mayConfirm;
        }


        public void Cancel(Object o)
        {
            RaiseOnDeleteViewClose();
        }

        #endregion




        #region Methods


        private void RaiseOnDeleteViewClose()
        {
            if (OnDeleteViewClose != null)
            {
                OnDeleteViewClose();
            }

        }

        #endregion


    }
}
