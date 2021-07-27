using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Acts.Acts
{
    class ChangePerson : DefaultAction
    {
        BirthdayList ListOfPersons { get; set; }
        public ChangePerson(string name, BirthdayList list)
        {
            Name = name;
            ListOfPersons = list;
        }
        public override void Do()
        {
            Console.Clear();

            Console.WriteLine("Введите имя человека, которого хотите изменить");
            string name = Console.ReadLine();

            List<Person> list = ListOfPersons.FindForName(name);
            Console.Clear();

            if (list.Count == 0)
            {
                Console.WriteLine("Такого человека не найдено");
                Exit();
            }
            if (list.Count == 1)
            {
                Console.WriteLine("Что вы хотите изменить у этого человека?\n" +
                    " 1. Дата рождения\n" +
                    " 2. Имя");

                char ch = Console.ReadKey().KeyChar;
                Console.Clear();
                if (ch == '1')
                {
                    Console.WriteLine("Введите дату рождения или напишите отмена");
                    string str = Console.ReadLine();
                    if(str.ToLower() == "отмена")
                    {
                        Exit();
                    }
                    else
                    {
                        try
                        {
                            string[] arr = str.Trim(' ').Split('.');

                            DateTime dt = new DateTime(Convert.ToInt32(arr[2]), Convert.ToInt32(arr[1]), Convert.ToInt32(arr[0]));

                            list[0].BirthDay = dt;
                            Console.WriteLine("Дата рождения успешно изменена");
                            Exit();

                        }
                        catch {
                            Console.WriteLine("Ошибка введенных данных");
                            Exit();
                        }
                    }
                }
                if(ch == '2')
                {
                    Console.WriteLine("Введите имя или напишите отмена");
                    string str = Console.ReadLine();
                    if (str.ToLower() == "отмена")
                    {
                        Exit();
                    }
                    else
                    {
                        list[0].Name = str;
                        Exit();
                    }
                }
                else
                    Exit();
            }
            if (list.Count > 2)
            {
                for (int i = 0; i < list.Count; i++)
                    Console.WriteLine($"{i + 1}. {list[i].ToString()}");

                Console.WriteLine("Введите номер человека, которого хотите изменить");

                string n = Console.ReadLine();

                int num = 0;
                bool cond = Int32.TryParse(n, out num);
                while (!cond)
                {
                    Console.WriteLine("Вы неправильно ввели число. Введите номер человека, которого хотите изменить");

                    n = Console.ReadLine();
                    cond = Int32.TryParse(n, out num);

                    if (cond && (num < 1 || num > list.Count)) cond = false;
                }

                num--;

                Console.WriteLine("Что вы хотите изменить у этого человека?\n" +
                     " 1. Дата рождения\n" +
                     " 2. Имя");

                char ch = Console.ReadKey().KeyChar;
                Console.Clear();
                if (ch == '1')
                {
                    Console.WriteLine("Введите дату рождения или напишите отмена");
                    string str = Console.ReadLine();
                    if (str.ToLower() == "отмена")
                    {
                        Exit();
                    }
                    else
                    {
                        try
                        {
                            string[] arr = str.Trim(' ').Split('.');

                            DateTime dt = new DateTime(Convert.ToInt32(arr[2]), Convert.ToInt32(arr[1]), Convert.ToInt32(arr[0]));

                            list[num].BirthDay = dt;
                            Console.WriteLine("Дата рождения успешно изменена");
                            Exit();

                        }
                        catch
                        {
                            Console.WriteLine("Ошибка введенных данных");
                            Exit();
                        }
                    }
                }
                if (ch == '2')
                {
                    Console.WriteLine("Введите имя или напишите отмена");
                    string str = Console.ReadLine();
                    if (str.ToLower() == "отмена")
                    {
                        Exit();
                    }
                    else
                    {
                        list[num].Name = str;
                        Exit();
                    }
                }
                else
                    Exit();
            }

            Exit();
        }
    }
}
