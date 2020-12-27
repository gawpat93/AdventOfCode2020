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

        //optimization with help https://github.com/LennardF1989/AdventOfCode2020/blob/master/Src/AdventOfCode2020/Days/Day13.cs
        public static long GetResultPart2(string inputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            var buses = lines[1].Split(",").Select(x => long.TryParse(x, out var tmp) ? tmp : 0).ToArray();
            long result = 0;
            var increment = buses[0];
            var i = 1;
            while (i < buses.Length)
            {
                if (buses[i] == 0)
                {
                    i++;
                    continue;
                }

                result += increment;
                if ((result + i) % buses[i] != 0)
                {
                    continue;
                }

                increment *= buses[i];
                i++;
            }

            return result;
        }
    }
}