namespace Day2.Models
{
    internal class Policy
    {
        public Policy(char _char, int min, int max)
        {
            Char = _char;
            Max = max;
            Min = min;
        }

        public char Char { get; }
        public int Max { get; }
        public int Min { get; }
    }
}
