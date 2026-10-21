using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class Consultant
{
    public int Id { get; set; }

    public string ConName { get; set; } = null!;

    public decimal? Salary { get; set; }

    public virtual ICollection<PatientConsultantAssignment> PatientConsultantAssignments { get; set; } = new List<PatientConsultantAssignment>();

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
