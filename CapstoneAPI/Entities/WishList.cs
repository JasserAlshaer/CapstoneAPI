using System;
using System.Collections.Generic;

namespace CapstoneAPI.Entities;

public  class WishList : MainEntity
{
    public int? ClientId { get; set; }
    public int? ItemId { get; set; }
}
