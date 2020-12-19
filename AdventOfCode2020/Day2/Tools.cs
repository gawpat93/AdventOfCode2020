using Day2.Models;
using System.IO;
using System.Linq;

namespace Day2
{
    public static class Tools
    {
        public static int ValidatePasswords(string inputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            var passwords = lines.Select(GetPasswordFromLine);
            var validPasswordsNumber = 0;
            foreach (var password in passwords)
            {
                if (password.Validate())
                {
                    validPasswordsNumber++;
                }
            }

            return validPasswordsNumber;
        }

        public static int ValidatePasswordsWithNewPolicy(string inputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            var passwords = lines.Select(GetPasswordFromLine);
            var validPasswordsNumber = 0;
            foreach (var password in passwords)
            {
                if (password.ValidateNewPolicy())
                {
                    validPasswordsNumber++;
                }
            }

            return validPasswordsNumber;
        }

        private static NewPolicy GetNewPolicy(string[] values)
        {
            var range = values[0].Split('-').Select(int.Parse).ToArray();
            var character = values[1].First();
            return new NewPolicy(character, range);
        }

        private static Password GetPasswordFromLine(string line)
        {
            string[] values = line.Split(' ');
            return new Password(values[2], GetPolicy(values), GetNewPolicy(values));
        }

        private static Policy GetPolicy(string[] values)
        {
            var range = values[0].Split('-');
            char _char = values[1].First();
            var min = int.Parse(range[0]);
            var max = int.Parse(range[1]);
            return new Policy(_char, min, max);
        }
    }
}