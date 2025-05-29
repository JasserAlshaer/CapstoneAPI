using System;
using System.Collections.Generic;

namespace CapstoneAPI.Entities;

public  class CountryCode : MainEntity
{
    

    public string? Code { get; set; }

    public string? Iso { get; set; }

    public string? FlagUrl { get; set; }
}
