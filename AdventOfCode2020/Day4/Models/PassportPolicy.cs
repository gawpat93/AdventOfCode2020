using System.Collections.Generic;
using System.Linq;

namespace Day4.Models
{
    public class PassportPolicy
    {
        public PassportPolicy(IEnumerable<string> requiredFields)
        {
            RequiredFields = requiredFields.ToList();
        }

        public bool Validate(Passport passport)
        {
            return RequiredFields.All(x => passport.Fields.TryGetValue(x, out var value) && !string.IsNullOrWhiteSpace(value));
        }

        public bool ValidateCustomRules(Passport passport)
        {
            return RequiredFields.All(key => passport.Fields.TryGetValue(key, out var value) && !string.IsNullOrWhiteSpace(value) && ValidateFields(key, value));
        }

        private bool ValidateFields(string key, string value)
        {
            return key switch
            {
                //byr (Birth Year) - four digits; at least 1920 and at most 2002.
                "byr" => int.TryParse(value, out var result) && result >= 1920 && result <= 2002,
                //iyr (Issue Year) - four digits; at least 2010 and at most 2020.
                "iyr" => int.TryParse(value, out var result) && result >= 2010 && result <= 2020,
                //eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
                "eyr" => int.TryParse(value, out var result) && result >= 2020 && result <= 2030,
                "hgt" => ValidateHeight(value),
                "hcl" => ValidateHairColor(value),
                "ecl" => ValidateEyeColor(value),
                "pid" => ValidatePassportId(value),
                _ => true
            };
        }

        private bool ValidateHeight(string height)
        {
            /*hgt (Height) - a number followed by either cm or in:
                            If cm, the number must be at least 150 and at most 193.
                            If in, the number must be at least 59 and at most 76.*/
            if (height.EndsWith("cm"))
            {
                return int.TryParse(height.Substring(0, height.Length - 2), out var result) && result >= 150 && result <= 193;
            }

            if (height.EndsWith("in"))
            {
                return int.TryParse(height.Substring(0, height.Length - 2), out var result) && result >= 59 && result <= 76;
            }

            return false;
        }

        private bool ValidateHairColor(string color)
        {
            //hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
            char[] allowedChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
            return !string.IsNullOrWhiteSpace(color) && color[0] == '#' && color[1..].All(x => allowedChars.Any(y => y == x));
        }

        private bool ValidateEyeColor(string color)
        {
            //ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
            string[] allowedColors = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            return !string.IsNullOrWhiteSpace(color) && allowedColors.Any(x => x == color);
        }

        private bool ValidatePassportId(string id)
        {
            //pid (Passport ID) - a nine-digit number, including leading zeroes.

            return !string.IsNullOrWhiteSpace(id) && id.Length == 9 && int.TryParse(id, out _);
        }

        private List<string> RequiredFields { get; }

    }
}
