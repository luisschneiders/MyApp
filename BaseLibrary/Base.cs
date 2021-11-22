using System;

namespace BaseLibrary
{
    public abstract class Base
    {
        private DateTime? _createdAt;
        private DateTime? _updatedAt;

        // contructor
        public Base()
        {
        }

        public DateTime? CreatedAt
        {
            get => _createdAt;
            set => _createdAt = value;
        }

        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            set => _updatedAt = value;
        }

    }
}
