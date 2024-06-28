using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyTaiLieu.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanLe.Domain.EntityMapper
{
    public class NumberDocMap : IEntityTypeConfiguration<NumberDoc>
    {
        public void Configure(EntityTypeBuilder<NumberDoc> builder)
        {
            builder.ToTable("NumberDoc")
                .HasKey(x => x.NumberDocCode)
                .HasName("pk_numberDoc");

            builder.Property(x => x.NumberDocCode)
                .HasColumnName("NumberDocCode")
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.NumberDocName)
                .HasColumnName("NumberDocName")
                .HasColumnType("NVARCHAR(100)");

            builder.Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR(200)");

        }
    }
}
