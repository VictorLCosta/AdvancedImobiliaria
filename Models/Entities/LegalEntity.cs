namespace AdvancedImobiliaria.Models.Entities
{
    public class LegalEntity : ApplicationUser
    {
        public string RepresentativeName { get; set; }
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public string stateRegistration { get; set; }
    }
}