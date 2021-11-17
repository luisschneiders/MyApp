using System;
using LocationLibrary;

namespace UserLibrary
{
    public class User : ILocation
    {
        private string _userId;
        private string _userName;
        private string _userEmail;
        private string _userPassword;
        private int _userMobilePhone;
        private int _userPhone;
        private ILocation _userLocation;

        // constructor
        public User(string userName, string userEmail, string userPassword, int userMobilePhone, int userPhone, ILocation userLocation)
        {
            _userName = userName;
            _userEmail = userEmail;
            _userPassword = userPassword;
            _userMobilePhone = userMobilePhone;
            _userPhone = userPhone;
            _userLocation = userLocation;
        }

        // method Save
        public void Save(string userName)
        {
            // Add validation for fields

            UserId = Guid.NewGuid().ToString();
            UserName = userName;

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

        // Assign get and set for _userLocation field
        public string Address { get => _userLocation.Address; set => _userLocation.Address = value; }
        public int Lat { get => _userLocation.Lat; set => _userLocation.Lat = value; }
        public int Lng { get => _userLocation.Lng; set => _userLocation.Lng = value; }
        public string Suburb { get => _userLocation.Suburb; set => _userLocation.Suburb = value; }
        public string Postcode { get => _userLocation.Postcode; set => _userLocation.Postcode = value; }
        public string State { get => _userLocation.State; set => _userLocation.State = value; }
    }
}
