using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    class Person
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }

        public Person(string name, DateTime dt)
        {
            Name = name;
            BirthDay = dt;
        }

        public override string ToString()
        {
            return $"{Name}: {BirthDay.ToString("dd MMM yyyy г.")}";
        }

        public string ToFile()
        {
            return $"{Name};{BirthDay.ToOADate()}";
        }

        public static Person GetPerson(string text)
        {
            string[] str = text.Split(';');
            string name = str[0];
            double date = Convert.ToDouble(str[1]);

            DateTime dt = DateTime.FromOADate(date);

            return new Person(name, dt);
        }
    }
}
