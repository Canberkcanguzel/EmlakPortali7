﻿using System.ComponentModel.DataAnnotations;

namespace EmlakPortali7.Models
{
    public class UserModels
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
