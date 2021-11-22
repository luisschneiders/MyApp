using System;
using ContactDetailsLibrary;
using LocationLibrary;

namespace UserLibrary
{
    public class User
    {
        private string _userId;
        private string _userName;
        private string _userPassword;
        private ContactDetails _userContactDetails;
        private Location _userLocation;

        // constructor
        public User()
        {
        }

        // method Save
        public void Save(string userName, string userPassword, ContactDetails userContactDetails, Location userLocation)
        {
            // Add validation for fields

            UserId = Guid.NewGuid().ToString();
            UserName = userName;
            UserPassword = userPassword;
            UserContactDetails = userContactDetails;
            UserLocation = userLocation;

        }

        public string UserId
        {
            get => _userId;
            set => _userId = value;
        }

        public string UserName
        {
            get => _userName;
            set => _userName = value;
        }

        public string UserPassword
        {
            get => _userPassword;
            set => _userPassword = value;
        }

        public ContactDetails UserContactDetails
        {
            get => _userContactDetails;
            set => _userContactDetails = value;
        }

        public Location UserLocation
        {
            get => _userLocation;
            set => _userLocation = value;
        }
    }
}
