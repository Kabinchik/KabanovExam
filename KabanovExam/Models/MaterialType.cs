using System;
using System.Collections.Generic;

namespace KabanovExam.Models;

public partial class MaterialType
{
    public int MaterialType_ID { get; set; }

    public decimal? ProcentBraka { get; set; }

    public string? TipMateriala { get; set; }
}
