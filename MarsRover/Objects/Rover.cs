using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Objects
{
    public class Rover
    {
        public int ID { get; set; }
        public Position Position { get; set; }
        public RoverRoute.Route Route { get; set; }
        public bool IsBlocked { get; set; }

        public Rover(Plateau plateau)
        {
            Position = new Position();
            Route = new RoverRoute.Route();
            IsBlocked = false;
        }
        //public bool Move(Plateau plateau, RoverRoute.Route route, Coordinate newCoordinate)
        //{
            
        //    switch (Route)
        //    {
        //        case RoverRoute.Route.N:
        //            {
        //                Coordinate newCoord = new Coordinate();
        //                newCoord.X = this.Position.X;
        //                newCoord.Y = this.Position.Y++;
        //                foreach (Rover rover in plateau.Rovers)
        //                {
        //                    if (this.Equals(rover) == false)
        //                    {
                                
                         
        //                    }
        //                }
        //                break;
        //            }
        //        case RoverRoute.Route.E:
        //            {
        //                Coordinate newCoord = new Coordinate();
        //                newCoord.X = this.Position.X;
        //                newCoord.Y = this.Position.Y++;
        //                break;
        //            }
        //        case RoverRoute.Route.S:
        //            {
        //                Coordinate newCoord = new Coordinate();
        //                newCoord.X = this.Position.X;
        //                newCoord.Y = this.Position.Y++;
        //                break;
        //            }
        //        case RoverRoute.Route.W:
        //            {
        //                Coordinate newCoord = new Coordinate();
        //                newCoord.X = this.Position.X;
        //                newCoord.Y = this.Position.Y++;
        //                break;
        //            }


        //    }

        //    return false;
        //}

        //public void Move()
        //{

        //}
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }


    }
    public class RoverRoute
    {
        public enum Route : byte
        {
            N=0,   E=1,  S=2,  W=3
        }
        public static string ToString(Route Route)
        {
            return Enum.GetName(typeof(Route),Route);
        }

    }
}
