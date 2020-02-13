using business_logic.Controller;
using business_logic.Models;
using DevExpress.Mvvm;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sport_Shop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        Models.UserLogic userLogic = new Models.UserLogic();

        public string UserName { get; set; }

        public string UserGender { get; set; }

        public string UserBirthDay { get; set; }

        public string UserWeight { get; set; } 

        public string UserHeight { get; set; } 

        public bool IsFindUser { get; set; }

        public bool IsCorrectly { get; set; }


        public ICommand ClickAdd
        {
            get
            {
                return new RelayCommand(() =>
                {
                    IsFindUser = userLogic.IsUserFind(UserName);   
                });
            }
        }

        public ICommand ClickAdd2
        {
            get
            {
                return new RelayCommand(() =>
                {
                  IsCorrectly = userLogic.IsUserNotCorrectly(UserName, UserGender, UserBirthDay, UserWeight, UserHeight);
                });
            }
        }

    }
}
