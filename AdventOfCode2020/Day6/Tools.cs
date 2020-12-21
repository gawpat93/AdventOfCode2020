using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day6
{
    public static class Tools
    {
        public static int QuestionsAnsweredYes(string inputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            var groups = new List<string>();
            var current = new StringBuilder();
            for (var i = 0; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    groups.Add(current.ToString());
                    current.Clear();
                }
                else
                {
                    current.Append($"{lines[i]}");
                }
            }

            groups.Add(current.ToString());
            current.Clear();

            var sum = 0;
            groups.ForEach(group => sum += group.ToCharArray().ToList().Distinct().Count());
            return sum;
        }

        public static int QuestionsAnsweredYesByAllPersonsInSameGroup(string inputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            var groups = new List<string>();
            var current = new StringBuilder();
            for (var i = 0; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    groups.Add(current.ToString());
                    current.Clear();
                }
                else
                {
                    current.Append($"{lines[i]};");
                }
            }

            groups.Add(current.ToString());
            current.Clear();

            var sum = 0;

            groups.ForEach(group =>
            {
                var persons = group.Split(";").Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.ToCharArray()).ToList();
                var intersect = (IEnumerable<char>)persons.First();
                persons.ForEach(person =>
                {
                    intersect = person.Intersect(intersect);
                });
                sum += intersect.Count();
            });

            return sum;
        }
    }
}