using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class PatientsDrugView
{
    public int PatientId { get; set; }

    public int? CountOfDrugs { get; set; }
}
