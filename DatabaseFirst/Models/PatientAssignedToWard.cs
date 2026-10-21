using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class PatientAssignedToWard
{
    public int PatientId { get; set; }

    public string PatientName { get; set; } = null!;

    public int? WardId { get; set; }
}
