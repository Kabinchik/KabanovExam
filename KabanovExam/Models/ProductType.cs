using System;
using System.Collections.Generic;

namespace KabanovExam.Models;

public partial class ProductType
{
    public int ProductType_ID { get; set; }

    public string TipProdukcii { get; set; } = null!;

    public decimal? Koefficient { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
