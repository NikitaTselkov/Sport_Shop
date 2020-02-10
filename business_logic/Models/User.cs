﻿using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.Models
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// День рождения.
        /// </summary>
        public DateTime BirthDate { get; }

        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }

        #endregion

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name"> Иия. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="birthDate"> День рождения. </param>
        /// <param name="weight"> Вес. </param>
        /// <param name="height"> Рост. </param>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустыи или null", nameof(name));
            }

            if(gender == null)
            {
                throw new ArgumentNullException("Пол не может быть null", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") && birthDate >= DateTime.Now) 
            {
                throw new ArgumentException("Невозможная дата рождения", nameof(birthDate));
            }

            if (weight <= 0 && weight > 500)
            {
                throw new ArgumentNullException("Аргумент не может быть меньше 0, больше 500 или равен null", nameof(weight));
            }

            if(height <= 0 && height > 3)
            {
                throw new ArgumentNullException("Аргумент не может быть меньше 0, больше 3 или равен null", nameof(height));
            }

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;

            #endregion
        }



        public override string ToString()
        {
            return Name;
        }


    }
}
