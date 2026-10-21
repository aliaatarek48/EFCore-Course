using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class Patient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly? Dob { get; set; }

    public int? WardId { get; set; }

    public virtual ICollection<DrugAdministration> DrugAdministrations { get; set; } = new List<DrugAdministration>();

    public virtual PatientConsultantAssignment? PatientConsultantAssignment { get; set; }

    public virtual Ward? Ward { get; set; }

    public virtual ICollection<Consultant> Consultants { get; set; } = new List<Consultant>();
}
