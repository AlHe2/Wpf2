using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf2
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Telephone { get; set; }

        public Person(String fn, String ln, int age, String tel) {
            FirstName = fn;
            LastName = ln;
            Age = age;
            Telephone = tel;
        }
    }
}
