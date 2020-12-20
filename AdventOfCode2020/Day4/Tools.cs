using Day4.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day4
{
    public static class Tools
    {
        public static int ValidPassports(string inputFileName)
        {
            int validPassports = 0;
            var lines = File.ReadAllLines(inputFileName);
            var passports = GetPassports(lines);
            string[] requiredFields =
            {
                "byr", // (Birth Year)
                "iyr", // (Issue Year)
                "eyr", // (Expiration Year)
                "hgt", // (Height)
                "hcl", // (Hair Color)
                "ecl", // (Eye Color)
                "pid", // (Passport ID)
                //"cid", // (Country ID) optional
            };
            var policy = new PassportPolicy(requiredFields);
            passports.ForEach(x=>
            {
                if (policy.Validate(x))
                {
                    validPassports++;
                }
            });
            
            return validPassports;
        }

        private static List<Passport> GetPassports(string[] lines)
        {
            var passportsData = new List<string>();
            var tmp = new StringBuilder();
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    tmp.Append($" {line}");
                }
                else
                {
                    passportsData.Add(tmp.ToString());
                    tmp.Clear();
                }
            }

            passportsData.Add(tmp.ToString());
            tmp.Clear();

            return passportsData.Select(x => new Passport(x)).ToList();
        }
    }
}