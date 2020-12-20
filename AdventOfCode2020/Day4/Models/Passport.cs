using System.Collections.Generic;
using System.Linq;

namespace Day4.Models
{
    public class Passport
    {
        public Passport(string data)
        {
            Fields = new Dictionary<string, string>();
            var fields = data.Split(' ');
            fields.Where(x => !string.IsNullOrWhiteSpace(x)).ToList().ForEach(x =>
              {
                  var elements = x.Split(':');
                  Fields.Add(elements[0], elements[1]);
              });
        }

        public Dictionary<string, string> Fields { get; }
    }
}
