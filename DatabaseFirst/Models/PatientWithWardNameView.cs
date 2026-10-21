using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class PatientWithWardNameView
{
    public int PatientId { get; set; }

    public string PatientName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string WardName { get; set; } = null!;
}
