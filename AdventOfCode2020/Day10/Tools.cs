using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day10
{
    public static class Tools
    {
        private const int MAX_DISTANCE = 3;

        public static long GetNumberOfAllPossibleCombinations(string inputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            var jolts = lines.Select(int.Parse).ToList();
            jolts.Add(jolts.Max() + 3);
            jolts.Add(0);
            return Combinations(jolts.OrderBy(x => x).ToList());
        }

        public static int GetOneJoltMultipliedByThreeJoltDifferences(string inputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            var jolts = lines.Select(int.Parse).OrderBy(x => x).ToArray();
            var gaps = new List<int> { jolts[0] };
            for (var i = 0; i < jolts.Length - 1; i++)
            {
                gaps.Add(jolts[i + 1] - jolts[i]);
            }
            gaps.Add(3); // difference between last jolt and my device

            return gaps.Count(x => x == 3) * gaps.Count(x => x == 1);
        }

        private static long Combinations(List<int> list)
        {
            long result = 1;
            for (var i = 1; i < list.Count - 1; i++)
            {
                var previous = list[i - 1];
                var next = list[i + 1];
                if (next - previous <= MAX_DISTANCE)
                {
                    var subList = new List<int>
                    {
                        list[i - 1]
                    };
                    subList.AddRange(list.GetRange(i + 1, list.Count - i - 1));
                    result += Combinations(subList);
                }
            }

            return result;
        }
    }
}