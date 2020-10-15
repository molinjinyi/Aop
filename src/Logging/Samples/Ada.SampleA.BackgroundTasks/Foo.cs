using System;
using System.Collections.Generic;
using System.Text;

namespace Ada.SampleA.BackgroundTasks
{
    class Foo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}}}";
        }
    }
}
