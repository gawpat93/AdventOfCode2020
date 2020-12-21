using System;
using System.Linq;

namespace Day5
{
    public static class Tools
    {
        private const int TOTAL_ROWS = 128;
        private const int TOTAL_SEATS = 8;
        private const char BACK = 'B';
        private const char FRONT = 'F';
        private const char RIGHT = 'R';
        private const char LEFT = 'L';

        public static int GetSeatId(string key)
        {
            if (string.IsNullOrWhiteSpace(key) || key.Length != 10)
                throw new Exception("Wrong input key!");

            char[] rowKeys = key.Substring(0, 7).ToCharArray();
            if (!rowKeys.All(x => x == FRONT || x == BACK))
                throw new Exception("Wrong row keys");
            char[] seatKeys = key.Substring(7, 3).ToCharArray();
            if (!seatKeys.All(x => x == RIGHT || x == LEFT))
                throw new Exception("Wrong seat keys");

            var row = FindSeatRowNumber(rowKeys);
            var seat = FindSeatRowNumber(seatKeys, true);
            return row * 8 + seat;
        }

        private static int FindSeatRowNumber(char[] keys, bool seat = false)
        {
            var min = 0;
            var max = (seat ? TOTAL_SEATS : TOTAL_ROWS) - 1;
            foreach (var key in keys)
            {
                var mid = (max - min) / 2 + 1;
                if (key == (seat ? LEFT : FRONT))
                {
                    max -= mid;
                }
                else
                {
                    min += mid;
                }
            }

            if (min == max)
            {
                return max;
            }

            throw new Exception("Error in Tools.FindSeatRowNumber");
        }
    }
}