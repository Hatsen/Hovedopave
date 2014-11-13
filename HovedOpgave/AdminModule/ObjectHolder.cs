using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminModule.Webservice;

namespace AdminModule
{
    public class ObjectHolder:ViewModelBase
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
        private List<Teacher> teacherList;

        public bool Isloading
        {
            get { return isLoading; }
            set
            {
                isLoading = value;
                OnPropertyChanged("Isloading");
            }
        }


        public List<Teacher> TeacherList
        {

            get { return teacherList; }

            set
            {
                teacherList = value;
                OnPropertyChanged("TeacherList");
            }

        }



        public async void GetTeachers()
        {
            Isloading = true;
            TeacherList = await ServiceProxy.Instance.GetTeachers();
            Isloading = false;
           // RaiseOnselectedPersonChanged("Underviser");
        }


    }
}
