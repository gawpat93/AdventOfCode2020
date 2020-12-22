namespace Day8.Models
{
    public class Command
    {
        public Command(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public int Value { get; }
    }
}
