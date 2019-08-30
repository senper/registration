using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eGP.Abstration.Domain;

namespace eGP.Registration.Domain.Organization
{
    public class OrganizationStatus : Enumeration
    {
        public static readonly OrganizationStatus New = new OrganizationStatus(0, "New");
        public static readonly OrganizationStatus Activated = new OrganizationStatus(0, "Activated");
        public static readonly OrganizationStatus Disabled = new OrganizationStatus(0, "Disabled");
        protected OrganizationStatus()
        {
            
        }
        public OrganizationStatus(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<OrganizationStatus> List() =>
            new[] { New, Activated, Disabled };

        public static OrganizationStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new DomainException($"Possible values for OrganizationStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static OrganizationStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new DomainException($"Possible values for OrganizationStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
