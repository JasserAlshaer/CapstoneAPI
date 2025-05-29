using System;
using System.Collections.Generic;

namespace CapstoneAPI.Entities;

public  class PaymentCard : MainEntity
{
    

    public string? CardLatestNumber { get; set; }

    public string? CardNumber { get; set; }

    public string? Cvv { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public double? Balance { get; set; }

    public string? CardHolder { get; set; }

    public int? ClientId { get; set; }
    public int CardTypeId { get; set; }

}
