using System;

namespace BaseLibrary
{
    public abstract class Base
    {
        private bool _isActive;
        private Guid _insertedBy;
        private DateTime? _createdAt;
        private DateTime? _updatedAt;

        // contructor
        public Base()
        {
        }

        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        public Guid InsertedBy
        {
            get => _insertedBy;
            set => _insertedBy = value;
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
