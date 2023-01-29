using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_FActuración.Entidades;

public partial class DbFacturacionContext : DbContext
{
    public DbFacturacionContext()
    {
    }

    public DbFacturacionContext(DbContextOptions<DbFacturacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FactClient> FactClients { get; set; }

    public virtual DbSet<FactInvoiceDetail> FactInvoiceDetails { get; set; }

    public virtual DbSet<FactInvoiceHead> FactInvoiceHeads { get; set; }

    public virtual DbSet<FactPayType> FactPayTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=jjmalesg.database.windows.net;Initial Catalog=grupo4DB;User ID=jeffersonmales;Password=Buenhombre1;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FactClient>(entity =>
        {
            entity.HasKey(e => e.CliIdentification).HasName("PK__fact_cli__1643381D5D527006");

            entity.ToTable("fact_client");

            entity.Property(e => e.CliIdentification)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cli_identification");
            entity.Property(e => e.CliAddres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cli_addres");
            entity.Property(e => e.CliBirthday)
                .HasColumnType("date")
                .HasColumnName("cli_birthday");
            entity.Property(e => e.CliMail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("cli_mail");
            entity.Property(e => e.CliName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("cli_name");
            entity.Property(e => e.CliPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cli_phone");
            entity.Property(e => e.CliStatus).HasColumnName("cli_status");
            entity.Property(e => e.TypId).HasColumnName("typ_id");

            entity.HasOne(d => d.Typ).WithMany(p => p.FactClients)
                .HasForeignKey(d => d.TypId)
                .HasConstraintName("FK__fact_clie__typ_i__5EBF139D");
        });

        modelBuilder.Entity<FactInvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.InvoiceDetailId).HasName("PK__fact_inv__84908DB6470145D7");

            entity.ToTable("fact_invoice_details");

            entity.Property(e => e.InvoiceDetailId).HasColumnName("invoice_detail_id");
            entity.Property(e => e.InvoiceDetailAmount).HasColumnName("invoice_detail_amount");
            entity.Property(e => e.InvoiceDetailSubtotal).HasColumnName("invoice_detail_subtotal");
            entity.Property(e => e.InvoiceHeadId).HasColumnName("invoice_head_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.InvoiceProductName).HasColumnName("invoice_product_name");

            entity.HasOne(d => d.InvoiceHead).WithMany(p => p.FactInvoiceDetails)
                .HasForeignKey(d => d.InvoiceHeadId)
                .HasConstraintName("FK__fact_invo__invoi__656C112C");
        });

        modelBuilder.Entity<FactInvoiceHead>(entity =>
        {
            entity.HasKey(e => e.InvoiceHeadId).HasName("PK__fact_inv__2EEC4B2763C860D8");

            entity.ToTable("fact_invoice_head");

            entity.Property(e => e.InvoiceHeadId).HasColumnName("invoice_head_id");
            entity.Property(e => e.CliIdentification)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cli_identification");
            entity.Property(e => e.InvoiceDate)
                .HasColumnType("date")
                .HasColumnName("invoice_date");
            entity.Property(e => e.InvoiceIva).HasColumnName("invoice_IVA");
            entity.Property(e => e.InvoiceSubtotal).HasColumnName("invoice_subtotal");
            entity.Property(e => e.InvoiceTotal).HasColumnName("invoice_total");
            entity.Property(e => e.InvoiceStatus).HasColumnName("invoice_status");
            entity.Property(e => e.TypId).HasColumnName("typ_id");

            entity.HasOne(d => d.CliIdentificationNavigation).WithMany(p => p.FactInvoiceHeads)
                .HasForeignKey(d => d.CliIdentification)
                .HasConstraintName("FK__fact_invo__cli_i__628FA481");

            entity.HasOne(d => d.Typ).WithMany(p => p.FactInvoiceHeads)
                .HasForeignKey(d => d.TypId)
                .HasConstraintName("FK__fact_invo__typ_i__619B8048");
        });

        modelBuilder.Entity<FactPayType>(entity =>
        {
            entity.HasKey(e => e.TypId).HasName("PK__fact_pay__FEF149130CDD0F45");

            entity.ToTable("fact_pay_type");

            entity.Property(e => e.TypId).HasColumnName("typ_id");
            entity.Property(e => e.Typ)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("typ");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
