using BroadageSports.Data.Configurations;
using BroadageSports.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageSports.Data
{
    public class BroadageSportsContext : DbContext
    {
        public BroadageSportsContext(DbContextOptions<BroadageSportsContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AwayTeamConfiguration());
            modelBuilder.ApplyConfiguration(new HomeTeamConfiguration());
            modelBuilder.ApplyConfiguration(new MatchConfiguration());
            modelBuilder.ApplyConfiguration(new RoundConfiguration());
            modelBuilder.ApplyConfiguration(new StageConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentConfiguration());


        }
        public DbSet<Match> Matches { get; set; }
        public DbSet<AwayTeam> AwayTeams { get; set; }
        public DbSet<HomeTeam> HomeTeams { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
    }
}
