using System;
using System.Collections.Generic;

namespace Day7.Models
{
    public class Bag
    {
        public Bag(string color, IEnumerable<Tuple<int, Bag>> canContain = null)
        {
            Color = color;
            CanContain = canContain;
        }

        public IEnumerable<Tuple<int, Bag>> CanContain { get; }
        public string Color { get; }
    }
}
