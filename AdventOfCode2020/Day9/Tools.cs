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
    }
}