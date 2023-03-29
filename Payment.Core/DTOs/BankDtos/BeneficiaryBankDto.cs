namespace Payment.Core.DTOs.BankDtos
{
    public class BeneficiaryBankDto
    {
        public string BankCode { get; set; } = null!;
        public string BankName { get; set; } = null!;
        public string? CountryCode { get; set; }
        public int PaystackBankId { get; set; } 
    }
}
