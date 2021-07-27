using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Acts.Acts
{
    class AddPerson : DefaultAction
    {
        public List<Person> ListOfPerson { get; set; }

        public AddPerson(string name, List<Person> list)
        {
            Name = name;
            ListOfPerson = list;
        }

        public override void Do()
        {
            Console.Clear();
            Console.WriteLine("Введите имя человека или \"отмена\"");
            string name = Console.ReadLine();

            while(name.ToLower() != "отмена")
            {
                Console.WriteLine("Введите дату его рождения");
                string date = Console.ReadLine();
                try
                {
                    string[] str = date.Trim(' ').Split('.');

                    DateTime dt = new DateTime(Convert.ToInt32(str[2]), Convert.ToInt32(str[1]), Convert.ToInt32(str[0]));

                    ListOfPerson.Add(new Person(name, dt));

                    Console.WriteLine("Введите имя человека или \"отмена\"");
                    name = Console.ReadLine();
                }
                catch { continue; }
            }

            Exit();
        }
    }
}
