using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ForumProject.Core.Entities
{
    public abstract class Identity
    {
        [Key]
        public int Id { get; set; }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
