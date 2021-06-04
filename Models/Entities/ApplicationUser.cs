using System;
using System.ComponentModel.DataAnnotations.Schema;
using AdvancedImobiliaria.Models.Enums;

namespace AdvancedImobiliaria.Models.Entities
{
    public abstract class ApplicationUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        [NotMapped]
        public string Email { get; set; }

        public string NormalizedEmail { get; set; }

        [NotMapped]
        public string ProvidedPassword { get; set; }
        public string PasswordHash { get; set; }
        public ClientStatus Status { get; set; }
        public string MotivoStatus { get; set; }
        public decimal Salary { get; set; }
        public string Cep { get; set; }
        public string CityId { get; set; }
        public City City { get; set; }
    }
}