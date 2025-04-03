using System;
using System.Collections.Generic;

namespace EventEasePoe.Models;

public partial class Venue
{
    public int VenueId { get; set; }

    public string VenueName { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string Capacity { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
