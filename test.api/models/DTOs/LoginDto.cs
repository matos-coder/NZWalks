﻿using System.ComponentModel.DataAnnotations;

namespace test.api.models.DTOs
{
    public class LoginDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
