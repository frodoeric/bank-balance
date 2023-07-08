﻿using System;
using System.Collections.Generic;
using System.Text;


/*
 * Encapsulate the tiny domain business rules. Structures that are unique 
 * by their properties and the whole object is immutable, once it is created
 * its state can not change.
 * https://martinfowler.com/bliki/ValueObject.html
 */

namespace ApolloData.ValueObjects
{
    public readonly struct CountryCode
    {
        private readonly string _text;

        public CountryCode(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                //todo create custom exception
                throw new ArgumentNullException($"CountryCode value is required");
            }

            _text = text;
        }

        public override string ToString()
        {
            return _text;
        }
    }
}
