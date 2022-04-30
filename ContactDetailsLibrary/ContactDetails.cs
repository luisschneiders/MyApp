using System;
using System.Collections.Generic;

namespace ContactDetailsLibrary
{
    public class ContactDetails
    {
        private Guid _id;
        private string _email;

        #nullable enable // Nullable contexts enable fine-grained control for how the compiler interprets reference type variables
        private string? _phone;
        private string? _mobile;

        // constructor
        public ContactDetails()
        {
        }

        public Guid Id
        {
            get => _id;
            set => _id = value;
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
