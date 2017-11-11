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
            builder.Entity<Zone>(Configure);
            builder.Entity<Competition>(Configure);
            builder.Entity<Game>(Configure);
            builder.Entity<Channel>(Configure);
            builder.Entity<CompetitionInstanceParticipant>(Configure);
            builder.Entity<ParticipantBase>(Configure);
            builder.Entity<Player>(Configure);
            builder.Entity<Team>(Configure);
            builder.Entity<Sport>(Configure);
            base.OnModelCreating(builder);
        }

        private void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Team");
        }

        private void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Player");
        }

        private void Configure(EntityTypeBuilder<Sport> builder)
        {
            builder.ToTable("Sport");
            builder.Property(ci => ci.Id)
                .ForNpgsqlUseSequenceHiLo("Sport_hilo")
                .IsRequired();
            builder.HasIndex(u => u.Name)
                 .IsUnique();
        }

        private void Configure(EntityTypeBuilder<ParticipantBase> builder)
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

        private void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Game");
            builder.Property(ci => ci.Id)
                .ForNpgsqlUseSequenceHiLo("Game_hilo")
                .IsRequired();
        }

        private void Configure(EntityTypeBuilder<Competition> builder)
        {
            builder.ToTable("Competition");
            builder.Property(ci => ci.Id)
                .ForNpgsqlUseSequenceHiLo("Competition_hilo")
                .IsRequired();
        }

        private void Configure(EntityTypeBuilder<Zone> builder)
        {
            builder.ToTable("Zone");
            builder.Property(ci => ci.Id)
                .ForNpgsqlUseSequenceHiLo("Zone_hilo")
                .IsRequired();
            builder.HasIndex(u => u.Name)
                 .IsUnique();
        }
        private void Configure(EntityTypeBuilder<CompetitionInstanceParticipant> builder)
        {
            builder.ToTable("CompetitionInstanceParticipant");

            builder
                .HasKey(bc => new { bc.CompetitionInstanceId, bc.ParticipantId });


            builder
                .HasOne(cp => cp.CompetitionInstance)
                .WithMany(c => c.CompetitionInstanceParticipants)
                .HasForeignKey(cp => cp.CompetitionInstanceId);


            builder
                .HasOne(cp => cp.Participant)
                .WithMany(p => p.CompetitionInstanceParticipants)
                .HasForeignKey(cp => cp.ParticipantId);
        }

        private void Configure(EntityTypeBuilder<Channel> builder)
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
