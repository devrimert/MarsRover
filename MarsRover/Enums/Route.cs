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
        public static string RouteEnumToString(Route Route)
        {
            return Enum.GetName(typeof(Route), Route);
        }
    }
}
