using System;
using System.Collections.Generic;

namespace CapstoneAPI.Entities;

public  class Location : MainEntity
{
    

    public string? LocationTitle { get; set; }

    public string? Description { get; set; }

    public double? Lat { get; set; }

    public double? Long { get; set; }

    public int? ClientId { get; set; }
}
