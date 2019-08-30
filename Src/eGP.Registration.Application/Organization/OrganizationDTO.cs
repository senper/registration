using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace eGP.Registration.Application.Organization
{
    public class OrganizationDTOList
    {
        public IList<OrganizationDTO> Organizations { get; set; } = new List<OrganizationDTO>();
    }
    public class OrganizationDTO
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public Guid Id { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("shortName")]
        public string ShortName { get; set; }

        [Newtonsoft.Json.JsonProperty("code")]
        public string Code { get; set; }

        [Newtonsoft.Json.JsonProperty("statusId")]
        public int StatusId { get; set; }

        [Newtonsoft.Json.JsonProperty("versionNo")]
        public string VersionNo { get; set; }

        public static OrganizationDTO MapFrom(Domain.Organization.Organization org)
        {
                return  new OrganizationDTO()
                {
                    Id = org.Id,
                    Name = org.Name,
                    ShortName = org.ShortName,
                    Code = org.Code,
                    StatusId = org.Status.Id,
                    VersionNo = org.Version
                };
        
        }
        public static Expression<Func< Domain.Organization.Organization, OrganizationDTO>> Projection
        {
            get
            {
                return org => new OrganizationDTO() { 
                    Id = org.Id,
                    Name = org.Name,
                    ShortName = org.ShortName,
                    Code = org.Code,
                    StatusId = org.Status.Id,
                    VersionNo = org.Version
                };
            }
        }
    }

    public class OrganizationDetailDTO
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public Guid Id { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("shortName")]
        public string ShortName { get; set; }

        [Newtonsoft.Json.JsonProperty("code")]
        public string Code { get; set; }

        [Newtonsoft.Json.JsonProperty("versionNo")]
        public string VersionNo { get; set; }

        [Newtonsoft.Json.JsonProperty("rootStructureId")]
        public string RootStructureId { get; set; }

        [Newtonsoft.Json.JsonProperty("profile")]
        public string Profile { get; set; }
    }
}
