using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class Drug
{
    public int Code { get; set; }

    public string? Dosage { get; set; }

    public virtual ICollection<DrugAdministration> DrugAdministrations { get; set; } = new List<DrugAdministration>();

    public virtual ICollection<DrugBrand> DrugBrands { get; set; } = new List<DrugBrand>();
}
