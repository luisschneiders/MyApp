using System;

namespace ContactDetailsLibrary
{
    public class ContactDetails
    {
        private string _email;
        private int _mobilePhone;
        private int _phone;

        // constructor
        public ContactDetails()
        {
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public int MobilePhone
        {
            get => _mobilePhone;
            set => _mobilePhone = value;
        }

        public int Phone
        {
            get => _phone;
            set => _phone = value;
        }
    }
}
