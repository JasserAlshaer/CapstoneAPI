using System;
using System.Collections.Generic;

namespace CapstoneAPI.Entities;

public  class Item : MainEntity
{
    

    public string? Name { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }

    public double? Price { get; set; }

    public double? Rate { get; set; }

    public int? Reviews { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

   
}
