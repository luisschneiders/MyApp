using System;
using LocationLibrary;

namespace UserLibrary
{
    public class User
    {
        private string _userId;
        private string _userName;
        private string _userEmail;
        private string _userPassword;
        private int _userMobilePhone;
        private int _userPhone;
        private Location _userLocation;

        // constructor
        public User(string userName, string userEmail, string userPassword, int userMobilePhone, int userPhone, Location userLocation)
        {
            _userName = userName;
            _userEmail = userEmail;
            _userPassword = userPassword;
            _userMobilePhone = userMobilePhone;
            _userPhone = userPhone;
            _userLocation = userLocation;
        }

        // method Save
        public void Save(string userName, string userEmail, string userPassword, int userMobilePhone, int userPhone, Location userLocation)
        {
            // Add validation for fields

            UserId = Guid.NewGuid().ToString();
            UserName = userName;
            UserEmail = userEmail;
            UserPassword = userPassword;
            UserMobilePhone = userMobilePhone;
            UserPhone = userPhone;
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

        public string UserEmail
        {
            get => _userEmail;
            set => _userEmail = value;
        }

        public string UserPassword
        {
            get => _userPassword;
            set => _userPassword = value;
        }

        public int UserMobilePhone
        {
            get => _userMobilePhone;
            set => _userMobilePhone = value;
        }

        public int UserPhone
        {
            get => _userPhone;
            set => _userPhone = value;
        }

        public Location UserLocation
        {
            get => _userLocation;
            set => _userLocation = value;
        }
    }
}
