using Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Mapping.Common
{
  public  class LoggerMap : IEntityTypeConfiguration<Logger>
  {
     public void Configure(EntityTypeBuilder<Logger> builder)
     {
        builder.ToTable("Logger");
        builder.HasKey(t => t.ID);
        builder.Property(t => t.ID).HasColumnName("ID");
        builder.Property(t => t.Account).HasColumnName("Account").HasMaxLength(30);
        builder.Property(t => t.Description).HasColumnName("Description").HasMaxLength(300);
        builder.Property(t => t.IPAddress).HasColumnName("IPAddress").HasMaxLength(100);
        builder.Property(t => t.Status).HasColumnName("Status").HasMaxLength(50);
        builder.Property(t => t.LogType).HasColumnName("LogType");
        builder.Property(t => t.CreatedTime).HasColumnName("CreatedTime");
        builder.Property(t => t.IPAddressName).HasColumnName("IPAddressName");
        builder.Property(t => t.RealName).HasColumnName("RealName");
     }
  }
}
