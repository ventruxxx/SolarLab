using System;
using System.Collections.Generic;
using System.IO;
using TestApp.Acts;
using TestApp.Acts.Acts;

namespace TestApp
{
    class Program
    {
        static BirthdayList list;
        static void Main(string[] args)
        {
            list = new BirthdayList();
            list.ListOfPersons = LoadPersons("persons.txt");

            Menu baseMenu = new Menu("Главное меню");
            Menu fullList = baseMenu.CreateSubmenu("Cписок ДР");
            fullList.CreateAct(new ShowFullList("Весь список ДР", list.ListOfPersons));
            fullList.CreateSubmenu("Список сегодняшних и ближайших ДР");
            baseMenu.CreateAct(new AddPerson("Добавить день рождения", list.ListOfPersons));
            baseMenu.CreateAct(new RemovePerson("Удалить день рождения", list));
            baseMenu.CreateAct(new ChangePerson("Изменить данные", list));
            baseMenu.CreateAct(new SaveDoc("Сохранить", "persons.txt", list.ListOfPersons));

            baseMenu.Do();
        }

        public static List<Person> LoadPersons(string p)
        {
            string path = p;
            List<Person> listok = new List<Person>();
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        try
                        {
                            listok.Add(Person.GetPerson(line));
                        }
                        catch { }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return listok;
        }
    }
}
