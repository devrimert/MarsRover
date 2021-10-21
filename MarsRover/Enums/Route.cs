using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Enums
{
    public class RouteEnums
    {
        public enum Route : byte
        {
            N = 0, E = 1, S = 2, W = 3
        }
        /// <summary>
        /// Returns route enumarator as a string.
        /// </summary>
        /// <param name="Route"></param>
        /// <returns></returns>
        public static string RouteEnumToString(Route Route)
        {
            return Enum.GetName(typeof(Route), Route);
        }
    }
}
