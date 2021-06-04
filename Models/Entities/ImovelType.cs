using System;

namespace AdvancedImobiliaria.Models.Entities
{
    public class ImovelType
    {
        public Guid Id { get; set; }
        public string Desc { get; set; }
        public bool Active { get; set; }
    }
}