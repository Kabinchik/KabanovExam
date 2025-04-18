using System;
using System.Collections.Generic;
using System.IO;

namespace KabanovExam.Models;

public partial class Partner
{
    public int Partners_ID { get; set; }

    public int PartnersType_ID { get; set; }

    public string NaimenovaniePartnera { get; set; } = null!;

    public string Familiya { get; set; } = null!;

    public string Imya { get; set; } = null!;

    public string? Otchestvo { get; set; }

    public string Email { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Index { get; set; } = null!;

    public string Oblast { get; set; } = null!;

    public string Gorod { get; set; } = null!;

    public string Ulica { get; set; } = null!;

    public int Dom { get; set; }

    public string INN { get; set; } = null!;

    public int Reyting { get; set; }

    public virtual PartnersType PartnersType { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    public string Fullname => $"Директор: {Familiya} {Imya} {Otchestvo}";
    public string Phone => $"+7 {Telephone}";
    public string Reyt => $"Рейтинг: {Reyting}";
    public int ObshayaProdaja
    {
        get
        {
            return Sales?.Sum(s => s.KolichestvoProdukcii) ?? 0;
        }
    }

    public string Skidka
    {
        get
        {
            int total = ObshayaProdaja;

            if (total < 10000)
                return "0%";
            else if (total < 50000)
                return "5%";
            else if (total < 300000)
                return "10%";
            else return "15%";
        }
    }
}
