using Entity.Manage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Mapping.Manage
{
   public class ModuleMap : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.ToTable("Module");
            builder.HasKey(t => t.ID);
            builder.Property(t => t.ID).HasColumnName("ID");
            builder.Property(t => t.ModuleName).HasColumnName("ModuleName").HasMaxLength(50);
            builder.Property(t => t.ParentID).HasColumnName("ParentID");
            builder.Property(t => t.Path).HasColumnName("Path");
            builder.Property(t => t.Url).HasColumnName("Url");
        }
    }   
}
