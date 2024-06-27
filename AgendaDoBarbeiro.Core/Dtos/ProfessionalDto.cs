using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDoBarbeiro.Core.Dtos
{
    public class ProfessionalDto
    {
        public long ProfessionalId { get; set; }
        public string? Whatsapp { get; set; }
        public string? FirstMessage { get; set; }
        public string? Description { get; set; }
        public long? EnterpriseId { get; set; }
        public required string UserName { get; set; }
        public required string Phone { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }

    }
}
