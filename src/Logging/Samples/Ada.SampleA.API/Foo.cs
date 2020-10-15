using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ada.SampleA.API
{
    public class Foo
    {
        public int Id { get; set; }

        public string Name { get;set; }

        public Foo Node { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Node)}={Node}}}";
        }
    }
}
