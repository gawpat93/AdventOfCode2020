using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14.Models
{
    public class CommandGroup
    {
        private const int BINARY_NUMBER_LENGTH = 36;
        private const char X = 'X';

        public CommandGroup(string mask)
        {
            Mask = mask;
            Memory = new Dictionary<long, long>();
        }

        private string Mask { get; set; }

        private Dictionary<long, long> Memory { get; }

        // Adds value to memory according to part1 rules
        public void AddMemoryCommand(int id, long value)
        {
            value = GetMaskedValue(value);
            if (!Memory.TryAdd(id, value)) Memory[id] = value;
        }

        // Adds value to memory according to part2 rules
        public void AddMemoryCommand2(int id, long value)
        {
            var ids = GetMaskedIds(id);
            foreach (var currentId in ids)
            {
                if (!Memory.TryAdd(currentId, value)) Memory[currentId] = value;
            }
        }

        public void ChangeMask(string mask)
        {
            Mask = mask;
        }

        public long GetMemoryValuesSum()
        {
            return Memory.Aggregate<KeyValuePair<long, long>, long>(0, (current, keyValuePair) => current + keyValuePair.Value);
        }

        private List<string> GetAllPossibleId(string id)
        {
            if (id.Any(x => x == X))
            {
                for (var i = 0; i < id.Length; i++)
                {
                    if (id[i] != X) continue;

                    var tmp0 = id.ToCharArray();
                    var tmp1 = id.ToCharArray();
                    tmp0[i] = '0';
                    tmp1[i] = '1';
                    return new List<string>
                    {
                        new(tmp0),
                        new(tmp1)
                    };
                }
            }

            return new List<string> { id };
        }

        private string GetBinaryNumberWithInsignificantZeros(long number)
        {
            var binaryString = Convert.ToString(number, 2);
            if (binaryString.Length < BINARY_NUMBER_LENGTH)
            {
                binaryString = binaryString.PadLeft(BINARY_NUMBER_LENGTH, '0');
            }

            return binaryString;
        }

        private List<long> GetMaskedIds(int id)
        {
            if (string.IsNullOrWhiteSpace(Mask))
            {
                throw new Exception("Mask cannot be null or empty!");
            }


            var binaryNumber = GetBinaryNumberWithInsignificantZeros(id);

            if (Mask.Length != binaryNumber.Length)
            {
                throw new Exception("Mask and binary number cannot have different length!");
            }

            var maskedList = new List<string>();

            var binaryNumberCharArray = binaryNumber.ToCharArray();
            for (var i = 0; i < Mask.Length; i++)
            {
                var maskChar = Mask[i];
                if (maskChar == 'X' || maskChar == '1')
                {
                    binaryNumberCharArray[i] = maskChar;
                }
            }

            maskedList.Add(new string(binaryNumberCharArray));

            do
            {
                var tmp = maskedList.Where(x => x.Any(y => y == X)).ToList();
                maskedList.RemoveAll(x => x.Any(y => y == X));
                foreach (var s in tmp)
                {
                    maskedList.AddRange(GetAllPossibleId(s));
                }

            } while (maskedList.Any(x => x.Any(y => y == X)));

            return maskedList.Select(x => Convert.ToInt64(x, 2)).ToList();
        }

        private long GetMaskedValue(long value)
        {
            if (string.IsNullOrWhiteSpace(Mask))
            {
                throw new Exception("Mask cannot be null or empty!");
            }

            var binaryNumber = GetBinaryNumberWithInsignificantZeros(value);

            if (Mask.Length != binaryNumber.Length)
            {
                throw new Exception("Mask and binary number cannot have different length!");
            }

            var binaryNumberCharArray = binaryNumber.ToCharArray();
            for (var i = 0; i < Mask.Length; i++)
            {
                var maskChar = Mask[i];
                if (maskChar != X && (maskChar == '0' || maskChar == '1'))
                {
                    binaryNumberCharArray[i] = maskChar;
                }
            }

            var stringValue = new string(binaryNumberCharArray);
            return Convert.ToInt64(stringValue, 2);
        }
    }
}
