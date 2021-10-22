using MarsRover.Enums;
using System;
using System.Text.RegularExpressions;
using MarsRover.Errors;

namespace MarsRover.Objects
{
    public class Rover
    {
        public int ID { get; set; }
        public Position Position { get; set; }
        public Move MovePath { get; set; }
        public string MoveResult { get; set; }

        public Rover()
        {
            Position = new Position();
            MovePath = new Move();
        }
      /// <summary>
      /// Moves the Rover to desired place according to MovePath of Rover.
      /// </summary>
      /// <param name="plateau">Plateau which the rover exist.</param>
      /// <returns></returns>
        public string Move(Plateau plateau) 
        {
            string resultStr;
            foreach (MoveEnums.MovePath path in this.MovePath.MovePaths)
            {
                if (path == MoveEnums.MovePath.M)
                {
                    resultStr = MoveMechanic(plateau);                                                                                 //Moves the rover.
                    if (resultStr != null)
                        return resultStr;
                }
                else
                    TurnMechanic(plateau, path);                                                                                      //Turns the rover.
            }
            return Results.RoverMoveResults.RMR03;
        }
        /// <summary>
        /// Moves the vehicle one step in the route it is facing.
        /// </summary>
        /// <param name="plateau">Plateau which the rover exist.</param>
        /// <returns></returns>
        private string MoveMechanic(Plateau plateau)
        {
            int moveValue = 1;                                                                                                        //Range of move.
            if (this.Position.Route == RouteEnums.Route.S || this.Position.Route == RouteEnums.Route.W)                               //Checks the direction of move.
                moveValue = moveValue * -1;
            Position newPos = new Position();
            newPos.Route = this.Position.Route;

            if (this.Position.Route == RouteEnums.Route.S || this.Position.Route == RouteEnums.Route.N)                               //Checks is move operation will effect vertical or horizontal.
            {
                newPos.X = this.Position.X;
                newPos.Y = this.Position.Y + moveValue;
            }
            else
            {
                newPos.X = this.Position.X + moveValue;
                newPos.Y = this.Position.Y;
            }

            string resultStr = CheckDesiredPosition(newPos, plateau);                                                                 //Checks is desired position available to move or not.
            if (resultStr != null)
                return resultStr;
            this.Position = newPos;
            return null;
        }
        /// <summary>
        /// Checks is the desired position in borders of plateau or is there another rover in the position.
        /// </summary>
        /// <param name="position">Desired Position</param>
        /// <param name="plateau">Plateau which the desired position exist.</param>
        /// <returns></returns>
        private string CheckDesiredPosition(Position position, Plateau plateau)
        {
            if ((position.X > plateau.MaxRange.X || position.Y > plateau.MaxRange.Y) || (position.X < 0 || position.Y < 0))
                return Results.RoverMoveResults.RMR01;
            foreach (Rover rover in plateau.Rovers)
            {
                if (position.X == rover.Position.X && position.Y == rover.Position.Y)
                    return Results.RoverMoveResults.RMR02 + " Blocked by Rover " + rover.ID.ToString();
            }
            return null;
        }
        /// <summary>
        /// Turns the rover according to move path taken from user.
        /// </summary>
        /// <param name="plateau">Plateau which the rover exist.</param>
        /// <param name="path">Direction which the rover need to turn.</param>
        private void TurnMechanic(Plateau plateau, MoveEnums.MovePath path)
        {
            int routeCode = (int)this.Position.Route;
            int turnValue = 1;
            if (path == MoveEnums.MovePath.L)
                turnValue = turnValue * -1;
            routeCode = (routeCode + turnValue + 4) % 4;
            this.Position.Route = (RouteEnums.Route)routeCode;
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
            //Check position string
            if (position == "")
                return (Errors.Errors.RoverCreationErrors.RCE02);
            string[] totalPos = position.Split(" ");
            string[] coords = { totalPos[0], totalPos[1] };
            //Check position value is valid or not
            if (position == null || totalPos.Length !=3 || coords.Length != 2)
                return (Errors.Errors.RoverCreationErrors.RCE03);
            if (!Regex.IsMatch(coords[0], "^[0-9]*$") || !Regex.IsMatch(coords[1], "^[0-9]*$"))
                return (Errors.Errors.RoverCreationErrors.RCE01);
            char[] route = totalPos[2].ToCharArray();
            //Check route value is valid or not. If it is valid, write.
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
            //Check is position inside of plateau or there any other rover in position. If it passes. write.
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
            //Check move path is valid or not. If its valid. write.
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
