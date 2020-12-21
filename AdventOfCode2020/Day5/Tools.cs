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

            var row = FindRowNumber(rowKeys);
            var seat = FindSeatNumber(seatKeys);
            return row * 8 + seat;
        }

        private static int FindRowNumber(char[] rowKeys)
        {
            var rowMin = 0;
            var rowMax = TOTAL_ROWS - 1;
            foreach (var rowKey in rowKeys)
            {
                var mid = (rowMax - rowMin) / 2 + 1;
                if (rowKey == FRONT)
                {
                    rowMax -= mid;
                }
                else
                {
                    rowMin += mid;
                }
            }

            if (rowMin == rowMax)
            {
                return rowMax;
            }

            throw new Exception("Error in Tools.FindRowNumber");
        }

        private static int FindSeatNumber(char[] seatKeys)
        {
            var min = 0;
            var max = TOTAL_SEATS - 1;
            foreach (var seatKey in seatKeys)
            {
                var mid = (max - min) / 2 + 1;
                if (seatKey == LEFT)
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

            throw new Exception("Error in Tools.FindRowNumber");
        }
    }
}