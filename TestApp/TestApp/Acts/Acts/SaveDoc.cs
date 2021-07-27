using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestApp.Acts.Acts
{
    class SaveDoc : DefaultAction
    {
        public string Path { get; set; }

        public List<Person> ListOfPersons { get; set; }

        public SaveDoc(string name, string path, List<Person> list) { Name = name; Path = path; ListOfPersons = list; }

        public override void Do()
        {
            Console.Clear();
            string text = "";

            for(int i = 0; i < ListOfPersons.Count; i++)
            {
                text += ListOfPersons[i].ToFile() + "\n";
            }
            
            try
            {
                using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Exit();
        }
    }
}
