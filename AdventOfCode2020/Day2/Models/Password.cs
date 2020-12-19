namespace Day2.Models
{
    internal class Password
    {
        public Password(string value, Policy policy, NewPolicy newPolicy)
        {
            Value = value;
            Policy = policy;
            NewPolicy = newPolicy;
        }

        public bool Validate()
        {
            var count = Value.Split(Policy.Char).Length - 1;
            return count >= Policy.Min && count <= Policy.Max;
        }
        
        public bool ValidateNewPolicy()
        {
            var chars = Value.ToCharArray();
            var char1 = chars[NewPolicy.PossiblePositions[0] - 1];
            var char2 = chars[NewPolicy.PossiblePositions[1] - 1];
            return (Policy.Char == char1 && Policy.Char != char2) || (Policy.Char != char1 && Policy.Char == char2);
        }

        public Policy Policy { get; }
        public NewPolicy NewPolicy { get; }
        public string Value { get; }
    }
}
