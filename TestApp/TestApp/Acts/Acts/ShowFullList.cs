using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Acts.Acts;

namespace TestApp.Acts
{
    class ShowFullList : DefaultAction
    {
        public List<Person> ListOfPerson { get; set; }

        public ShowFullList(string name, List<Person> list)
        {
            Name = name;
            ListOfPerson = list;
        }

        public override void Do()
        {
            Console.Clear();
            for(int i = 0; i < ListOfPerson.Count; i++)
                Console.WriteLine((i + 1) + ". " + ListOfPerson[i].ToString());

            Exit();
        }
    }
}
