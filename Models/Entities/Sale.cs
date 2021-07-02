using System;

namespace AdvancedImobiliaria.Models.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public Guid physicalUserId { get; set; }
        public PhysicalPerson physicalPerson { get; set; }
        public Guid legalUserId { get; set; }
        public LegalEntity legalEntity { get; set; }
        public Imovel Imovel { get; set; }
        public DateTime saleDate { get; set; }
        public string Financier{ get; set; }
        public int Months { get; set; }
        public decimal Fees { get; set; }
        public decimal Multa { get; set; }
    }
}