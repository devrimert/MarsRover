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
            Console.WriteLine("To begin to explore, please create a plateau and rovers");
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
            
            while (addRover)
            {
                Rover rover = new Rover();
                success = false;
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
                plateau.AddRover(rover);
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
            
            for (int i =0; i<plateau.Rovers.Count; i++) {
                plateau.Rovers[i].MoveResult = plateau.Rovers[i].Move(plateau);
                Console.WriteLine("Rover " + plateau.Rovers[i].ID.ToString() + ": " + plateau.Rovers[i].Position.X.ToString() + " " + plateau.Rovers[i].Position.Y + " " +  RouteEnums.RouteEnumToString(plateau.Rovers[i].Position.Route) + " | " + plateau.Rovers[i].MoveResult);
            }

            
          
        }
    }
}
