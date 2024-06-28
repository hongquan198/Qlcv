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
    public class DocumentMap : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("Document")
                .HasKey(x => x.DocumentId)
                .HasName("pk_document");

            builder.Property(x => x.DocumentId)
          .HasColumnName("DocumentId")
          .HasColumnType("INT");

            builder.Property(x => x.Signer)
             .HasColumnName("Signer")
             .HasColumnType("NVARCHAR(50)");

            builder.Property(x => x.ApprovedBy)
             .HasColumnName("ApprovedBy")
             .HasColumnType("NVARCHAR(50)");

            builder.Property(x => x.NumberPage)
            .HasColumnName("NumberPage")
            .HasColumnType("INT");

            builder.Property(x => x.NumberSymbols)
            .HasColumnName("NumberSymbols")
            .HasColumnType("NVARCHAR(40)");

            builder.Property(x => x.DateTime)
                .HasColumnName("DateTime")
                .HasColumnType("DateTime");

            builder.Property(x => x.Abstract)
            .HasColumnName("Abstract")
            .HasColumnType("NVARCHAR(500)");


            builder.Property(x => x.Content)
            .HasColumnName("Content")
            .HasColumnType("NVARCHAR(MAX)");

            //Đến

            builder.Property(x => x.Receive)
            .HasColumnName("Receive")
            .HasColumnType("NVARCHAR(40)");

            builder.Property(x => x.NumberFrom)
            .HasColumnName("NumberFrom")
            .HasColumnType("INT");

            builder.Property(x => x.DateFrom)
               .HasColumnName("DateFrom")
               .HasColumnType("DateTime");

            // Đi



            builder.Property(x => x.Sender)
            .HasColumnName("Sender")
            .HasColumnType("NVARCHAR(40)");

            builder.Property(x => x.NumberGo)
         .HasColumnName("NumberGo")
         .HasColumnType("INT");

            builder.Property(x => x.Quantity)
         .HasColumnName("Quantity")
         .HasColumnType("INT");

            builder.Property(x => x.PlaceDocId)
              .HasColumnName("PlaceDocId")
              .HasColumnType("INT");

            builder.HasOne(c => c.PlaceDoc)
                .WithMany(p => p.Documents)
                .HasForeignKey(c => c.PlaceDocId)
                .HasConstraintName("fk_document_place");

            builder.Property(x => x.TypeDocId)
            .HasColumnName("TypeDocId")
            .HasColumnType("INT");

            builder.HasOne(c => c.TypeDoc)
                .WithMany(p => p.Documents)
                .HasForeignKey(c => c.TypeDocId)
                .HasConstraintName("fk_document_type");

            builder.Property(x => x.TypeDocId)
           .HasColumnName("TypeDocId")
           .HasColumnType("INT");

            builder.HasOne(c => c.TypeDoc)
                .WithMany(p => p.Documents)
                .HasForeignKey(c => c.TypeDocId)
                .HasConstraintName("fk_document_type");


            builder.Property(x => x.NumberDocCode)
        .HasColumnName("NumberDocCode")
        .HasColumnType("VARCHAR(50)");

            builder.HasOne(c => c.NumberDoc)
                .WithMany(p => p.Documents)
                .HasForeignKey(c => c.NumberDocCode)
                .HasConstraintName("fk_document_number");
        }
    }
}