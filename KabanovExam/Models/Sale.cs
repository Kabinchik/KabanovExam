using System;
using System.Collections.Generic;

namespace KabanovExam.Models;

public partial class Sale
{
    public int Sales_ID { get; set; }

    public int Products_ID { get; set; }

    public int Partners_ID { get; set; }

    public int KolichestvoProdukcii { get; set; }

    public DateOnly DataProdaji { get; set; }

    public virtual Partner Partners { get; set; } = null!;

    public virtual Product Products { get; set; } = null!;
}
