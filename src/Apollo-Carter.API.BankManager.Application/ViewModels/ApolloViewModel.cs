using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Apollo_Carter.API.BankManager.Domain.ApolloData;

/*
 * A view model represents the data that you want to display on 
 * your view/page, whether it be used for static text or for input
 * values (like textboxes and dropdown lists). It is something 
 * different than your domain model. It is a model for the view. 
 */
namespace Apollo_Carter.API.BankManager.Application.ViewModels
{
    public class ApolloViewModel
    {
        public ApolloViewModel()
        {

        }
        public ApolloViewModel(string providerName,
            string countryCode,
            IEnumerable<Account> accounts)
        {
            ProviderName = providerName;
            CountryCode = countryCode;
            Accounts = accounts;
        }
        public IEnumerable<Account> Accounts { get; set; }


        [Required]
        [MinLength(5)]
        [MaxLength(150)]
        public string ProviderName { get; set; }

        [MaxLength(1500)]
        [JsonProperty(PropertyName = "CountryCode")]
        public string CountryCode { get; set; } = "";
    }


}
