using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Core.Entities
{
    public class InstagramAccount : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<string> Tags { get; set; }

        public int Subscribers { get; set; }
    }
}
