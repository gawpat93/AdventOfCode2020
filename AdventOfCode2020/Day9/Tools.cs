using System;
using System.IO;
using System.Linq;
using static System.Int64;

namespace Day9
{
    public static class Tools
    {

        public static long GetNotSumNumberAfterPreamble(string inputFileName, int preambleSize)
        {
            var lines = File.ReadAllLines(inputFileName);
            var values = lines.Select(Parse).ToArray();
            for (var index = preambleSize; index < values.Length; index++)
            {
                bool isSumOfPreviousTwoValues = false;
                var current = values[index];
                var previousValues = values[(index - preambleSize)..index];
                for (var i = 0; i < previousValues.Length; i++)
                {
                    if (isSumOfPreviousTwoValues)
                    {
                        break;
                    }

                    for (var j = 0; j < previousValues.Length; j++)
                    {
                        if (i == j) continue;

                        if (previousValues[i] + previousValues[j] == current)
                        {
                            isSumOfPreviousTwoValues = true;
                            break;
                        }
                    }
                }

                if (!isSumOfPreviousTwoValues)
                {
                    return current;
                }
            }

            throw new Exception("Error in Tools.GetNotSumNumberAfterPreamble");
        }

        public static long GetSumMinMAxOfContiguousSetOfAtLeastTwoNumbersThatSumToWeaknessNumber(string inputFileName, int preambleSize)
        {
            var sum = GetNotSumNumberAfterPreamble(inputFileName, preambleSize);

            var lines = File.ReadAllLines(inputFileName);
            var values = lines.Select(Parse).ToArray();
            for (var i = 0; i < values.Length - 1; i++)
            {
                var tmpSum = values[i];
                for (var j = i + 1; j < values.Length - 1; j++)
                {
                    tmpSum += values[j];

                    if (tmpSum == sum)
                    {
                        var searchList = values[i..j].ToList();
                        return searchList.Max() + searchList.Min();
                    }

                    if (tmpSum > sum)
                    {
                        break;
                    }
                }
            }

            throw new Exception("Error in Tools.GetSumMinMAxOfContiguousSetOfAtLeastTwoNumbersThatSumToWeaknessNumber");
        }
    }
}