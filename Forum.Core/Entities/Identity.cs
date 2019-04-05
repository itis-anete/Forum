using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Core.Entities
{
    public abstract class Identity
    {
        public Guid Id { get; private set; }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
