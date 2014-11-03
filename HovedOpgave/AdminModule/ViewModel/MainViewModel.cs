using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Commands;

namespace AdminModule.ViewModel
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            ButtCommand = new DelegateCommand<object>(Clicked);
        }

        //public DelegateCommand<object> 

        public DelegateCommand<object> ButtCommand { get; set; }

        private void Clicked(Object o)
        {
            MessageBox.Show("clicked!");

        }


    }
}
