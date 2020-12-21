using System;
using System.IO;
using System.Linq;

namespace Day5
{
    public static class Tools
    {
        private const char BACK = 'B';
        private const char FRONT = 'F';
        private const char LEFT = 'L';
        private const char RIGHT = 'R';
        private const int TOTAL_ROWS = 128;
        private const int TOTAL_SEATS = 8;

        public static int FindMySeatId(string inputFileName)
        {
            var keys = File.ReadAllLines(inputFileName);
            var takenSeats = new int[keys.Length];
            int max = GetSeatId(keys[0]);
            int min = max;
            for (var i = 0; i < keys.Length; i++)
            {
                int value = GetSeatId(keys[i]);
                takenSeats[i] = value;
                if (value > max)
                {
                    max = value;
                }
                else if (value< min)
                {
                    min = value;
                }
            }
            
            var result = Enumerable.Range(min, max - min).Except(takenSeats).ToArray();
            
            if (result.Length == 1)
            {
                return result.First();
            }
            
            throw new Exception("Error in Tools.FindMySeatId");
        }

        public static int GetHighestSeatIdFromFile(string inputFileName)
        {
            var keys = File.ReadAllLines(inputFileName);
            int max = 0;
            foreach (var key in keys)
            {
                int id = GetSeatId(key);
                if (id > max)
                {
                    max = id;
                }
            }

            return max;
        }

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