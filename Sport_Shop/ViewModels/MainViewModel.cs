using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sport_Shop.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public int Clicks { get; set; }
        

       
        public ICommand ClickAdd
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Clicks++;
                });
            }
        }

    }
}
