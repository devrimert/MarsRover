using System;
using MarsRover.Objects;
using MarsRover.Enums;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            string errStr;
            bool success = false;
            //Start
            Console.WriteLine("To begin to explore, please create a plateau and rovers");
            //Create Plateau
            Plateau plateau = new Plateau();         
            while (!success)
            {
                Console.WriteLine("Please enter max range for the plateau: ");
                string rangeStr = Console.ReadLine();
                
                errStr = plateau.MaxRange.CheckRange(rangeStr);
                if (errStr != null)
                    Console.WriteLine("Error: " + errStr);
                else
                    success = true;
            }            
            bool addRover = true;
            int roverCount = 1;
            //Add Rovers
            while (addRover) //While keep adding new rovers.
            {
                Rover rover = new Rover();
                success = false;
                //Add rover position
                while (!success)
                {
                    Console.WriteLine("Please Enter Rover " + roverCount.ToString() + "'s coordinates and route.");
                    string roverStr = Console.ReadLine();
                    errStr = rover.Position.CheckPosition(roverStr, plateau);
                    if (errStr != null)
                        Console.WriteLine("Error: " + errStr);
                    else
                        success = true;
                }
                //Add move path.
                Move move = new Move();
                success = false;
                while (!success)
                {
                    Console.WriteLine("Please enter a move path.");
                    string moveStr = Console.ReadLine();
                    errStr = move.CheckMovePath(moveStr);
                    if (errStr != null)
                        Console.WriteLine("Error: " + errStr);
                    else
                        success = true;
                }                              
                rover.MovePath = move;               
                rover.ID = roverCount;
                roverCount++;
                // add rover to plateau.
                plateau.AddRover(rover);
                //ask user wants to keep adding rovers or not.
                ConsoleKey response;
                do
                {
                    Console.WriteLine("Do you want to add another rover?('Y' Yes - 'N' No)");                       
                    response = Console.ReadKey(false).Key;
                    if (response != ConsoleKey.Enter)
                        Console.WriteLine();
                } while (response != ConsoleKey.Y && response != ConsoleKey.N);
                if (response == ConsoleKey.N)
                    addRover = false;
            }
            //Move rovers on plateau and print the result.
            for (int i =0; i<plateau.Rovers.Count; i++) {
                plateau.Rovers[i].MoveResult = plateau.Rovers[i].Move(plateau);
                Console.WriteLine("Rover " + plateau.Rovers[i].ID.ToString() + ": " + plateau.Rovers[i].Position.X.ToString() + " " + plateau.Rovers[i].Position.Y + " " +  RouteEnums.RouteEnumToString(plateau.Rovers[i].Position.Route) + " | " + plateau.Rovers[i].MoveResult);
            }

            //Done.
          
        }
    }
}
