using System;
using System.Collections.Generic;
using eGP.Registration.Persistance.EntityModels;
using eGP.Registration.Persistance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eGP.Registration.Persistance.Configurations
{
    /// <summary>
    /// Code first configuration information for Organization table
    /// </summary>
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        /// <summary>
        /// Configures the Organization table.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
           ConfigureBase(builder);
            builder.Property(o => o.Code)
                .HasColumnName("code")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(o => o.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Property(o => o.ShortName)
                .HasColumnName("short_name")
                .HasColumnType("varchar(50)")
                .IsRequired(false);

            builder.Property(o => o.Version)
                .HasColumnName("version")
                .HasColumnType("varchar(50)")
                .IsRequired(false);

            builder.Property(o => o.Profile)
                .HasColumnName("profile")
                .HasColumnType("jsonb")
                .IsRequired(false);

            builder.Property(o => o.RootStructureId)
                .HasColumnName("root_structure_id")
                .HasColumnType("uuid")
                .IsRequired();

           SeedData(builder);

            builder.ToTable("organizations", "registration");

        }


        /// <summary>
        /// Duplicate this part of the code and replace Organization with corresponding generic parameter
        /// </summary>
        /// <param name="builder"></param>
        private void ConfigureBase(EntityTypeBuilder<Organization> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.DateCreated)
                .HasColumnName("date_created")
                .HasColumnType("timestamptz")
                .IsRequired();

            builder.Property(o => o.CreatedBy)
                .HasColumnName("created_by")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(o => o.DateModified)
                .HasColumnName("date_modified")
                .HasColumnType("timestamptz")
                .IsRequired(false);

            builder.Property(o => o.ModifiedBy)
                .HasColumnName("modified_by")
                .HasColumnType("uuid")
                .IsRequired(false);
        }
        public void SeedData(EntityTypeBuilder<Organization> builder)
        {
            var abc = new  string[]{"ABC","ABC", "ACB", "BAC", "BCA", "CAB", "CBA"};
            var lst = new List<Organization>();
            for (var i = 1; i < 5; i++)
            {
                var org = new Organization()
                {
                    Id = GetSample($"00{i}"),
                    ShortName = abc[i],
                    Name = $"Ministry of {abc[i]}",
                    Version = "0.0.1",
                    Code = "axy0{i}",
                    CreatedBy = GetSample($"0{i}0"),
                    DateCreated = DateTime.UtcNow,
                    RootStructureId = GetSample($"{i}00")

                };
                lst.Add(org);
            }

            builder.HasData(lst.ToArray());
        }

        private Guid GetSample(string lastThree)
        {
            var guidTemplate = "00000000-0000-0000-0000-000000000xyz";
            var guid = guidTemplate.Replace("xyz", lastThree);
            return Guid.Parse(guid);
        }
    }
}