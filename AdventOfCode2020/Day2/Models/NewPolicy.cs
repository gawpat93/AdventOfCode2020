namespace Day2.Models
{
    internal class NewPolicy
    {
        public NewPolicy(char _char, int[] possiblePositions)
        {
            Char = _char;
            PossiblePositions = possiblePositions;
        }

        public char Char { get; }
        public int[] PossiblePositions { get; }
    }
}
