﻿using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UserManagment2.Models;

namespace UserManagment2.Models;

public partial class Visit
{
    public int VisitId { get; set; }

    public int PatientId { get; set; }

    [Display(Name = "medical number")]
    public string Umn { get; set; } = null!;

    public int? TicketNumber { get; set; }

    public string? EntryPlace { get; set; }

    public string? PaymentType { get; set; }

    public DateTime EntryDate { get; set; } = DateTime.Now;
    public string? CurrentLocation { get; set; }
    public virtual ICollection<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();

    public virtual Patient Patient { get; set; } = null!;
}
