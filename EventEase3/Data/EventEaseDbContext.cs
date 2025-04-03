using System;
using System.Collections.Generic;
using EventEase3.Models;
using Microsoft.EntityFrameworkCore;

namespace EventEase3.Data;

public partial class EventEaseDbContext : DbContext
{
    public EventEaseDbContext()
    {
    }

    public EventEaseDbContext(DbContextOptions<EventEaseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__73951ACD5BBF644A");

            entity.ToTable("Booking");

            entity.HasIndex(e => new { e.VenueId, e.BookingDate }, "CK_UniqueVenueBookingTime").IsUnique();

            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.BookingDate).HasColumnType("datetime");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.VenueId).HasColumnName("VenueID");

            entity.HasOne(d => d.Event).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Booking__EventID__3D5E1FD2");

            entity.HasOne(d => d.Venue).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("FK__Booking__VenueID__3E52440B");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Event__7944C8708E6D48FB");

            entity.ToTable("Event");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.EventDate).HasColumnType("datetime");
            entity.Property(e => e.EventName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.VenueId).HasColumnName("VenueID");

            entity.HasOne(d => d.Venue).WithMany(p => p.Events)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("FK__Event__VenueID__398D8EEE");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.VenueId).HasName("PK__Venues__3C57E5D275A210CD");

            entity.Property(e => e.VenueId).HasColumnName("VenueID");
            entity.Property(e => e.ImageUrl)
                .IsUnicode(false)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.VenueName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
