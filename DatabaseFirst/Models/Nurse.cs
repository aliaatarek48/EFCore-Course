using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class Nurse
{
    public int Number { get; set; }

    public string Name { get; set; } = null!;

    public string? NurseAddress { get; set; }

    public int? SupervisedWardId { get; set; }

    public int? ServesInWardId { get; set; }

    public int? ManagerId { get; set; }

    public decimal? Salary { get; set; }

    public virtual ICollection<DrugAdministration> DrugAdministrations { get; set; } = new List<DrugAdministration>();

    public virtual ICollection<Nurse> InverseManager { get; set; } = new List<Nurse>();

    public virtual Nurse? Manager { get; set; }

    public virtual Ward? ServesInWard { get; set; }

    public virtual Ward? SupervisedWard { get; set; }
}
