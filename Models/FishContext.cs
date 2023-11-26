using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FishBuddy.Models
{
    public class FishContext : DbContext
    {
        public FishContext(DbContextOptions<FishContext> options) : base(options)
        { }
        public DbSet<FishLog> FishList { get; set; }

        public DbSet<FishSpecies> FishSpecies { get; set; }

        public DbSet<FishLure> FishLure { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FishLog>().HasData(
                new FishLog
                {
                    ID = 1,
                    FishName = "Largemouth Bass",
                    Location = "Ransom Lake",
                    MaxLength = "27 Inches",
                    MaxWeight = "11.94 Pounds"

                },
                new FishLog
                {
                    ID = 2,
                    FishName = "Northern Pike",
                    Location = "Bronson Lake",
                    MaxLength = "51.5 Inches",
                    MaxWeight = "39 Pounds"
                },
                new FishLog
                {
                    ID = 3,
                    FishName = "Walleye",
                    Location = "Long Lake",
                    MaxLength = "35 Inches",
                    MaxWeight = "17.19 Pounds"
                }
            );
            modelBuilder.Entity<FishSpecies>().HasData(
               new FishSpecies
               {
                   FishSpeciesId = 1,
                   FishCommonName = "Largemouth Bass",
                   FishSpeciesName = "Micropterus salmoides",
                   FishHabitat = "Ponds, Swamps, Lakes, Creeks, Rivers",
                   RecordWeight = "22 Pounds 4 Ounces",
                   RecordLength = "25.59 inches"

               },
               new FishSpecies
               {
                   FishSpeciesId = 2,
                   FishCommonName = "Smallmouth Bass",
                   FishSpeciesName = "Micropterus salmoides",
                   FishHabitat = "Ponds, Lakes, Creeks, Rivers",
                   RecordWeight = "11 Pounds 15 Ounces",
                   RecordLength = "27 inches"

               },
               new FishSpecies
               {
                   FishSpeciesId = 3,
                   FishCommonName = "Northern Pike",
                   FishSpeciesName = "Esox lucius",
                   FishHabitat = "Ponds, Lakes, Creeks, Rivers",
                   RecordWeight = "55 Pounds",
                   RecordLength = "52 Inches"

               },
                new FishSpecies
                {
                    FishSpeciesId = 4,
                    FishCommonName = "Lake Trout",
                    FishSpeciesName = "Salvelinus namaycush",
                    FishHabitat = "Lakes",
                    RecordWeight = "73 Pounds 29 Ounces",
                    RecordLength = "47 Inches"

                }
           );
            modelBuilder.Entity<FishLure>().HasData(
               new FishLure
               {
                   FishLureId = 1,
                   FishSpeciesId = 1,
                   FishLureName = "Fake Worms, Jigs, Topwater Lures, Paddletail Swimbaits"
                   

               },
               new FishLure
               {
                   FishLureId = 2,
                   FishSpeciesId = 2,
                   FishLureName = "Tubes, Jigs, Topwater Lures, Paddletail Swimbaits"


               },
               new FishLure
               {
                   FishLureId = 3,
                   FishSpeciesId = 3,
                   FishLureName = "Spoons, Crankbaits, Jerkbaits, Large Soft Swimbaits"


               },
               new FishLure
               {
                   FishLureId = 4,
                   FishSpeciesId = 4,
                   FishLureName = "Spoons & Tubes"


               }
                );
        }
    }
}
