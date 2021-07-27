using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    class BirthdayList
    {
        List<Person> listOfPersons;
        /// <summary>
        /// Список людей
        /// </summary>
        public List<Person> ListOfPersons { get => Sort(); set { listOfPersons = value; } }

        public BirthdayList()
        {
            ListOfPersons = new List<Person>();
        }
        List<Person> Sort()
        {
            return listOfPersons;
        }
        /// <summary>
        /// Получить сегодняшние ДР
        /// </summary>
        /// <returns></returns>
        public List<Person> GetToDay()
        {
            List<Person> list = new List<Person>();

            foreach(Person i in listOfPersons) if (i.BirthDay.Day == DateTime.UtcNow.Day) list.Add(i);

            return list;
        }
        /// <summary>
        /// Получить ближайшие ДР
        /// </summary>
        /// <returns></returns>
        public List<Person> GetNearest()
        {
            List<Person> list = new List<Person>();

            foreach (Person i in listOfPersons) 
                if ((i.BirthDay.Day - 5 <= DateTime.UtcNow.Day || 
                    i.BirthDay.Day + 5 >= DateTime.UtcNow.Day) 
                    && i.BirthDay.Day != DateTime.UtcNow.Day) 
                    list.Add(i);

            return list;
        }

        /// <summary>
        /// Поиск по имени
        /// </summary>
        /// <param name="name">Имя</param>
        /// <returns>Список совпадений</returns>
        public List<Person> FindForName(string name)
        {
            List<Person> list = new List<Person>();

            foreach(Person i in ListOfPersons)
            {
                if(i.Name.ToLower().Contains(name.ToLower()))
                {
                    list.Add(i);
                }
            }
            return list;
        }
    }
}
