using System;
using System.Collections.Generic;
using System.Text;


/*
 * Encapsulate the tiny domain business rules. Structures that are unique 
 * by their properties and the whole object is immutable, once it is created
 * its state can not change.
 * https://martinfowler.com/bliki/ValueObject.html
 */

namespace ApolloData.ValueObjects.AccountValueObjects
{
    public readonly struct CurrencyCode
    {
        private readonly string _text;

        public CurrencyCode(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException($"CurrencyCode value is required");
            }

            _text = text;
        }

        public override string ToString()
        {
            return _text;
        }
    }
}
