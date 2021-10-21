using MarsRover.Enums;
using System;
using System.Text.RegularExpressions;

namespace MarsRover.Objects
{
    public class Rover
    {
        public int ID { get; set; }
        public Position Position { get; set; }
        public bool IsBlocked { get; set; }
        public Move Move { get; set; }

        public Rover()
        {
            Position = new Position();
        }
      
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public RouteEnums.Route Route { get; set; }
        /// <summary>
        /// Checks given position is valid or not.
        /// </summary>
        /// <param name="position">Position of new rover.</param>
        /// <param name="plateau">The plateau which rovers adding on.</param>
        /// <returns></returns>
        public string CheckPosition(string position, Plateau plateau)
        {
            if (position == "")
                return (Errors.Errors.RoverCreationErrors.RCE02);
            string[] totalPos = position.Split(" ");
            string[] coords = { totalPos[0], totalPos[1] };

            if (position == null || totalPos.Length !=3 || coords.Length != 2)
                return (Errors.Errors.RoverCreationErrors.RCE03);
            if (!Regex.IsMatch(coords[0], "^[0-9]*$") || !Regex.IsMatch(coords[1], "^[0-9]*$"))
                return (Errors.Errors.RoverCreationErrors.RCE01);
            char[] route = totalPos[2].ToCharArray();
            if (!char.IsLetter(route[0]) || !char.IsUpper(route[0]) || !(route[0] == 'N' || route[0] == 'S' || route[0] == 'W' || route[0] == 'E') )
                return (Errors.Errors.RoverCreationErrors.RCE04);
            else
            {
                if (route[0] == 'N')
                    this.Route = RouteEnums.Route.N;
                else if (route[0] == 'E')
                    this.Route = RouteEnums.Route.E;
                else if (route[0] == 'S')
                    this.Route = RouteEnums.Route.S;
                else
                    this.Route = RouteEnums.Route.W;
            }
            if (Convert.ToInt32(coords[0]) > plateau.MaxRange.X || Convert.ToInt32(coords[1]) > plateau.MaxRange.Y)
                return Errors.Errors.RoverCreationErrors.RCE06;
            foreach(Rover rover in plateau.Rovers)
            {
                if (Convert.ToInt32(coords[0]) == rover.Position.X && Convert.ToInt32(coords[1]) == rover.Position.Y)
                    return Errors.Errors.RoverCreationErrors.RCE05;
            }


            this.X = Convert.ToInt32(coords[0]);
            this.Y = Convert.ToInt32(coords[1]);
            

            return null;
        }
    }
    public class Move
    {  
        public MoveEnums.MovePath[] MovePaths { get; set; }
        /// <summary>
        /// Checks given move path is valid or not.
        /// </summary>
        /// <param name="movepath">Move path which taken for rover.</param>
        /// <returns></returns>
        public string CheckMovePath(string movepath)
        {
            if (movepath == "")
                return (Errors.Errors.MoveCreationError.MCE03);
            MoveEnums.MovePath[] final = new MoveEnums.MovePath[movepath.Length];
            int pathcounter = 0;
            foreach (char c in movepath)
            {
                if (!char.IsLetter(c) || !char.IsUpper(c) || !(c == 'L' || c == 'M' || c == 'R'))
                    return Errors.Errors.MoveCreationError.MCE01 + " " + Errors.Errors.MoveCreationError.MCE02;
                else
                {
                    if (c == 'L')
                        final[pathcounter] = MoveEnums.MovePath.L;
                    else if (c == 'M')
                        final[pathcounter] = MoveEnums.MovePath.M;
                    else
                        final[pathcounter] = MoveEnums.MovePath.R;
                }
                pathcounter++;
            }
            this.MovePaths = final;
            return null;
        }

    }
}
