using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Core.Entities
{
    public abstract class Identity
    {
        public int Id { get; set; }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
