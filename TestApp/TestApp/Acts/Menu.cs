using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Acts
{
    class Menu : IAct
    {
        public string Name { get; set; }
        public List<IAct> ListOfActs { get; private set; }
        public Menu MainMenu { get; set; }

        public Menu(string name)
        {
            Name = name;
            MainMenu = null;
            ListOfActs = new List<IAct>();
        }
        private Menu(string name, Menu mainMenu)
        {
            Name = name;
            MainMenu = mainMenu;
            ListOfActs = new List<IAct>();
        }

        public Menu CreateSubmenu(string name)
        {
            Menu m = new Menu(name, this);
            ListOfActs.Add(m);
            return m;
        }

        public void CreateAct(IAct act)
        {
            act.MainMenu = this;
            ListOfActs.Add(act);
        }

        public override string ToString()
        {
            string str = Name + "\n";
            for (int i = 0; i < ListOfActs.Count; i++)
            {
                str += $" {i + 1}. {ListOfActs[i].Name}\n";
            }

            if (MainMenu == null)
                str += $" {ListOfActs.Count + 1}. Выход";
            else
                str += $" {ListOfActs.Count + 1}. Назад";

            return str;
        }

        public void Do()
        {
            Console.Clear();
            Console.WriteLine(ToString());
            Console.WriteLine("Выберите пункт меню");

            char ch = Console.ReadKey().KeyChar;
            int num = 0;
            bool cond = Int32.TryParse(ch.ToString(), out num);

            if (cond)
            {
                num--;
                if (num < 0 || num > ListOfActs.Count)
                {
                    Console.WriteLine("Неправильно введены данные");
                    Do();
                    return;
                }

                if (num == ListOfActs.Count)
                {
                    if (MainMenu == null) return;
                    else
                    {
                        MainMenu.Do();
                        return;
                    }
                }
                else
                    ListOfActs[num].Do();
            }
        }
    }
}
