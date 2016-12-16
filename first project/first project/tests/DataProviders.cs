﻿using System;
using System.Collections;
using first_project.model;

namespace first_project.tests
{
    internal class DataProviders
    {
        public static IEnumerable ValidCustomers
        {
            get
            {
                yield return new Customer()
                {
                    Firstname = "Adam",
                    Lastname = "Smith",
                    Phone = "+0123456789",
                    Address = "Hidden Place",
                    Postcode = "12345",
                    City = "New City",
                    Country = "US",
                    Zone = "KS",
                    Email = "adam" + (long)(DateTime.Now - DateTime.MinValue).TotalMilliseconds + "@smith.me",
                    Password = "qwerty"
                };
                /* ... */
            }
        }
    }
}