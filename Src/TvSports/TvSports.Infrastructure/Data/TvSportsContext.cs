using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;
using TvSports.Core.Entities;

namespace TvSports.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TvSportsContext>
    {
        public TvSportsContext CreateDbContext(string[] args)
        {
            return new TvSportsContext(new DbContextOptions<TvSportsContext>(), GetConfiguration());
        }
        static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }

    public class TvSportsContext : DbContext
    {
        private IConfiguration _configuration;

        public TvSportsContext(DbContextOptions<TvSportsContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Zone>(ConfigureZone);
            builder.Entity<Competition>(ConfigureCompetition);
            builder.Entity<Game>(ConfigureGame);
            builder.Entity<Channel>(ConfigureChannel);
            builder.Entity<ParticipantBase>(ConfigureParticipantBase);
            builder.Entity<Player>(ConfigurePlayer);
            builder.Entity<Team>(ConfigureTeam);
            builder.Entity<Sport>(ConfigureSport);
            base.OnModelCreating(builder);
        }

        private void ConfigureTeam(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Team");
        }

        private void ConfigurePlayer(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Player");
        }

        private void ConfigureSport(EntityTypeBuilder<Sport> builder)
        {
            builder.ToTable("Sport");
            builder.Property(ci => ci.Id)
                .ForNpgsqlUseSequenceHiLo("Sport_hilo")
                .IsRequired();
            builder.HasIndex(u => u.Name)
                 .IsUnique();
        }

        private void ConfigureParticipantBase(EntityTypeBuilder<ParticipantBase> builder)
        {
            builder.ToTable("Participant");
            builder.Property(ci => ci.Id)
                .ForNpgsqlUseSequenceHiLo("Participant_hilo")
                .IsRequired();
            builder.HasIndex(u => u.Name)
                 .IsUnique();
        }

        //
        //var navigation = builder.Metadata.FindNavigation(nameof(Chanel.ChanelNames));
        //navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

        private void ConfigureGame(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Game");
            builder.Property(ci => ci.Id)
                .ForNpgsqlUseSequenceHiLo("Game_hilo")
                .IsRequired();
        }

        private void ConfigureCompetition(EntityTypeBuilder<Competition> builder)
        {
            builder.ToTable("Competition");
            builder.Property(ci => ci.Id)
                .ForNpgsqlUseSequenceHiLo("Competition_hilo")
                .IsRequired();
        }

        private void ConfigureZone(EntityTypeBuilder<Zone> builder)
        {
            builder.ToTable("Zone");
            builder.Property(ci => ci.Id)
                .ForNpgsqlUseSequenceHiLo("Zone_hilo")
                .IsRequired();
            builder.HasIndex(u => u.Name)
                 .IsUnique();
        }

        private void ConfigureChannel(EntityTypeBuilder<Channel> builder)
        {
            builder.ToTable("Channel");
            builder.Property(ci => ci.Id)
                .ForNpgsqlUseSequenceHiLo("Channel_hilo")
                .IsRequired();
            builder.HasIndex(u => u.Name)
                 .IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqlConnectionString = _configuration.GetConnectionString("DataAccessPostgreSqlProvider");

            optionsBuilder.UseNpgsql(
                sqlConnectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
