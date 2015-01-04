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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModule.Webservice
{
    public partial class Class
    {
        //shouldwork...
        private string associatedTeacher;

        public string AssociatedTeacher
        {
            get
            {
                if (ObjectHolder.Instance.TeacherList == null)
                {
                    ObjectHolder.Instance.GetTeachers();
                }

                if (ObjectHolder.Instance.TeacherList != null)
                {

                    foreach (TeacherEx teacher in ObjectHolder.Instance.TeacherList)
                    {

                        foreach (ClassEx classEx in teacher.ClassList)
                        {
                            if (classEx.Id == Id)
                            {
                                associatedTeacher = teacher.Firstname + " " + teacher.Lastname;
                            }

                        }
                    }
                }
              

                return associatedTeacher;
            }
            set { associatedTeacher = value; }
        }


        public override string ToString()
        {

            return Name + "\tUnderviser:" + Fkteacherid;
        }


    }
}
