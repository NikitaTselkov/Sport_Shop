using business_logic.Controller;
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
    class MainViewModel : ViewModelBase
    {
        public string UserName { get; set; }
        
        public string UserGender { get; set; }

        public string UserBirthDay { get; set; }

        public string UserWeight { get; set; }

        public string UserHeight { get; set; }

        public ICommand ClickAdd
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    CreateUser();
                });
            }
        }

        public void CreateUser()
        {
            DateTime _UserBirthDay = DateTime.Parse(UserBirthDay);
            double _UserWeight = double.Parse(UserWeight);
            double _UserHeight = double.Parse(UserHeight);

            var userController = new UserController(UserName, UserGender, _UserBirthDay, _UserWeight, _UserHeight);
            userController.Save();

        }

    }
}
