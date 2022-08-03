using System;
using Microsoft.EntityFrameworkCore;

namespace CourierService.Models
{
    public class OfferCriteriaContext: DbContext
    {
        public DbSet<OfferCriteria> OfferCriterias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName=Tombo.db");
        }
    }
}
