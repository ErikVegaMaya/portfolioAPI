using System;
using System.Collections.Generic;

namespace PortfolioAPI.Models;

public partial class Skill
{
    public int IdSkill { get; set; }

    public string NameSkill { get; set; } = null!;

    public string TypeSkill { get; set; } = null!;

    public string LevelSkill { get; set; } = null!;
}
