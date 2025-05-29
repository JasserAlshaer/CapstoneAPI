using System;
using System.Collections.Generic;

namespace CapstoneAPI.Entities;

public  class Order : MainEntity
{
    
    public int? CouponId { get; set; }
    public DateTime? Date { get; set; }

    public int? StatusId { get; set; }

    public int? PaymentCardId { get; set; }

    public int? PaymentMethodId { get; set; }

    public int? LocationId { get; set; }

    public int? DeliveryEmployeeId { get; set; }

    public int? ClientId { get; set; }

    public bool? IsCheckout { get; set; }
    public string? SignalRConnectionId { get; set; }
    public double? DriverLocationLat { get; set; }
    public double? DriverLocationLong { get; set; }
}
