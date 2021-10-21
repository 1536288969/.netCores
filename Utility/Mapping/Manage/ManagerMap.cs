using Entity;
using Entity.Manage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Mapping.Manage
{
    public class ManagerMap : IEntityTypeConfiguration<Manager>
    {
        //public override void Config(EntityTypeBuilder<Information> builder)
        //{
        //    builder.ToTable("Informations");
        //}
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.ToTable("Manager");
            builder.HasKey(t => t.ID);
            builder.Property(t => t.ID).HasColumnName("ID");
            builder.Property(t => t.Email).HasColumnName("Email").HasMaxLength(30);
            builder.Property(t => t.ManagerAccount).HasColumnName("ManagerAccount").HasMaxLength(30);
            builder.Property(t => t.ManagerPwd).HasColumnName("ManagerPwd").HasMaxLength(100);
            builder.Property(t => t.RealName).HasColumnName("RealName").HasMaxLength(50);
            builder.Property(t => t.Remark).HasColumnName("Remark").HasMaxLength(400);
            builder.Property(t => t.RoleID).HasColumnName("RoleID");
            builder.Property(t => t.Telephone).HasColumnName("Telephone").HasMaxLength(16);
            builder.Property(t => t.OrderBy).HasColumnName("OrderBy");
            builder.Property(t => t.Status).HasColumnName("Status");
            builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(t => t.CreatedTime).HasColumnName("CreatedTime");
            builder.Property(t => t.RevisedBy).HasColumnName("RevisedBy");
            builder.Property(t => t.RevisedTime).HasColumnName("RevisedTime");
            builder.HasOne(t => t.Role).WithMany(t => t.Managers).HasForeignKey(t => t.RoleID);
        }

    }
}
