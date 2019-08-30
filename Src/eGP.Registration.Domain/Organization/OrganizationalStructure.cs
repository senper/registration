using System;
using eGP.Abstration.Domain;

namespace eGP.Registration.Domain.Organization
{
    public class OrganizationalStructure : Entity<Guid>, IAggregateRoot
    {
        public Guid OrganizationId { get; private set; }
        public Guid ParentId { get; private set; }

        public string Code { get; private set; }
        public string Name { get; private set; }

        public bool CanAddSubUnit { get; private set; }


        public SimpleLookup StructureType { get; set; }
        public OrganizationalStructure(Guid id) : base(id)
        {
        }

        public static OrganizationalStructure CreateRoot(Guid organizationId, string code)
        {
            return new OrganizationalStructure(Guid.NewGuid())
            {
                OrganizationId = organizationId,
                Code = code,
                Name ="Root",
                ParentId = Guid.Empty,
                StructureType = new SimpleLookup(0, "Root"),
                CanAddSubUnit = true,
                
            };
        }
        public  OrganizationalStructure AddSubUnit(SimpleLookup unitType, string unitName, bool canAddSubUnit)
        {
            if (!CanAddSubUnit)
            {
                throw new ArgumentOutOfRangeException();
            }
            return new OrganizationalStructure(Guid.NewGuid())
            {
                OrganizationId = this.OrganizationId,
                Code = this.Code + "." + ShortGuid.GenerateCode(2),
                Name = unitName,
                ParentId = this.Id,
                StructureType = unitType ,
                CanAddSubUnit = canAddSubUnit
            };

        }

    }
}