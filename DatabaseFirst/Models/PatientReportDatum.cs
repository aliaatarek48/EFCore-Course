using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class PatientReportDatum
{
    public int PatientId { get; set; }

    public string PatientName { get; set; } = null!;

    public DateOnly Dob { get; set; }

    public string WardName { get; set; } = null!;

    public int? NurseCount { get; set; }

    public decimal? AvgNurseSalary { get; set; }

    public string? SupervisorName { get; set; }

    public string? SupervisorManagerName { get; set; }

    public string? AssignedConsultant { get; set; }

    public decimal? ConsultantSalary { get; set; }

    public int? ExaminingConsultants { get; set; }

    public int? AdministrationCount { get; set; }

    public int? DistinctDrugs { get; set; }

    public int? DistinctNurses { get; set; }

    public int? TotalQuantity { get; set; }

    public int? AvailableBrands { get; set; }

    public string MedicationCategory { get; set; } = null!;

    public long? RankInWard { get; set; }
}
