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
    public class PlaceDocMap : IEntityTypeConfiguration<PlaceDoc>
    {
        public void Configure(EntityTypeBuilder<PlaceDoc> builder)
        {
            builder.ToTable("PlaceDoc")
                .HasKey(x => x.PlaceDocId)
                .HasName("pk_PlaceDoc");

            builder.Property(x => x.PlaceDocId)
                .HasColumnName("PlaceDocId")
                .HasColumnType("INT");

            builder.Property(x => x.PlaceDocName)
                .HasColumnName("PlaceDocName")
                .HasColumnType("NVARCHAR(100)");

            builder.Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR(200)");

        }
    }
}
