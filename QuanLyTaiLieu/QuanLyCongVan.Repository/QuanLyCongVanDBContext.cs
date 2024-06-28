using CuaHangBanLe.Domain.EntityMapper;
using Microsoft.EntityFrameworkCore;
using QuanLyTaiLieu.Domain.EntityMapper;
using QuanLyTaiLieu.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiLieu.Repository
{
    public class QuanLyCongVanDBContext : DbContext
    {
        public QuanLyCongVanDBContext(DbContextOptions<QuanLyCongVanDBContext> options) : base(options)
        {

        }
        public QuanLyCongVanDBContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new DocumentMap());
            modelBuilder.ApplyConfiguration(new NumberDocMap());
            modelBuilder.ApplyConfiguration(new PlaceDocMap());
            modelBuilder.ApplyConfiguration(new TypeDocMap());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Account> Account { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<NumberDoc> NumberDoc { get; set; }
        public DbSet<PlaceDoc> PlaceDoc { get; set; }
        public DbSet<TypeDoc> TypeDoc { get; set; }


    }
}
