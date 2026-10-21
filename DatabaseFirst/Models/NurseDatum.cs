using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class NurseDatum
{
    public int Number { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public int? ManagerId { get; set; }
}
