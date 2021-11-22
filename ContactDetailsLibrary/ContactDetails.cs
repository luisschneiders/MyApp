using System;
using System.Collections.Generic;

namespace ContactDetailsLibrary
{
    public class ContactDetails
    {
        private List<string> _email; // can add more than one email

        #nullable enable //Nullable contexts enable fine-grained control for how the compiler interprets reference type variables
        private List<string>? _phone; // can add more than one phone or it can be nullable
        private string? _mobile; // this field can be nullable

        // constructor
        public ContactDetails(List<string> email, List<string>? phone, string? mobile)
        {
            _email = email;
            _phone = phone;
            _mobile = mobile;
        }

        public List<string> Email
        {
            get => _email;
            set => _email = value;
        }

        public List<string>? Phone
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
