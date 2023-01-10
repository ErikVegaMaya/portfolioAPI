using System;
using System.Collections.Generic;

namespace PortfolioAPI.Models;

public partial class PersonalInfo
{
    public int IdPi { get; set; }

    public string NamePi { get; set; } = null!;

    public string LastNamePi { get; set; } = null!;

    public string? PhonePi { get; set; }

    public string? EmailPi { get; set; }

    public string? GithubPi { get; set; }

    public string? LinkedinPi { get; set; }
}
