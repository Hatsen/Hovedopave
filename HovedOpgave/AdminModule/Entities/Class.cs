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
