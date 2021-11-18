using System;

namespace LocationLibrary
{

    public partial class Location
    {
        private string _address;
        private int _lat;
        private int _lng;
        private string _suburb;
        private string _postcode;
        private string _state;

        // constructor
        public Location(string address, int lat, int lng, string suburb, string postcode, string state)
        {
            _address = address;
            _lat = lat;
            _lng = lng;
            _suburb = suburb;
            _postcode = postcode;
            _state = state;
        }

        public string Address
        {
            get => _address;
            set => _address = value;
        }
        public int Lat
        {
            get => _lat;
            set => _lat = value;
        }

        public int Lng
        {
            get => _lng;
            set => _lng = value;
        }

        public string Suburb
        {
            get => _suburb;
            set => _suburb = value;
        }

        public string Postcode
        {
            get => _postcode;
            set => _postcode = value;
        }

        public string State
        {
            get => _state;
            set => _state = value;
        }

    }

}
