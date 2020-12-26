using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day13
{
    public static class Tools
    {
        public static long GetResultPart1(string inputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            var timeStamp = int.Parse(lines[0]);
            var buses = lines[1].Split(",").Where(x => x != "x").Select(int.Parse).ToList();
            var timestamps = new Dictionary<int, int>();
            foreach (var bus in buses)
            {
                var tmpTimestamp = 0;
                do
                {
                    tmpTimestamp += bus;
                } while (tmpTimestamp < timeStamp);
                timestamps.Add(bus, tmpTimestamp);
            }

            var minTimestamp = timestamps.FirstOrDefault().Value;
            var minTimestampBusId = timestamps.FirstOrDefault().Key;
            foreach (var (key, value) in timestamps)
            {
                if (value < minTimestamp)
                {
                    minTimestamp = value;
                    minTimestampBusId = key;
                }
            }

            return minTimestampBusId * (minTimestamp - timeStamp);
        }

        public static long GetResultPart2(string inputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            return 0;
        }
    }
}