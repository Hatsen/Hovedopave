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
            ConfirmCommand = new DelegateCommand<object>(Confirm, MayConfirm);
            AssociateCommand = new DelegateCommand<object>(Associate, CanAssociate);
            CancelCommand = new DelegateCommand<object>(Cancel);

        }


        public Action OnDeleteViewClose;
        public Enums.ViewstateObject ViewstateObject;

        #region PrivateMembers

        private List<ClassEx> listofClassExs = new List<ClassEx>();
        private ClassEx currentClass; // is the incomming class
        private ClassEx selectedClassEx;// is the selected class in for example combobox.
        private ClassEx chosenClass;// the class selected from the listview.
        private List<ClassEx> listofRelatedClassesToTeacher = new List<ClassEx>();

        private TeacherEx selectedTeacherEx; // is the selected teacher in for example combobox.
        private bool isLoading;
        private TeacherEx currentTeacherEx; // is the incomming teacher
        private List<TeacherEx> listofTeacherExs = new List<TeacherEx>();


        public int goBackToFkTeacherId = -1;

        #endregion

        #region PublicMembers

        public ClassEx ChosenClass
        {
            get { return chosenClass; }
            set
            {
                chosenClass = value;
                AssociateCommand.RaiseCanExecuteChanged();
                ConfirmCommand.RaiseCanExecuteChanged();
                OnPropertyChanged("ChosenClass");
            }

        }

        public List<ClassEx> ListofRelatedClassesToTeacher // den selecterede klasse fra mainview. (den man ønsker at slette)
        {
            get { return listofRelatedClassesToTeacher; }
            set
            {
                listofRelatedClassesToTeacher = value;
                OnPropertyChanged("ListofRelatedClassesToTeacher");
            }
        }

        public List<ClassEx> ListofClassEx // den selecterede klasse fra mainview. (den man ønsker at slette)
        {
            get { return listofClassExs; }
            set
            {

                listofClassExs = value;
                OnPropertyChanged("ListofClassEx");
            }
        }

        public List<TeacherEx> ListofTeacherEx // den selecterede klasse fra mainview. (den man ønsker at slette)
        {
            get { return listofTeacherExs; }
            set
            {
                listofTeacherExs = value;
                OnPropertyChanged("ListofTeacherEx");
            }
        }

        public ClassEx CurrentClass // den selecterede klasse fra mainview. (den man ønsker at slette)
        {
            get { return currentClass; }
            set
            {
                currentClass = value;
                foreach (ClassEx classEx in ObjectHolder.Instance.ClassList)
                {
                    ListofClassEx.Add(classEx);
                }
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
                ConfirmCommand.RaiseCanExecuteChanged();
                AssociateCommand.RaiseCanExecuteChanged();
            }
        }

        public TeacherEx SelectedTeacherEx // den selecterede klasse fra mainview. (den man ønsker at slette)
        {
            get { return selectedTeacherEx; }
            set
            {
                selectedTeacherEx = value;
                OnPropertyChanged("SelectedTeacherEx");
                ConfirmCommand.RaiseCanExecuteChanged();
                AssociateCommand.RaiseCanExecuteChanged();
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

        public TeacherEx CurrentTeacherEx // den selecterede klasse fra mainview. (den man ønsker at slette)
        {
            get { return currentTeacherEx; }
            set
            {
                currentTeacherEx = value;
                // ListofTeacherEx = ObjectHolder.Instance.TeacherList;
                foreach (TeacherEx teacherEx in ObjectHolder.Instance.TeacherList)
                {
                    ListofTeacherEx.Add(teacherEx); // til comboboxen.
                }
                ListofTeacherEx.Remove(CurrentTeacherEx);// fordi du er igang med at slette den selecterede klasse.

                foreach (ClassEx classEx in value.ClassList)
                {
                    ListofRelatedClassesToTeacher.Add(classEx); // til datagrid
                }

                goBackToFkTeacherId = CurrentTeacherEx.Id; // til hvis aktøren annullerer.

            }
        }


        #endregion

        #region Commands

        public DelegateCommand<object> AssociateCommand { get; set; }

        public DelegateCommand<object> ConfirmCommand { get; set; }

        public DelegateCommand<object> CancelCommand { get; set; }

        #endregion

        #region CommandMethods

        public void Associate(Object o)
        {

            if (ViewstateObject == Enums.ViewstateObject.Teacher)
            {

                ListofClassEx.Remove(ChosenClass);
                ChosenClass.Fkteacherid = SelectedTeacherEx.Id;

               // ListofRelatedClassesToTeacher.Add(ChosenClass);
                ChosenClass = null;
            }



        }

        public bool CanAssociate(Object o)
        {

            bool mayConfirm = false;

            if (ViewstateObject == Enums.ViewstateObject.Class)
            {
                mayConfirm = CurrentClass.StudentsList.Count == 0 || CurrentClass.StudentsList == null || SelectedClassEx != null;
            }

            else if (ViewstateObject == Enums.ViewstateObject.Teacher)
            {
                mayConfirm = SelectedTeacherEx != null && ChosenClass != null;
            }

            return mayConfirm;
        }

        public async void Confirm(Object o)
        {
            bool success = false;
            Isloading = false;
            string successString = "";

            if (ViewstateObject == Enums.ViewstateObject.Class)
            {
                foreach (Student student in CurrentClass.StudentsList)
                {
                    student.FkClassid = SelectedClassEx.Id;
                    await BusinessLogic.Instance.UpdateStudent(student);
                }

                success = await BusinessLogic.Instance.DeleteClass(CurrentClass.Id);
            }

            else if (ViewstateObject == Enums.ViewstateObject.Teacher)
            {

                foreach (ClassEx classex in ListofRelatedClassesToTeacher)
                {
                    await BusinessLogic.Instance.UpdateClass(classex);
                }
                successString = await BusinessLogic.Instance.DeleteUserById(CurrentTeacherEx.Id);
                if (string.IsNullOrEmpty(successString))
                {
                    success = true;
                }
            }

            MessageBox.Show(success
                ? "Sletning er fuldført! Vinduet lukkes."
                : "Noget gik galt. Sletningen kunne ikke fuldføres.");

            // ObjectHolder.Instance.GetClasses();
            //ObjectHolder.Instance.GetTeachers();
            // ObjectHolder.Instance.GetTeachers();

            OnDeleteViewClose();
            //tjek med id.findes id allerede på user skal der ikke genereres username eller password.

        }

        public bool MayConfirm(Object o)
        {
            bool mayConfirm = false;

            if (ViewstateObject == Enums.ViewstateObject.Class)
            {
                mayConfirm = SelectedClassEx != null;
            }

            else if (ViewstateObject == Enums.ViewstateObject.Teacher)
            {
               // mayConfirm = SelectedTeacherEx != null && ChosenClass != null;

               /* if (ListofRelatedClassesToTeacher.All(obj => obj.Fkteacherid == CurrentTeacherEx.Id))
                    mayConfirm = true;*/

                int tmpint = 0;

                for (int i = 0; i<ListofRelatedClassesToTeacher.Count;i++)
                {
                    if (ListofRelatedClassesToTeacher[i].Fkteacherid != CurrentTeacherEx.Id)
                    {
                        tmpint++;
                        if (tmpint == listofRelatedClassesToTeacher.Count)
                        {
                            mayConfirm = true;
                        }
                    }

                }


            }

            return mayConfirm;
        }


        public void Cancel(Object o)
        {

            if (ViewstateObject == Enums.ViewstateObject.Teacher)
            {

                foreach (ClassEx classes in CurrentTeacherEx.ClassList)
                {
                    classes.Fkteacherid = goBackToFkTeacherId;
                }

            }


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
