using System;
using System.Collections.Generic;

namespace API_FActuración.Entidades;

public partial class FactClient
{
    public string CliIdentification { get; set; } = null!;

    public string? CliName { get; set; }

    public DateTime? CliBirthday { get; set; }

    public string? CliAddres { get; set; }

    public string? CliPhone { get; set; }

    public string? CliMail { get; set; }

    public bool? CliStatus { get; set; }

    public int? TypId { get; set; }

    public virtual ICollection<FactInvoiceHead> FactInvoiceHeads { get; } = new List<FactInvoiceHead>();

    public virtual FactPayType? Typ { get; set; }
}
