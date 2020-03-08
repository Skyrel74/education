using Cenema.Models.Domain;
using EntityFramework.DynamicFilters;
using System;
using System.Data.Entity;

namespace Cenema.DataBaseLayer
{
    public class CinemaContext : DbContext
    {
        public CinemaContext() : base("Cinema")
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Hall> Halls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Filter("IsDeleted", (BaseEntity x) => x.IsDeleted, false);
        }
    }
}