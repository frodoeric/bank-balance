using System.Collections.Generic;
using System.Net;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData
{
    public class Party
    {
        public string PartyId { get; set; }
        public string FullName { get; set; }
        public List<Address> Addresses { get; set; }
        public string PartyType { get; set; }
        public bool? IsIndividual { get; set; }
        public bool? IsAuthorizingParty { get; set; }
        public string EmailAddress { get; set; }
        public List<string> PhoneNumbers { get; set; }
    }
}