using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyTaiLieu.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiLieu.Domain.EntityMapper
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account")
                .HasKey(x => x.UserName)
                .HasName("pk_accountid");

            builder.Property(x => x.UserName)
             .HasColumnName("UserName")
             .HasColumnType("NVARCHAR(30)");

            builder.Property(x => x.FullName)
              .HasColumnName("FullName")
              .HasColumnType("NVARCHAR(50)");

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR(50)");

            builder.Property(x => x.Phone)
               .HasColumnName("Phone")
               .HasColumnType("NVARCHAR(20)");

            builder.Property(x => x.Password)
                .HasColumnName("Password")
                .HasColumnType("NVARCHAR(20)");

            builder.Property(x => x.DateTime)
                .HasColumnName("DateTime")
                .HasColumnType("DateTime");

            builder.Property(x => x.RoleId)
                .HasColumnName("RoleId")
                .HasColumnType("VARCHAR(30)");


        }
    }
}