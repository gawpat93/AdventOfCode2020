using System;

namespace Day12.Models
{
    public class Ship
    {
        public Ship(int eastWestValue, int northSouthValue, int waypointHorizontal, int waypointVertical)
        {
            EastWestValue = eastWestValue;
            NorthSouthValue = northSouthValue;
            WaypointHorizontal = waypointHorizontal;
            WaypointVertical = waypointVertical;
        }

        public int ManhattanDistance => Math.Abs(EastWestValue) + Math.Abs(NorthSouthValue);

        private int EastWestValue { get; set; }
        private int NorthSouthValue { get; set; }
        private int WaypointHorizontal { get; set; }
        private int WaypointVertical { get; set; }

        public void MoveShip(int times)
        {
            EastWestValue += WaypointHorizontal * times;
            NorthSouthValue += WaypointVertical * times;
        }

        public void MoveWaypoint(int x, int y)
        {
            WaypointHorizontal += x;
            WaypointVertical += y;
        }

        public void RotateWaypoint(int times, bool clockwise = true)
        {
            if (times == 0) return;

            var horizontal = WaypointHorizontal;
            var vertical = WaypointVertical;
            if (clockwise)
            {
                WaypointHorizontal = vertical;
                WaypointVertical = -horizontal;
            }
            else
            {
                WaypointHorizontal = -vertical;
                WaypointVertical = horizontal;
            }

            times--;
            if (times > 0) RotateWaypoint(times, clockwise);
        }
    }
}
