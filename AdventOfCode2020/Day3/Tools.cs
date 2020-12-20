using System.ComponentModel;
using System.IO;

namespace Day3
{
    public static class Tools
    {
        private const char TREE = '#';
        public static int CountEncounteredTrees(string inputFileName,int slopeX=3,int slopeY = 1)
        {
            var lines = File.ReadAllLines(inputFileName);
            var length = lines[0].Length; 
            var treeCount = 0;
            var x = 0;
            for (var i = 0; i<lines.Length;i+=slopeY)
            {
                var current = lines[i];
                if (current[x] == TREE) treeCount++;
                x += slopeX;
                if (x >= length) x -= length;
            }

            return treeCount;
        }
    }
}