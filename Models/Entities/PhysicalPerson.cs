using System;

namespace AdvancedImobiliaria.Models.Entities
{
    public class PhysicalPerson : ApplicationUser
    {
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public char Gender { get; set; }
        public int qtyChildren { get; set; }
        public DateTime birthDate{ get; set; }
    }
}