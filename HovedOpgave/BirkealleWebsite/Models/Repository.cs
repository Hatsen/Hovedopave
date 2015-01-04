



/**
* Copyright (c) 2013 Lars Skaaning Jensen
*
* The terms of use for this and related files can be read in
* the fictional LICENSE file, which do not exist!
*/
/**
* Author: Lars Skaaning Jensen
* Location: Erhvervsakademiet Lillebælt, DAT12A
*/





using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BirkealleWebsite.Models
{
    public class Repository
    {

 
        private string childFirstname;
        private string childLastname;
        private string motherUsername;
        private string fatherUsername;
        private string childAddress;
        private string childCity;
        private int childPhonenumber;
        private string childBirthdate;
        private string notes;


   //     [RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 3 bogstaver ud for barnets navn!")] // DataAnnotations;
        [Required(ErrorMessage = "Barnets fornavn skal udfyldes!")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Barnets navn skal udfyldes!")]
        public string ChildFirstname
        {
            set
            {
                childFirstname = value;
            }
            get
            {
                return childFirstname;
            }
        }


        [Required(ErrorMessage = "Barnets navn skal udfyldes!")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Barnets efternavn skal udfyldes!")]
        public string ChildLastname
        {
            set
            {
                childLastname = value;
            }
            get
            {
                return childLastname;
            }
        }




   //     [RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 3 bogstaver ud for moderens brugernavn!")] // DataAnnotations;
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Invalid")]
        public string MotherUsername
        {
            set
            {
                motherUsername = value;
            }
            get
            {
                return motherUsername;
            }
        }


    //    [RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 3 bogstaver ud for faderens brugernavn!")] // DataAnnotations;
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Invalid")]
        public string FatherUsername
        {
            set
            {
                fatherUsername = value;
            }
            get
            {
                return fatherUsername;
            }
        }


      //  [RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 1 tal ud for barnets telefonnummer! - Hvis der ikke findes et nummer for barnet indtastes der blot 0")] // DataAnnotations;
        [Required(ErrorMessage = "Barnets adresse skal udfyldes!")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Invalid")]
        public string ChildAddress
        {
            set
            {
                childAddress = value;
            }
            get
            {
                return childAddress;
            }
        }


        //[RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 1 tal ud for barnets telefonnummer! - Hvis der ikke findes et nummer for barnet indtastes der blot 0")] // DataAnnotations;
        [Required(ErrorMessage = "Barnets by skal udfyldes!")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Minimum 1 tal ud for barnets telefonnummer! - Hvis der ikke findes et nummer for barnet indtastes der blot 0")]
        public string ChildCity
        {
            set
            {
                childCity = value;
            }
            get
            {
                return childCity;
            }
        }

     
        [Required(ErrorMessage = "Barnets telefonnummer skal udfyldes!")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Barnets telefonnummer må kun indeholde tal!")]
    
        public int ChildPhonenumber
        {
            set
            {
                childPhonenumber = value;
            }
            get
            {
                return childPhonenumber;
            }
        }

        public string ChildBirthdate
        {
            set
            {
                childBirthdate = value;
            }
            get
            {
                return childBirthdate;
            }
        }




        public string Notes
        {
            set
            {
                notes = value;
            }
            get
            {
                return notes;
            }
        }


       

    }
}