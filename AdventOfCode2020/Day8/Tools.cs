using Day8.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8
{
    public static class Tools
    {
        const string INCREASE_ACCUMULATOR_COMMAND = "acc";
        const string JUMP_COMMAND = "jmp";
        const string NO_OPERATION_COMMAND = "nop";

        public static int GetAccumulatorValueBeforeInfinitiveLoop(string inputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            var commands = lines.Select(line =>
            {
                var items = line.Split(" ");
                return new Command(items[0], int.Parse(items[1]));
            }).ToArray();

            var accumulatorValue = 0;
            var i = 0;
            var visitedIndexes = new List<int>();
            while (!visitedIndexes.Contains(i))
            {
                visitedIndexes.Add(i);
                var current = commands[i];
                switch (current.Name)
                {
                    case NO_OPERATION_COMMAND:
                        i++;
                        break;
                    case INCREASE_ACCUMULATOR_COMMAND:
                        accumulatorValue += current.Value;
                        i++;
                        break;
                    case JUMP_COMMAND:
                        i += current.Value;
                        break;
                    default:
                        throw new Exception("Wrong command name!");
                }
            }

            return accumulatorValue;
        }
    }
}