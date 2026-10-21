using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class Ward
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Nurse> NurseServesInWards { get; set; } = new List<Nurse>();

    public virtual ICollection<Nurse> NurseSupervisedWards { get; set; } = new List<Nurse>();

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
