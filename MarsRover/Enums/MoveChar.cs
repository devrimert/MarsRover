using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Enums
{
    public class MoveEnums
    {
        public enum MovePath : byte
        {
            L = 0, M = 1, R = 2
        }
        /// <summary>
        /// Returns route enumarator as a string.
        /// </summary>
        /// <param name="Route"></param>
        /// <returns></returns>
        public static string MoveEnumToString(MovePath Route)
        {
            return Enum.GetName(typeof(MovePath), Route);
        }
    }
}
