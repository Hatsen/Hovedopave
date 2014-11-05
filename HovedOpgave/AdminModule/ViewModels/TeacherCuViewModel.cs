using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
           ConfirmCommand = new DelegateCommand<object>(Confirm);

       }

       public Enums.ViewState Viewstate; // bliver altid sat til Create til at starte med.

       #region PrivateMembers

       private string firstname;
       private string lastname;
       private string city;
       private string birthdate;
       private string address;
       private int rank;
       private Teacher currentTeacher;

       #endregion

       #region PublicMembers


       public Teacher CurrentTeacher
       {
           get { return currentTeacher; }
           set
           {
               currentTeacher = value ?? new Teacher(); // hvis value er null bliver den sat til en ny. Burde ikke blive ramt hvis der ikke allerede er en currentTeacher.

               Firstname = currentTeacher.Firstname;
               Lastname = currentTeacher.Lastname;

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
           set { city = value; }
       }

       public string Birthdate
       {
           get { return birthdate; }
           set { birthdate = value; }
       }

       public string Address
       {
           get { return address; }
           set { address = value; }
       }

       public int Rank
       {
           get { return rank; }
           set { rank = value; }
       }

       #endregion

       #region Commands
       public DelegateCommand<object> ConfirmCommand { get; set; }

       #endregion

       #region CommandMethods


       public void Confirm(Object o)
       {

           // vurder ud fra viewstate om der skal oprettes en user deraf dets username password mm. 
           // eller om der skal oprettes en user.

           if (Viewstate==Enums.ViewState.Create)
           {

               Teacher teacher = new Teacher();
               teacher.Firstname = firstname;
               teacher.Lastname = lastname;
               teacher.City = city;
               teacher.Birthdate = birthdate;
               teacher.Address = address;
               teacher.Rank = rank;

               BusinessLogic.Instance.CreateTeacher(teacher);
           }

           else if (Viewstate==Enums.ViewState.Edit)
           {
               // her vil det ikke være nødvendigt at oprette password, id og username.
               BusinessLogic.Instance.UpdateTeacher(CurrentTeacher);

           }
        




           //tjek med id.findes id allerede på user skal der ikke genereres username eller password.
           
       }


       public bool IsEnable(Object o)
       {
           return false;
       }

       #endregion





       #region Methods



       #endregion



    }
}
