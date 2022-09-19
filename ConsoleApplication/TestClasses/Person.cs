using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.TestClasses
{
    public class Person
    {
        public Person(string name, string surname, int age, bool isMarried)
        {
            Name = name;
            Surname = surname;
            Age = age;
            IsMarried = isMarried;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public bool IsMarried { get; set; }

        public void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }
}
