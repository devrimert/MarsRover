using System;
using MarsRover.Objects;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {        
            Console.WriteLine("To begin to explore, please create a plateau and rovers");
            Console.WriteLine("Please enter max range for the plateau: ");
            string rangeStr = Console.ReadLine();
            Plateau plateau = new Plateau();
            MaxRange plateauRange = new MaxRange();
            string errStr = plateauRange.CheckRange(rangeStr);
            if (errStr != null)
            {
                Console.WriteLine(errStr);
                return;
            }
            bool addRover = true;
            int roverCount = 1;
            while (addRover)
            {
                Console.WriteLine("Please Enter Rover " + roverCount.ToString() + "'s coordinates and route.");
                string roverStr = Console.ReadLine()

            }
                
       
                

            
          
        }
    }
}
