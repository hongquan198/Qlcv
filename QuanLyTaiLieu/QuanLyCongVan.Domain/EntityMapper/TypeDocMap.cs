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
    public class TypeDocMap : IEntityTypeConfiguration<TypeDoc>
    {
        public void Configure(EntityTypeBuilder<TypeDoc> builder)
        {
            builder.ToTable("TypeDoc")
                .HasKey(x => x.TypeDocId)
                .HasName("pk_TypeDoc");

            builder.Property(x => x.TypeDocId)
                .HasColumnName("TypeDocId")
                .HasColumnType("INT");

            builder.Property(x => x.TypeDocName)
                .HasColumnName("TypeDocName")
                .HasColumnType("NVARCHAR(100)");

            builder.Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR(200)");

        }
    }
}
