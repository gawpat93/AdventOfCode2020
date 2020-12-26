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
            var buses = lines[1].Split(",");
            int timeStamp = 0;
            while (true)
            {
                timeStamp += int.Parse(buses[0]);
                var condition = true;
                for (var i = 1; i < buses.Length; i++)
                {
                    if (buses[i] == "x") continue;
                    var busId = int.Parse(buses[i]);
                    if ((timeStamp + i) % busId != 0)
                    {
                        condition = false;
                        break;
                    }
                }

                if (condition)
                {
                    break;
                }
            }

            return timeStamp;
        }
    }
}