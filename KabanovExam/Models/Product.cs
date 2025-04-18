using System;
using System.Collections.Generic;

namespace KabanovExam.Models;

public partial class Product
{
    public int Products_ID { get; set; }

    public int ProductType_ID { get; set; }

    public string NaimenovanieProdukcii { get; set; } = null!;

    public string Artikul { get; set; } = null!;

    public decimal? MinStoimost { get; set; }

    public virtual ProductType ProductType { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
