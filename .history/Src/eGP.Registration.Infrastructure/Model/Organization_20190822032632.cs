using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using eGP.Abstration.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eGP.Registration.Infrastructure.Model
{
    public enum RecordStatus {
        Active = 1,
        Deleted = 2
    }
    public abstract class EntityBase<TId> {
        public TId Id {get;set;}

        public RecordStatus RecordStatus {get;set;}
        public DateTime DateCreated {get;set;}

        public String CreatedBy {get;set;}

        public DateTime DateModified {get;set;}

        public String ModifiedBy {get;set;}

        public DateTime DateDeleted {get;set;}

        public String DeletedBy {get;set;}

        public byte[] RowVersion {get;set;}

    }
    public class Organization : EntityBase<Guid>
    {
        public String Code { get; set; }
        public String Name { get; set; }
        public string ShortName { get; set; }

        public string Version { get; set; }

        [Column(TypeName = "jsonb")]
        public String Profile { get; set; }

        public Guid RootStructureId { get; set; }
    }

    public class OrganizationStructure: EntityBase<Guid>
    {
        public Guid OrganizationId { get; set; }
        public Guid ParentId { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }

        public int TypeId { get; set; }
        [Column(TypeName = "jsonb")]
        public String Profile { get; set; }
    }

    
    public class Placement: EntityBase<Guid>
    {
        public Guid OrganizationId { get; set; }
        public Guid StructureId { get; set; }
        public Guid PersonnelId { get; set; }
    }
}
