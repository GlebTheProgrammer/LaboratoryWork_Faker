using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleApplication.TestClasses;
using ConsoleApplication.TestStructures;
using Faker;

namespace ConsoleApplication
{
    public class Test
    {

    }

    public class Program
    {
        static void Main(string[] args)
        {
            FakerGenerator faker = new Faker.FakerGenerator();

            var boolVar = faker.Create<bool>();
            var bool2Var = faker.Create<bool>();
            var byteVar = faker.Create<byte>();
            var byte2Var = faker.Create<byte>();
            var byte3Var = faker.Create<byte>();
            var charVar = faker.Create<char>();
            var shortVar = faker.Create<short>();
            var intVar = faker.Create<int>();
            var longVar = faker.Create<long>();
            var floatVar = faker.Create<float>();
            var decimalVar = faker.Create<decimal>();
            var doubleVar = faker.Create<double>();

            Console.WriteLine($"{nameof(boolVar)} = {boolVar}");
            Console.WriteLine($"{nameof(bool2Var)} = {bool2Var}");
            Console.WriteLine($"{nameof(byteVar)} = {byteVar}");
            Console.WriteLine($"{nameof(byte2Var)} = {byte2Var}");
            Console.WriteLine($"{nameof(byte3Var)} = {byte3Var}");
            Console.WriteLine($"{nameof(charVar)} = {charVar}");
            Console.WriteLine($"{nameof(shortVar)} = {shortVar}");
            Console.WriteLine($"{nameof(intVar)} = {intVar}");
            Console.WriteLine($"{nameof(longVar)} = {longVar}");
            Console.WriteLine($"{nameof(floatVar)} = {floatVar}");
            Console.WriteLine($"{nameof(decimalVar)} = {decimalVar}");
            Console.WriteLine($"{nameof(doubleVar)} = {doubleVar}");


            Console.WriteLine("\nReference type objects:\n");
            var person = faker.Create<Person>();
            Console.WriteLine($"Name: {person.Name}");
            Console.WriteLine($"Surname: {person.Surname}");
            Console.WriteLine($"Age: {person.Age}");
            Console.WriteLine($"Is Married: {person.IsMarried}");

            List<int> ints = faker.Create<List<int>>();
            List<List<int>> ints2 = faker.Create<List<List<int>>>();
            List<Person> test = faker.Create<List<Person>>();

            var structtemp = faker.Create<House>();

            var a = faker.Create<A>();
        }
    }
}
