﻿using DataAccessLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Customer : BaseEntity
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public int AdressId { get; set; }
        public Adress Adress { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public RoleType Role { get; set; }
    }
}