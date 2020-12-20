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

        private List<string> RequiredFields { get; }
        
    }
}
