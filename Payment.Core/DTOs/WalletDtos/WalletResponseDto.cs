using Payment.Core.DTOs.VirtualAccountDtos;
using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.DTOs.WalletDtos
{
    public class WalletResponseDto
    {
        public string Name { get; set; } = null!;
        public decimal Balance { get; set; }

        public VirtualAccountDto VirtualAccount { get; set; } = null!;
    }
}
