using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class DrugBrand
{
    public int DrugCode { get; set; }

    public string Brand { get; set; } = null!;

    public virtual Drug DrugCodeNavigation { get; set; } = null!;
}
