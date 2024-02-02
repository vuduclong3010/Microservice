﻿namespace ProjectServiceB.Models
{
    public class Customer
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Avatar { get; set; }

        public bool IsDeleted { get; set; }
    }
}
