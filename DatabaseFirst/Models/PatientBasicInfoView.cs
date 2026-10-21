using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class PatientBasicInfoView
{
    public int PatientId { get; set; }

    public string PatientName { get; set; } = null!;

    public DateOnly DateOfbirth { get; set; }
}
