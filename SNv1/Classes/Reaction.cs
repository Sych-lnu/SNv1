using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNv1
{
    public class Reaction
    {
        public Reaction(string description, int count)
        {
            Description = description;
            Count = count;
        }
        public Reaction(string description)
        {
            Description = description;
            Count = 1;

        }
        public Reaction()
        {
            Description = "like";
            Count = 1;
        }
        public string Description { get; set; }
        public int Count { get; set; }

    }
}
