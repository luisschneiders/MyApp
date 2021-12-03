using System;
using System.Collections.Generic;

namespace ContactDetailsLibrary
{
    public class ContactDetails
    {
        private string _email;

        #nullable enable // Nullable contexts enable fine-grained control for how the compiler interprets reference type variables
        private string? _phone;
        private string? _mobile;

        // constructor
        public ContactDetails()
        {
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string? Phone
        {
            get => _phone;
            set => _phone = value;
        }

        public string? Mobile
        {
            get => _mobile;
            set => _mobile = value;
        }

    }
}
