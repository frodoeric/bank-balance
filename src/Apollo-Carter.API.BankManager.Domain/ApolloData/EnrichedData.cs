using System.Security.Claims;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData
{
    public class EnrichedData
    {
        public Category Category { get; set; }
        public Class Class { get; set; }
        public string PredictedMerchantName { get; set; }
    }
}