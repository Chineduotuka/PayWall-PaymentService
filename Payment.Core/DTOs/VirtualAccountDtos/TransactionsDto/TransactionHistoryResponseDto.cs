using Payment.Domain.Enums;

namespace Payment.Core.DTOs
{
    public class TransactionHistoryResponseDto
    {
        public string TransactionId { get; set; }  = String.Empty;
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public TransactionStatus Status { get; set; }
        public string Narration { get; set; } = String.Empty;
        public string Reference { get; set; } = String.Empty;
        public string WalletId { get; set; } = String.Empty;

    }
}
