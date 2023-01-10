using System;
using System.Collections.Generic;

namespace PortfolioAPI.Models;

public partial class Education
{
    public int IdEdu { get; set; }

    public string NameEdu { get; set; } = null!;

    public string GardeEdu { get; set; } = null!;
}
