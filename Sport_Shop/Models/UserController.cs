using business_logic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace business_logic.Controller
{/// <summary>
/// Контроллер пользователя.
/// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public List<User> Users { get; } 

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание нового контроллера пользователя приложения.
        /// </summary>
        /// <param name="user"> Пользователь приложения. </param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("userName не может быть равен Null или пустым", nameof(userName));
            }

            Users = GetUsersData();
            //---------------
            foreach (var item in Users)
            {
                Console.WriteLine($"Name: {item.Name}, Age: {item.Age}, BDay: {item.BirthDate}, W: {item.Weight}, H: {item.Height}");
            }
            //---------------
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }


        }


        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            // TODO: Проверка.
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        
        }


        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("Users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }

        /// <summary>
        /// Получить сщхраненный список пользователей.
        /// </summary>
        /// <returns> Пользователь приложения. </returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("Users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }

            }
        }


        
    }
}
