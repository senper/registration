using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using eGP.Abstration.Domain;
using GP.Registration.Domain.Events;

namespace eGP.Registration.Domain.Organization
{
    public class Organization: Entity<Guid>, IAggregateRoot
    {

        public string Code { get; private set; }

        public OrganizationStatus  Status { get; private set; }
        public string ShortName { get; private set; }
        public string Name { get; private set; }
        public string Version { get; private set; }

        public Guid RootStructureId { get; private set; }

        private Organization(Guid id) : base(id)
        {

        }

        public void ChangeName(string name, string shortName)
        {
            Name = name;
            ShortName = shortName;
            AddDomainEvent(new OrganizationNameChangeDomainEvent(this));
        }

        public void ChangeVersion(string version)
        {
            Version = version;
        }
        public void SetProfile(string profile)
        {
            this.Profile = profile;
        }

        public string Profile { get; private set; }

        

        public static Organization LoadData(Guid id, 
            string name,
            string shortName,
            string code,
            int statusid,
            string version,
            Guid rootStructureId,
            string profile)
        {
            var status = Enumeration.FromValue<OrganizationStatus>(statusid);
            var org = new Organization(id)
            {
                Name = name,
                ShortName = shortName,
                Code = code,
                Status = status,
                RootStructureId = rootStructureId,
                Version = version,
                Profile = profile
            };
            return org;
        }
        public static Organization Register( string name, string shortName, string code)
        {
            var id = Guid.NewGuid();
            var org = new Organization(id)
            {
                Name = name,
                Code = code,
                ShortName = shortName,
                Status = OrganizationStatus.New,
                RootStructureId = OrganizationalStructure.CreateRoot(id, code).Id
            };
            return org;

        }


    }
}
