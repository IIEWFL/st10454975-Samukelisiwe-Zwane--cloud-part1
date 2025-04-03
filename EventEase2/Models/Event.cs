using System;
using System.Collections.Generic;

namespace EventEase2.Models;

public partial class Event
{
    public int EventId { get; set; }

    public string EventName { get; set; } = null!;

    public string EventDate { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int VenueId { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Venue Venue { get; set; } = null!;
}
