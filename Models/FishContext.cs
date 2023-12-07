using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishBuddy.Models;


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
                   FishSpeciesName = "Micropterus dolomieu",
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

                },
                new FishSpecies
                {
                    FishSpeciesId = 5,
                    FishCommonName = "Walleye",
                    FishSpeciesName = "Sander vitreus",
                    FishHabitat = "Lakes & Rivers",
                    RecordWeight = "25 Pounds",
                    RecordLength = "41 Inches"

                },
                new FishSpecies
                {
                    FishSpeciesId = 6,
                    FishCommonName = "Steelhead",
                    FishSpeciesName = "Oncorhynchus mykiss",
                    FishHabitat = "Lakes & Rivers",
                    RecordWeight = "40 Pounds",
                    RecordLength = "45 Inches"

                },
                new FishSpecies
                {
                    FishSpeciesId = 7,
                    FishCommonName = "Musky",
                    FishSpeciesName = "Esox masquinongy",
                    FishHabitat = "Lakes & Rivers",
                    RecordWeight = "70 Pounds",
                    RecordLength = "72 Inches"

                },
                new FishSpecies
                {
                    FishSpeciesId = 8,
                    FishCommonName = "King Salmon",
                    FishSpeciesName = "Oncorhynchus tshawytscha",
                    FishHabitat = "Lakes & Rivers",
                    RecordWeight = "126 Pounds",
                    RecordLength = "58 Inches"

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


               },
               new FishLure
               {
                   FishLureId = 5,
                   FishSpeciesId = 5,
                   FishLureName = "Crankbaits & Jigs"


               },
               new FishLure
               {
                   FishLureId = 6,
                   FishSpeciesId = 6,
                   FishLureName = "Spoons, Imitation Eggs, & Spinners"


               },
               new FishLure
               {
                   FishLureId = 7,
                   FishSpeciesId = 7,
                   FishLureName = "Spoons, Crankbaits, Jerkbaits, Large Soft Swimbaits"


               },
               new FishLure
               {
                   FishLureId = 8,
                   FishSpeciesId = 8,
                   FishLureName = "Spoons, Imitation Eggs, & Spinners"


               }
                );

            modelBuilder.Entity<FishTime>().HasData(
                new FishTime
                {
                    FishTimeId = 1,
                    FishSpeciesId = 1, 
                    BestTimes = "Dawn & Dusk"

                },
                new FishTime
                {
                    FishTimeId = 2,
                    FishSpeciesId = 2,
                    BestTimes = "Dawn & Dusk"

                },
                new FishTime
                {
                    FishTimeId = 3,
                    FishSpeciesId = 3,
                    BestTimes = "Dawn & Dusk"

                },
                new FishTime
                {
                    FishTimeId = 4,
                    FishSpeciesId = 4,
                    BestTimes = "Dawn & Dusk"

                },
                new FishTime
                {
                    FishTimeId = 5,
                    FishSpeciesId = 5,
                    BestTimes = "Dawn, Dusk, & Night"

                },
                new FishTime
                {
                    FishTimeId = 6,
                    FishSpeciesId = 6,
                    BestTimes = "Dawn & Dusk"

                },
                new FishTime
                 {
                     FishTimeId = 7,
                     FishSpeciesId = 7,
                     BestTimes = "Dawn & Dusk"

                 },
                 new FishTime
                 {
                     FishTimeId = 8,
                     FishSpeciesId = 8,
                     BestTimes = "Dawn & Dusk"

                 }
                );
            modelBuilder.Entity<FishWeather>().HasData(
                new FishWeather 
                {
                    FishWeatherId = 1,
                    FishSpeciesId = 1,
                    BestWeathers = "Cloudy & warmer weather"

                },
                new FishWeather
                {
                    FishWeatherId = 2,
                    FishSpeciesId = 2,
                    BestWeathers = "Cloudy & cooler weather"

                },
                new FishWeather
                {
                    FishWeatherId = 3,
                    FishSpeciesId = 3,
                    BestWeathers = "Cloudy & cooler weather"

                },
                new FishWeather
                {
                    FishWeatherId = 4,
                    FishSpeciesId = 4,
                    BestWeathers = "Cloudy & very cold weather"

                },
                 new FishWeather
                 {
                     FishWeatherId = 5,
                     FishSpeciesId = 5,
                     BestWeathers = "Cloudy & cooler weather"

                 },
                  new FishWeather
                  {
                      FishWeatherId = 6,
                      FishSpeciesId = 6,
                      BestWeathers = "Cloudy & very cold weather"

                  },
                  new FishWeather
                  {
                      FishWeatherId = 7,
                      FishSpeciesId = 7,
                      BestWeathers = "Cloudy & cooler weather"

                  },
                  new FishWeather
                  {
                      FishWeatherId = 8,
                      FishSpeciesId = 8,
                      BestWeathers = "Cloudy & very cold weather"

                  }

                );



        } //onmodelcreating end 

        public DbSet<FishBuddy.Models.FishWeather>? FishWeather { get; set; }

        public DbSet<FishBuddy.Models.FishTime>? FishTime { get; set; }
    }
}
