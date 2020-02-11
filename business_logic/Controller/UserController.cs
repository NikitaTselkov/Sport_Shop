using business_logic.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        public User User { get; }

        /// <summary>
        /// Создание нового контроллера пользователя приложения.
        /// </summary>
        /// <param name="user"> Пользователь приложения. </param>
        public UserController(string userName, string genderName, DateTime birthDay, double wight, double height)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("userName не может быть равен Null или пустым", nameof(userName));
            }
            // TODO: Проверка.

            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, wight, height);

        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("Users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }

        /// <summary>
        /// Загрузить данные полбзователя.
        /// </summary>
        /// <returns> Пользователь приложения. </returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("Users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }

                // TODO: Что делать если пользователя не прочитали?
            }
        }
    }
}
