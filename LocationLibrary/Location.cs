using System;

namespace LocationLibrary
{
    public interface ILocation
    {
        string Address { get; set; }
        int Lat { get; set; }
        int Lng { get; set; }
        string Suburb { get; set; }
        string Postcode { get; set; }
        string State { get; set; }
    }

    public class Location: ILocation
    {
        private string _address;
        private int _lat;
        private int _lng;
        private string _suburb;
        private string _postcode;
        private string _state;

        public Location()
        {
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
