using System;

namespace AdvancedImobiliaria.Models.Entities
{
    public class Sale
    {
        public string Id { get; set; }
        public ApplicationUser User { get; set; }
        public Imovel Imovel { get; set; }
        public DateTime saleDate { get; set; }
        public string Financier{ get; set; }
        public int Months { get; set; }
        public decimal Fees { get; set; }
        public decimal Multa { get; set; }
    }
}