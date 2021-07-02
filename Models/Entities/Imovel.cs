using System;
using AdvancedImobiliaria.Models.Enums;

namespace AdvancedImobiliaria.Models.Entities
{
    public class Imovel
    {
        public int Id { get; set; }
        public ImovelType Tipo { get; set; }
        public int Banheiros { get; set; }
        public int Dormitorios { get; set; }
        public int vagasGaragem { get; set; }
        public ImovelStatus Status { get; set; }
        public string Finalidade { get; set; }
        public string Transaction { get; set; }
        public double Largura { get; set; }
        public double Comprimento { get; set; }
        public double privateArea { get; set; }
        public double areaComum { get; set; }
        public double totalArea { get; set; }
        public string Street { get; set; }
        public City City { get; set; }
        public int Number { get; set; }
        public string Complemento { get; set; }
        public decimal Value { get; set; }
        public decimal Iptu { get; set; }
        
        public Guid physicalPersonId { get; set; }
        public PhysicalPerson physicalPerson { get; set; }
        public Guid legalEntityId { get; set; }
        public LegalEntity legalEntity { get; set; }
        public Sale Sale { get; set; }
    }
}