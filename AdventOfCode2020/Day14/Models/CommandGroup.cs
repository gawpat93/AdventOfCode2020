using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14.Models
{
    public class CommandGroup
    {
        private const int BINARY_NUMBER_LENGTH = 36;

        public CommandGroup(string mask)
        {
            Mask = mask;
            Memory = new Dictionary<int, long>();
        }

        private string Mask { get; set; }

        private Dictionary<int, long> Memory { get; }

        public void AddMemoryCommand(int id, long value)
        {
            value = GetMaskedValue(value);
            if (!Memory.TryAdd(id, value)) Memory[id] = value;
        }

        public void ChangeMask(string mask)
        {
            Mask = mask;
        }

        public long GetMemoryValuesSum()
        {
            return Memory.Aggregate<KeyValuePair<int, long>, long>(0, (current, keyValuePair) => current + keyValuePair.Value);
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
                if (maskChar != 'X' && (maskChar == '0' || maskChar == '1'))
                {
                    binaryNumberCharArray[i] = maskChar;
                }
            }

            var stringValue = new string(binaryNumberCharArray);
            return Convert.ToInt64(stringValue, 2);
        }
    }
}
