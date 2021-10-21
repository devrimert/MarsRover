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
            string errStr = plateau.MaxRange.CheckRange(rangeStr);
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
                string roverStr = Console.ReadLine();
                Rover rover = new Rover();
                errStr = rover.Position.CheckPosition(roverStr, plateau);
                if (errStr != null)
                {
                    Console.WriteLine(errStr);
                    return;
                }
                rover.ID = roverCount;
                roverCount++;
                Console.WriteLine("Please enter a move path.");
                string moveStr = Console.ReadLine();

                plateau.AddRover(rover);
                Console.WriteLine("Do you want to add another rover?('Y' Yes - 'N' No");
                    


            }
                
       
                

            
          
        }
    }
}
