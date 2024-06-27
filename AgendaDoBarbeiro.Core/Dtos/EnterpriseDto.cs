namespace AgendaDoBarbeiro.Core.Dtos
{
    public class EnterpriseDto
    {
        public long EnterpriseId { get; set; }

        public string Name { get; set; } = null!;

        public string SocialName { get; set; } = null!;

        public string? Cnpj { get; set; }

        public string? Cpf { get; set; }

        public string? Phone { get; set; }
    }
}
