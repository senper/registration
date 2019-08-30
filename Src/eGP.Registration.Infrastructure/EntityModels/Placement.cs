using System;

namespace eGP.Registration.Persistance.Models
{
    public class Placement: EntityBaseGuid
    {
        public Guid OrganizationId { get; set; }
        public Guid StructureId { get; set; }
        public Guid PersonnelId { get; set; }
    }
}