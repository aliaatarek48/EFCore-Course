using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class NurseDataServWardOne
{
    public int Number { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public int? ServesInWardId { get; set; }

    public int? ManagerId { get; set; }
}
