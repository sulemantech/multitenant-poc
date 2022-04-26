using System.Collections.Generic;

namespace multitenant_poc.Data.Entities
{
    public class College : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
