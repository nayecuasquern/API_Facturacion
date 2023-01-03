using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_FActuración.Entidades;

public partial class FactPayType
{

    public int TypId { get; set; }

    public string? Typ { get; set; }

    public virtual ICollection<FactClient> FactClients { get; } = new List<FactClient>();

    public virtual ICollection<FactInvoiceHead> FactInvoiceHeads { get; } = new List<FactInvoiceHead>();
}
