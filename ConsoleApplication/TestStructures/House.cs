using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.TestStructures
{
    public struct House
    {
        public int BlockOfFlatsNumber { get; set; }
        public int NumberOfPeopleInIt { get; set; }

        public House(int blockOfFlatsNumber, int numberOfPeopleInIt)
        {
            BlockOfFlatsNumber = blockOfFlatsNumber;
            NumberOfPeopleInIt = numberOfPeopleInIt;
        }
    }
}
