using Payment.Core.DTOs.WalletDtos;
using Payment.Core.DTOs;
using Payment.Core.DTOs.PaystackDtos.FundAccountDto;
using Payment.Core.DTOs.TransactionsDto;
using Payment.Core.DTOs.BeneficiaryDto;
using Paystack.Net.SDK.Models;

namespace Payment.Core.Interfaces
{
    public interface IWalletService
    {
        /// <summary>
        /// Gets wallet by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns wallet and Sucess if it exists and fails if not found</returns>
        public Task<ResponseDto<WalletResponseDto>> GetWalletByIdAsync(string id);

        /// <summary>
        /// Transfer funds from one wallet to another by account number
        /// </summary>
        /// <param name="model">Data transfer object to be mapped to a wallet object</param>
        /// <returns></returns>
        Task<ResponseDto<string>> LocalTransferAsync(string walletId, LocalTransferRequestDto request);

        /// <summary>
        /// Creates a wallet object and saves it to the database
        /// </summary>
        /// <param name="walletRequestDto">Data transfer object to be mapped to a wallet object</param>
        /// <returns></returns>
        Task<ResponseDto<CreateWalletResponse>> CreateWalletAsync(CreateWalletRequest walletRequestDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="walletId"></param>
        /// <returns></returns>
        Task<ResponseDto<string>> FundWalletVerificationAsync(VerifyTransactionRequestDto reference, string walletId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="walletId"></param>
        /// <returns></returns>
        Task<ResponseDto<PaymentInitalizationResponseModel>> InitializeFundWallet(FundWalletRequest request, string walletId);
    }
}
