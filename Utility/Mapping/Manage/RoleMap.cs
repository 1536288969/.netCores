using Entity.Manage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Mapping.Manage
{
   public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(t => t.ID);
            builder.Property(t => t.ID).HasColumnName("ID");
            builder.Property(t => t.RoleName).HasColumnName("RoleName").HasMaxLength(30);
            builder.Property(t => t.Description).HasColumnName("Description").HasMaxLength(200);
            builder.Property(t => t.OrderBy).HasColumnName("OrderBy");
            builder.Property(t => t.Status).HasColumnName("Status");
            builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(t => t.CreatedTime).HasColumnName("CreatedTime");
            builder.Property(t => t.RevisedBy).HasColumnName("RevisedBy");
            builder.Property(t => t.RevisedTime).HasColumnName("RevisedTime");
            //builder.HasOne(t => t.Role).WithMany(t => t.Managers).HasForeignKey(t => t.RoleID);
        }
    }
}
