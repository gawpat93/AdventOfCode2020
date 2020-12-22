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

        public static int GetAccumulatorValue(string inputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            var commands = lines.Select(line =>
            {
                var items = line.Split(" ");
                return new Command(items[0], int.Parse(items[1]));
            }).ToArray();

            var history = GetIndexesBeforeInfinitiveLoop(commands);
            for (var j = history.Count - 1; j >= 0; j--)
            {
                var index = history[j];
                var cmd = commands[index];
                if (cmd.Name == INCREASE_ACCUMULATOR_COMMAND)
                {
                    continue;
                }
                
                var newCmd = new Command(cmd.Name == NO_OPERATION_COMMAND ? JUMP_COMMAND : NO_OPERATION_COMMAND, cmd.Value);

                var correctedCommands = commands;
                correctedCommands[index] = newCmd;

                var accumulatorValue = 0;
                var i = 0;
                var visitedIndexes = new List<int>();
                while (!visitedIndexes.Contains(i) && i < correctedCommands.Length)
                {
                    visitedIndexes.Add(i);
                    var current = correctedCommands[i];
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

                if (i >= correctedCommands.Length)
                {
                    return accumulatorValue;
                }
            }

            throw new Exception("Error in Tools.GetAccumulatorValue");
        }

        private static List<int> GetIndexesBeforeInfinitiveLoop(Command[] commands)
        {
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
                        i++;
                        break;
                    case JUMP_COMMAND:
                        i += current.Value;
                        break;
                    default:
                        throw new Exception("Wrong command name!");
                }
            }

            return visitedIndexes;
        }
    }
}