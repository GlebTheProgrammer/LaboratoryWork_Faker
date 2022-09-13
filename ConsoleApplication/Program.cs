using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Faker;

namespace ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FakerGenerator faker = new Faker.FakerGenerator();

            //int a = faker.Create<int>();

            int b = 10;

            string json = JsonSerializer.Serialize(b);
            Console.WriteLine(json);
        }
    }
}
