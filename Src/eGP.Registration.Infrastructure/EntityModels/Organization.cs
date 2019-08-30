using eGP.Registration.Persistance.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using eGP.Registration.Domain.Organization;

namespace eGP.Registration.Persistance.EntityModels
{

  
    public class Organization : EntityBaseGuid
    {
        public String Code { get; set; }
        public String Name { get; set; }
        public string ShortName { get; set; }

        public int StatusId { get; set; }
        public string Version { get; set; }

        public String Profile { get; set; }

        public Guid RootStructureId { get; set; }


        public static Expression<Func<Organization, Domain.Organization.Organization>> Projection
        {
            get
            {
                return org => Domain.Organization.Organization.LoadData(
                    org.Id,
                    org.Name,
                    org.ShortName,
                    org.Code,
                    org.StatusId,
                    org.Version,
                    org.RootStructureId,
                    org.Profile
                );
            }
        }

        public Domain.Organization.Organization ToModel
        {
            get
            {
                var org = this;
                return Domain.Organization.Organization.LoadData(
                    org.Id,
                    org.Name,
                    org.ShortName,
                    org.Code,
                    org.StatusId,
                    org.Version,
                    org.RootStructureId,
                    org.Profile
                );
            }
        }

        public static Organization FromModel(Domain.Organization.Organization model)
        {
            return new Organization()
            {
                Id = model.IsTransient()? Guid.NewGuid() : model.Id,
                Code = model.Code,
                Name = model.Name,
                ShortName = model.ShortName,
                StatusId = model.Status.Id,
                RootStructureId = model.RootStructureId,
                Version = model.Version,
                Profile = model.Profile
            };
        }

    }
}
