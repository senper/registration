using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGP.Registration.Persistance.Models
{
    public class OrganizationStructure: EntityBaseGuid
    {
        public Guid OrganizationId { get; set; }
        public Guid ParentId { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }

        public int TypeId { get; set; }
        [Column(TypeName = "jsonb")]
        public String Profile { get; set; }
    }
}