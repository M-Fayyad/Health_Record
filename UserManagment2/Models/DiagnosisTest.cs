using System;
using System.Collections.Generic;
using UserManagment2.Models;

namespace UserManagment2.Models;

public partial class DiagnosisTest
{
    public int Id { get; set; }

    public int? DiagnosisId { get; set; }

    public int? TestId { get; set; }

    public virtual Diagnosis? Diagnosis { get; set; }

    public virtual TestsXRay? Test { get; set; }
}
