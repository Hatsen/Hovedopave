

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
using AdminModule.Webservice;

namespace AdminModule
{
    public class ObjectHolder : ViewModelBase
    {

        private static ObjectHolder instance;

        private ObjectHolder() { }

        public static ObjectHolder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjectHolder();
                }
                return instance;
            }

        }


        private bool isLoading;
        private List<TeacherEx> teacherList;
        private List<ClassEx> classList;
        private List<Student> studentList;


        public bool Isloading
        {
            get { return isLoading; }
            set
            {
                isLoading = value;
                OnPropertyChanged("Isloading");
            }
        }


        public List<TeacherEx> TeacherList
        {
            get { return teacherList; }
            set
            {
                teacherList = value;
                OnPropertyChanged("TeacherList");
                OnPropertyChanged("CurrentClass");
               // Test = true;

            }

        }

        public List<ClassEx> ClassList
        {

            get { return classList; }

            set
            {
                classList = value;
                OnPropertyChanged("ClassList");
                OnPropertyChanged("CurrentStudent");
            }

        }


        public List<Student> StudentList
        {

            get { return studentList; }

            set
            {
                studentList = value;
                OnPropertyChanged("StudentList");
            }

        }


        public async void GetTeachers()
        {
            Isloading = true;
            TeacherList = await ServiceProxy.Instance.GetTeachers();
            Isloading = false;
        }


        public async void GetClasses()
        {
            Isloading = true;
            ClassList = await ServiceProxy.Instance.GetClasses();
            Isloading = false;
        }


        public async void GetStudents()
        {
            Isloading = true;
            StudentList = await ServiceProxy.Instance.GetStudents();
            Isloading = false;
        }


    }
}
