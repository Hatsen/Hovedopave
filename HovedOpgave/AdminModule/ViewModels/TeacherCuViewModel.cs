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
       private List<int> ranks;
       private Teacher currentTeacher;
       private int selectedRank;


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

       public List<int> Ranks
       {
           get { return ranks; }
           set
           {
               ranks = value;
               OnPropertyChanged("Rank");
           }
       }

       public int SelectedRank
       {
           get { return selectedRank; }
           set
           {
               selectedRank = value;
               OnPropertyChanged("SelectedRank");
           }
       }

       #endregion

       #region Commands
       public DelegateCommand<object> ConfirmCommand { get; set; }

       #endregion

       #region CommandMethods


       public async void Confirm(Object o)
       {
           bool success;

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
               teacher.Userrole = 1;

               success = await BusinessLogic.Instance.CreateTeacher(teacher);

               if (success)
               {
                   // kast et event og sig han blev oprettet.
               }
           }

           else if (Viewstate==Enums.ViewState.Edit) // for next week! 
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
