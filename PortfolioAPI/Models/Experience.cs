using System;
using System.Collections.Generic;

namespace PortfolioAPI.Models;

public partial class Experience
{
    public int IdExp { get; set; }

    public string CompanyExp { get; set; } = null!;

    public string ProjectExp { get; set; } = null!;

    public string JobTitleExp { get; set; } = null!;

    public DateTime InitDateExp { get; set; }

    public DateTime EndDateExp { get; set; }

    public string DescriptionExp { get; set; } = null!;
}
