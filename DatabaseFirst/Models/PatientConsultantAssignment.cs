using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class PatientConsultantAssignment
{
    public int PatientId { get; set; }

    public int ConsultantId { get; set; }

    public virtual Consultant Consultant { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
