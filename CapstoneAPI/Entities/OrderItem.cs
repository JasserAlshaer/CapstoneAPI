using System;
using System.Collections.Generic;

namespace CapstoneAPI.Entities;

public  class OrderItem : MainEntity
{
    

    public int? CartId { get; set; }

    public int? ItemId { get; set; }

    public int? Quantity { get; set; }

    public double? NetPrice { get; set; }

    public string? Note { get; set; }

}
