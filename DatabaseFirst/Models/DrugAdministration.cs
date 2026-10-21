using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class DrugAdministration
{
    public int NurseId { get; set; }

    public int DrugCode { get; set; }

    public int PatientId { get; set; }

    public string? Dosage { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public int? Quantity { get; set; }

    public virtual Drug DrugCodeNavigation { get; set; } = null!;

    public virtual Nurse Nurse { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
