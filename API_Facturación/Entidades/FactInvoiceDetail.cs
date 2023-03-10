using System;
using System.Collections.Generic;

namespace API_FActuración.Entidades;

public partial class FactInvoiceDetail
{
    public int InvoiceDetailId { get; set; }

    public int? InvoiceDetailAmount { get; set; }

    public double? InvoiceDetailSubtotal { get; set; }

    public string? ProductId { get; set; }

    public string? InvoiceProductName { get; set; }

    public int? InvoiceHeadId { get; set; }

    public virtual FactInvoiceHead? InvoiceHead { get; set; }
}
