using System;

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
        public static string MoveEnumToString(MovePath Path)
        {
            return Enum.GetName(typeof(MovePath), Path);
        }
    }
}
