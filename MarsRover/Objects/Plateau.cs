using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MarsRover.Objects
{
    public class Plateau
    {
        public MaxRange MaxRange { get; set; }
        public List<Rover> Rovers { get; set; }

        public Plateau()
        {
            MaxRange = new MaxRange();
            Rovers = new List<Rover>();
        }



        /// <summary>
        /// Adds a rover into the plateau terrain.
        /// </summary>
        /// <param name="Rover">The rover you want to add terrain</param>
        public void AddRover(Rover Rover)
        {
            this.Rovers.Add(Rover);
        }
    }
    public class MaxRange
    {
        public int X { get; set; }
        public int Y { get; set; }
        /// <summary>
        /// Checks the given coordinates is valid or not
        /// </summary>
        /// <param name="CoordinateString">Max Range coordinates for plateau</param>
        /// <returns></returns>
        public string CheckRange(string CoordinateString)
        {
            MaxRange coordinate = new MaxRange();
            //Check Values
            if (CoordinateString == "")                                                                         //Checks coordinate string left blank by user or not.
                return (Errors.Errors.PlateauCreationErrors.PCE02);
            string[] coords = CoordinateString.Split(" ");

            if (CoordinateString == null || coords.Length != 2)                                                 //Checks is coordinate string valid or not.
                return (Errors.Errors.PlateauCreationErrors.PCE03);
            if (!Regex.IsMatch(coords[0], "^[0-9]*$") || !Regex.IsMatch(coords[1], "^[0-9]*$"))                 //Checks is coordinate string consist of numbers or not.
                return (Errors.Errors.PlateauCreationErrors.PCE01);
            //Write Values
            this.X = Convert.ToInt32(coords[0]);                                                                    
            this.Y = Convert.ToInt32(coords[1]);
            return null;
        }
    }
}
