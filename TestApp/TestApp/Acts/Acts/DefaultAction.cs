using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Acts.Acts
{
    abstract class DefaultAction : IAct
    {
        public string Name { get; set; }
        public Menu MainMenu { get; set; }

        public abstract void Do();

        protected void Exit()
        {
            Console.WriteLine("Нажмите на любую клавишу, чтобы вернуться назад");
            Console.ReadKey();
            MainMenu.Do();
        }
    }
}
