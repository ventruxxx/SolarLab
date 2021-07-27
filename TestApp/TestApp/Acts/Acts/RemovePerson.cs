using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Acts.Acts
{
    class RemovePerson : DefaultAction
    {
        BirthdayList ListOfPersons { get; set; }
        public RemovePerson(string name, BirthdayList list)
        {
            Name = name;
            ListOfPersons = list;
        }
        public override void Do()
        {
            Console.Clear();

            Console.WriteLine("Введите имя человека, которого хотите удалить");
            string name = Console.ReadLine();

            List<Person> list = ListOfPersons.FindForName(name);

            Console.Clear();
            if(list.Count == 0)
            {
                Console.WriteLine("Такого человека не найдено");
                Exit();
            }
            if(list.Count == 1)
            {
                Console.WriteLine("Вы точно хотите удалить этого человека? (Д/Н)");
                char ch = Console.ReadKey().KeyChar;

                if (ch == 'д')
                {
                    ListOfPersons.ListOfPersons.Remove(list[0]);
                }
                Exit();
            }
            if(list.Count > 1)
            {
                for(int i = 0; i < list.Count; i++)
                    Console.WriteLine($"{i + 1}. {list[i].ToString()}");

                Console.WriteLine("Введите номер человека, которого хотите удалить или напишите all, чтобы удалить всех");

                string n = Console.ReadLine();

                if (n.ToLower() == "all")
                {
                    for (int i = 0; i < list.Count; i++)
                        ListOfPersons.ListOfPersons.Remove(list[i]);

                    Exit();
                }

                else
                {
                    int num = 0;
                    bool cond = Int32.TryParse(n, out num);
                    while (!cond)
                    {
                        Console.WriteLine("Вы неправильно ввели число. Введите номер человека, которого хотите удалить");

                        n = Console.ReadLine();
                        cond = Int32.TryParse(n, out num);

                        if (cond && (num < 1 || num > list.Count)) cond = false;
                    }

                    num--;

                    Console.WriteLine("Вы точно хотите удалить этого человека? (Д/Н)");
                    char ch = Console.ReadKey().KeyChar;

                    if (ch == 'д') ListOfPersons.ListOfPersons.Remove(list[num]);
                    Exit();
                }
            }

        }
    }
}
