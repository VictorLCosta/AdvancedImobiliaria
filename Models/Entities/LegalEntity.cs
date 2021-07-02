using System.Collections.Generic;

namespace AdvancedImobiliaria.Models.Entities
{
    public class LegalEntity : ApplicationUser
    {
        public string RepresentativeName { get; set; }
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public string stateRegistration { get; set; }

        public IEnumerable<Sale> Sales { get; set; }
        public IEnumerable<Imovel> Imoveis { get; set; }
    }
}