using System;
using System.IO;
using System.Linq;

namespace Day1
{
    public static class Tools
    {
        private const int SEARCHED_SUM = 2020;

        public static int MultiplyThreeElementsOfSearchedSum(string inputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            var array = lines.Select(int.Parse).ToArray();

            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] > SEARCHED_SUM) continue;
                for (var j = 0; j < array.Length; j++)
                {
                    if (i == j) continue;
                    if (array[i] + array[j] > SEARCHED_SUM) continue;
                    for (var k = 0; k < array.Length; k++)
                    {
                        if (i == j || i == k || j == k) continue;

                        if (array[i] + array[j] + array[k] == SEARCHED_SUM)
                        {
                            return array[i] * array[j] * array[k];
                        }
                    }
                }
            }

            throw new Exception("Not found");
        }

        public static int MultiplyTwoElementsOfSearchedSum(string inputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            var array = lines.Select(int.Parse).ToArray();

            for (var i = 0; i < array.Length; i++)
            {
                for (var j = 0; j < array.Length; j++)
                {
                    if (i == j) continue;

                    if (array[i] + array[j] == SEARCHED_SUM)
                    {
                        return array[i] * array[j];
                    }
                }
            }

            throw new Exception("Not found");
        }
    }
}