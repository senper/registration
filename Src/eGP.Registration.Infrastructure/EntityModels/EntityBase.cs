using System;

namespace eGP.Registration.Persistance.Models
{
    public abstract class EntityBase<TId> : ITrackable
    {
        public TId Id { get; set; }
    }

    public abstract class EntityBaseInt : EntityBase<int>
    {

    }
    public abstract class EntityBaseGuid : EntityBase<Guid>
    {


        public DateTime DateCreated { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? DateModified { get; set; }

        public Guid? ModifiedBy { get; set; }



        //TODO: to be tested 
        //[Timestamp]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[Column("xmin", TypeName = "xid")]
        // public uint RowVersion {get;set;}

    }
}
