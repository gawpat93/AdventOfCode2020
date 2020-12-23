using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    public static class Tools
    {

        public static int GetOneJoltMultipliedByThreeJoltDifferences(string inputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            var jolts = lines.Select(int.Parse).OrderBy(x => x).ToArray();
            var gaps = new List<int> { jolts[0] };
            for (var i = 0; i < jolts.Length - 1; i++)
            {
                gaps.Add(jolts[i + 1] - jolts[i]);
            }
            gaps.Add(3); // difference between las jolt and my device

            return gaps.Count(x => x == 3) * gaps.Count(x => x == 1);
        }
    }
}