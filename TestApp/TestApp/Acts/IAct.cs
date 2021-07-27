using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Acts
{
    interface IAct
    {
        public string Name { get; set; }
        public Menu MainMenu { get; set; }
        public void Do();
    }
}
