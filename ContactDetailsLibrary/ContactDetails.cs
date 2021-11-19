using System;
using System.Collections.Generic;

namespace ContactDetailsLibrary
{
    public class ContactDetails
    {
        private List<string> _email;
        private List<int> _phone;
        private int _mobile;

        // constructor
        public ContactDetails()
        {
        }

        public List<string> Email
        {
            get => _email;
            set => _email = value;
        }

        public List<int> Phone
        {
            get => _phone;
            set => _phone = value;
        }

        public int Mobile
        {
            get => _mobile;
            set => _mobile = value;
        }

    }
}
