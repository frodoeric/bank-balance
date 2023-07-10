using System.Transactions;
using System;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string CreditDebitIndicator { get; set; }
        public string Status { get; set; }
        public TransactionCode TransactionCode { get; set; }
        public string ProprietaryTransactionCode { get; set; }
        public DateTime BookingDate { get; set; }
        public MerchantDetails MerchantDetails { get; set; }
        public EnrichedData EnrichedData { get; set; }
    }
}