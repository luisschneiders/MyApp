using System;
using LocationLibrary;

namespace UserLibrary
{
    public class UserAccount : ILocation
    {
        private string _userId;
        private string _userName;
        private string _userEmail;
        private string _userPassword;
        private string _userMobilePhone;
        private string _userPhone;
        private ILocation _userLocation;

        // constructor
        public UserAccount(string userName, string userEmail, string userPassword, string userMobilePhone, string userPhone, ILocation userLocation)
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
            if (userName.Trim() == "")
            {
                throw new ArgumentNullException(nameof(userName), "Name can't be null.");
            }

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

        public string UserMobilePhone
        {
            get => _userMobilePhone;
            set => _userMobilePhone = value;
        }

        public string UserPhone
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
