using business_logic.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_Shop.Models
{
    public class UserLogic
    {
        /// <summary>
        /// Создает нового пользователя.
        /// </summary>
        /// <param name="UserName"> Имя. </param>
        /// <param name="UserGender"> Пол. </param>
        /// <param name="UserBirthDate"> Дата рождения. </param>
        /// <param name="UserWeight"> Вес. </param>
        /// <param name="UserHeight"> рост. </param>
        public void UserCreate(string UserName, string UserGender, DateTime UserBirthDate, double UserWeight, double UserHeight)
        {
            #region Проверка.
            if (string.IsNullOrWhiteSpace(UserName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустыи или null", nameof(UserName));
            }
            if (string.IsNullOrWhiteSpace(UserGender))
            {
                throw new ArgumentNullException("пол не может быть пустыи или null", nameof(UserGender));
            }
           
            #endregion

            

            var userController = new UserController(UserName);

            //if (userController.IsNewUser)
            //{
            //   // userController.SetNewUserData(UserGender, UserBirthDate, UserWeight, UserHeight);
                
            //}
           userController.SetNewUserData(UserGender, UserBirthDate, UserWeight, UserHeight);
            
        }
        /// <summary>
        /// Проверка на корректность входных данных.
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserGender"></param>
        /// <param name="UserBirthDate"></param>
        /// <param name="UserWeight"></param>
        /// <param name="UserHeight"></param>
        /// <returns></returns>
        public bool IsUserNotCorrectly(string UserName, string UserGender, string UserBirthDate, string UserWeight, string UserHeight)
        { 
            #region Проверка и парсинг

            if (DateTime.TryParse(UserBirthDate, out DateTime _UserBirthDate))
            {
                Console.WriteLine("Ok " + _UserBirthDate);
            }
            else
            {
                return true;
            }

            if (Double.TryParse(UserWeight, out double _UserWeight))
            {
                Console.WriteLine("Ok " + _UserWeight);
            }
            else
            {
                return true;
            }

            if (Double.TryParse(UserHeight, out double _UserHeight))
            {
                Console.WriteLine("Ok " + _UserHeight);
            }
            else
            {
                return true;
            }

            #endregion

            UserCreate(UserName, UserGender, _UserBirthDate, _UserWeight, _UserHeight);

            return false;
        }

        /// <summary>
        /// Проверяет надичие пользователя.
        /// </summary>
        /// <param name="UserName"> Имя. </param>
        /// <returns> Наличие пользователя. </returns>
        public bool IsUserFind(string UserName)
        {
            var userController = new UserController(UserName);

            if (userController.IsNewUser)
            {
                return true;
            }
            else 
            {
                
               return false;
            }
        }

        

      
    }
}
