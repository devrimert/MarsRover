﻿namespace MarsRover.Errors
{
    // XXX = Message Type
    // 00 = Message Number
    internal static class Errors
    {
        internal static class PlateauCreationErrors
        {
            /// <summary>
            /// Plateaus size data can only consist of numbers.
            /// </summary>
            internal const string PCE01 = "Plateaus size data can only consist of 2 numbers.";
            /// <summary>
            /// Plateaus size data can't be left blank."
            /// </summary>
            internal const string PCE02 = "Plateaus size data can't be left blank.";
            /// <summary>
            /// Invalid plateaus size data."
            /// </summary>
            internal const string PCE03 = "Invalid plateaus size data.";
        }
        internal static class RoverCreationErrors
        {
            /// <summary>
            /// Rovers position data can only consist of 2 numbers.
            /// </summary>
            internal const string RCE01 = "Rovers position data can only consist of 2 numbers.";
            /// <summary>
            /// Rovers position data can not be left blank.
            /// </summary>
            internal const string RCE02 = "Rovers position data can not be left blank.";
            /// <summary>
            /// Invalid rover position data."
            /// </summary>
            internal const string RCE03 = "Invalid rover position data.";
            /// <summary>
            /// Rovers route data can consist only one capital character.('N', 'W', 'S', 'E').
            /// </summary>
            internal const string RCE04 = "Rovers route data can consist only one capital character.('N', 'W', 'S', 'E')";
            /// <summary>
            /// There is another rover in given position for the rover.
            /// </summary>
            internal const string RCE05 = "There is another rover in given position for the rover.";
            /// <summary>
            /// Given position for rover is out of plateaus range.
            /// </summary>
            internal const string RCE06 = "Given position for rover is out of plateaus range.";
        }
        internal static class MoveCreationError
        {
            /// <summary>
            /// Invalid move data."
            /// </summary>
            internal const string MCE01 = "Invalid move data.";
            /// <summary>
            /// Move data can consist only capital characters.('L', 'R', 'M').
            /// </summary>
            internal const string MCE02 = "Move data can consist only capital characters.('L', 'R', 'M')";
            /// <summary>
            /// Rovers move data can not be left blank.
            /// </summary>
            internal const string MCE03 = "Rovers move data can not be left blank.";

        }
    }
    internal static class Results
    {
        internal static class RoverMoveResults
        {
            /// <summary>
            /// The rover is reached plateaus boundry during the move.
            /// </summary>
            internal const string RMR01 = "The rover is reached plateaus boundry during the move.";
            /// <summary>
            /// The rover is blocked by another rover.
            /// </summary>
            internal const string RMR02 = "The rover is blocked by another rover.";
            /// <summary>
            /// The rover is moved to desired position successfuly.
            /// </summary>
            internal const string RMR03 = "The rover is moved to desired position successfuly.";
        }
    }
       
}

