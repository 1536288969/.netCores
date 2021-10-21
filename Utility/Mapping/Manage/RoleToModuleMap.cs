using Entity.Manage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Mapping.Manage
{
  public  class RoleToModuleMap : IEntityTypeConfiguration<RoleToModule>
    {
        public void Configure(EntityTypeBuilder<RoleToModule> builder)
        {
            builder.ToTable("RoleToModule");
            builder.HasKey(t => t.ID);
            builder.Property(t => t.ID).HasColumnName("ID");
            builder.Property(t => t.RoleID).HasColumnName("RoleID");
            builder.Property(t => t.MenuID).HasColumnName("MenuID");
            builder.Property(t => t.Flag).HasColumnName("Flag");
            builder.HasOne(t => t.Role).WithMany(t => t.RoleToModules).HasForeignKey(t => t.RoleID);
        }
    }
}
