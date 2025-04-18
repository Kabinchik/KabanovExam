using System;
using System.Collections.Generic;

namespace KabanovExam.Models;

public partial class PartnersType
{
    public int PartnersType_ID { get; set; }

    public string TipPartnera { get; set; } = null!;

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();
}
