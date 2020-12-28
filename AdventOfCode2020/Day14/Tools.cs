using Day14.Models;
using System.IO;

namespace Day14
{
    public static class Tools
    {
        private const string MASK = "mask";

        public static long GetResultPart1(string inputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            var commandGroup = new CommandGroup(string.Empty);
            foreach (var line in lines)
            {
                var elements = line.Split('=');
                if (elements[0].Trim() == MASK)
                {
                    commandGroup.ChangeMask(elements[1].Trim());
                }
                else
                {
                    var id = GetIdFromLineString(line);
                    var value = int.Parse(elements[1].Trim());
                    commandGroup?.AddMemoryCommand(id, value);
                }
            }

            return commandGroup.GetMemoryValuesSum();
        }

        public static long GetResultPart2(string inputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            var commandGroup = new CommandGroup(string.Empty);
            foreach (var line in lines)
            {
                var elements = line.Split('=');
                if (elements[0].Trim() == MASK)
                {
                    commandGroup.ChangeMask(elements[1].Trim());
                }
                else
                {
                    var id = GetIdFromLineString(line);
                    var value = int.Parse(elements[1].Trim());
                    commandGroup?.AddMemoryCommand2(id, value);
                }
            }

            return commandGroup.GetMemoryValuesSum();
        }

        private static int GetIdFromLineString(string line)
        {
            var elements = line.Split('=');
            return int.Parse(elements[0].Replace("]", "").Replace("mem[", ""));
        }
    }
}